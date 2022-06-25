import { injectable } from "inversify";

import type { IProject, IProjectDto } from "../model/Project";
import { BaseService } from "../core/services/BaseService";
import { api } from "../api/api";
import type { IProjectService } from "../di/interfaces/services";
import { fakeDb } from "./dummyDb";
import { guid } from "../utils/guid";
import { sendMsg } from "../core/components/toastify/Toastify";

@injectable()
export class ProjectService extends BaseService<IProjectDto> implements IProjectService {
    constructor() {
        super(api.projects);
    }

    /* overwrite the base method which would call the endpoint and we use fake frontend db */

    public rawToDto(item: IProject): IProjectDto {
        const dto = {
            id: item.id,
            deadline: item.deadline ? new Date(item.deadline) : null,
            companyId: item.companyId,
            company: fakeDb.companies.find(x => x.id === item.companyId),
            completed: item.completed,
            name: item.name,
            logs: fakeDb.logs.filter(x => x.projectId === item.id),
            get totalSpentTime() {
                return this.logs.reduce((t, c) => t + c.loggedMinutes, 0);
            },
            get isEnded() {
                return (this.deadline && this.deadline.getTime() < Date.now()) || false;
            },
        }
        return dto;
    }

    public dtoToRaw(item: IProjectDto): IProject {
        const raw = {
            id: item.id || guid(),
            name: item.name,
            deadline: item.deadline?.toISOString(),
            companyId: item.company?.id,
            completed: item.completed || false,
        } as IProject;
        return raw;
    }

    // this is used only for frontend sorting, normaly we don't need this because we send it to backend
    private sortResolver(a: IProjectDto, b: IProjectDto, sortKey: string, sortDir: 1 | -1): number {
        if (sortKey === 'name') {
            return a.name.localeCompare(b.name) * sortDir;
        } else if (sortKey === 'companyName') {
            return (a.company?.name || '').localeCompare(b.company?.name || '') * sortDir;
        } else if (sortKey === 'timeSpent') {
            return a.totalSpentTime - b.totalSpentTime * sortDir;
        } else if (sortKey === 'deadline') {
            return ((a.deadline?.getTime() || 0) - (b.deadline?.getTime() || 0)) * sortDir;
        } else if (sortKey === 'completed') {
            return (+a.completed - +b.completed) * sortDir;
        }
        return 0;
    }

    public async get(id: string) {
        const project = this.transform(await super.get(id));
        if (!project) {
            throw new Error(`Entity is missing (id: ${id})`);
        }
        return project;
    }

    public transform(item: IProjectDto): IProjectDto {
        if (typeof item.deadline === 'string') {
            item.deadline = new Date(item.deadline);
        }
        if (!item.hasOwnProperty('totalSpentTime')) {
            Object.defineProperty(item, 'totalSpentTime', {
                get: function () { return item.logs.reduce((t, c) => t + c.loggedMinutes, 0); }
            });
        }
        if (!item.hasOwnProperty('isEnded')) {
            Object.defineProperty(item, 'isEnded', {
                get: function () { return (item.deadline && this.deadline.getTime() < Date.now()) || false; }
            });
        }
        return item;
    }

    public async getList(params?: Record<string, string | number | boolean>) {
        let projects = (await super.getList(params)).map(this.transform);
        if (params) {
            // filter out on frontend, which often happens on backend not here, just I not used backend here
            if (params.companyId) {
                projects = projects.filter(x => x.company?.id === params.companyId);
            }
            if (params.sortKey && params.sortDir) {
                const sortDir = params.sortDir === 'ASC' ? 1 : -1;
                projects = projects.sort((a, b) => this.sortResolver(a, b, params.sortKey as string, sortDir))
            }
        }

        return projects;
    }

    public async create(item: IProjectDto): Promise<IProjectDto> {
        const savedItem = await super.create(item);

        if (sendMsg) { sendMsg('success', `Project "${item.name}" was created!`); }
        return this.transform(savedItem);
    }

    public async update(item: IProjectDto): Promise<IProjectDto> {
        await super.update(item);
        if (sendMsg) { sendMsg('success', `Project "${item.name}" was updated!`); }
        return item;
    }

    public async delete(id: string) {
        await super.delete(id);
        if (sendMsg) { sendMsg('success', `Project was deleted!`); }
    }
}