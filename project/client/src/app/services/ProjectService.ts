import { injectable } from "inversify";

import { IProject, IProjectDto } from "../model/Project";
import { BaseService } from "../core/services/BaseService";
import { api } from "../api/api";
import { IProjectService } from "../di/interfaces/services";
import { fakeDb } from "./dummyDb";
import { guid } from "../utils/guid";
import { delayPromise } from "../utils/delayPromise";
import { sendMsg } from "../core/components/toastify/Toastify";

@injectable()
export class ProjectService extends BaseService<IProjectDto> implements IProjectService {
    constructor() {
        super(api.projects);
    }

    /* overwrite the base method which would call the endpoint and we use fake frontend db */

    public rawToDto(item?: IProject): IProjectDto | undefined {
        if (!item) { return; }
        const dto = {
            id: item.id,
            deadline: item.deadline ? new Date(item.deadline) : null,
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

    public dtoToRaw(item?: IProjectDto): IProject | undefined {
        if (!item) { return; }
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
            return a.totalSpentTime - b.totalSpentTime;
        } else if (sortKey === 'deadline') {
            return ((a.deadline?.getTime() || 0) - (b.deadline?.getTime() || 0)) * sortDir;
        } else if (sortKey === 'completed') {
            return (+a.completed - +b.completed) * sortDir;
        }
        return 0;
    }

    public async get(id: string) {
        const project = fakeDb.projects.find(x => x.id === id);
        if (!project) {
            throw new Error(`Entity is missing (id: ${id})`);
        }
        return this.rawToDto(project) as IProjectDto;
    }

    public async getList(params?: Record<string, string | number | boolean>) {
        let projects = fakeDb.projects.map(x => this.rawToDto(x)!).filter(Boolean);
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

        if (fakeDb.useFakeDelays) { await delayPromise(1000, 2000); }
        return projects;
    }

    public async create(item: IProjectDto): Promise<IProjectDto> {
        const rawProject = {
            id: guid(),
            name: item.name,
            deadline: item.deadline?.toISOString(),
            companyId: item.company?.id,
            completed: false,
        } as IProject;
        fakeDb.projects.push(rawProject);
        if (fakeDb.useFakeDelays) { await delayPromise(500, 1000) };
        sendMsg('success', `Project "${item.name}" was created!`);
        return this.rawToDto(rawProject)!;
    }

    public async update(item: IProjectDto): Promise<IProjectDto> {
        const raw = this.dtoToRaw(item)!;
        const projectIdx = fakeDb.projects.findIndex(x => x.id === item.id);
        if (projectIdx >= 0) {
            fakeDb.projects[projectIdx] = raw;
        }
        if (item.logs.length) {
            const newLogs = [...item.logs];
            fakeDb.logs = [...fakeDb.logs.filter(x => x.projectId !== item.id), ...newLogs];
        }
        if (fakeDb.useFakeDelays) { await delayPromise(500, 1000); }
        sendMsg('success', `Project "${item.name}" was updated!`);
        return item;
    }

    public async delete(id: string) {
        fakeDb.projects = fakeDb.projects.filter(x => x.id !== id);
        fakeDb.logs = fakeDb.logs.filter(x => x.projectId !== id);
        if (fakeDb.useFakeDelays) { await delayPromise(500, 1000); }
        sendMsg('success', `Project was deleted!`);
    }
}