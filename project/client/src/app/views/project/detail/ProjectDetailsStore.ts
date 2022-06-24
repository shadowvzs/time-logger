import { Container } from "inversify";

import { TYPES } from "../../../di/types/types";
import type { ICompanyListStore, IProjectService } from "../../../di/interfaces/services";
import { action, makeObservable, observable } from "mobx";
import type { IProjectDto } from "../../../model/Project";
import { ITimeLog } from "../../../model/TimeLog";
import { guid } from "../../../utils/guid";
import { NavigateFunction } from "react-router-dom";

export class ProjectDetailsStore {

	public service: IProjectService;
	public companyListStore: ICompanyListStore;

	public item: IProjectDto;
	public setItem(item: IProjectDto) { this.item = item; }

	constructor(
		container: Container,
		navigate: NavigateFunction,
		projectId: string
	) {
		this.service = container.get<IProjectService>(TYPES.IProjectService);
		this.companyListStore = container.get<ICompanyListStore>(TYPES.ICompanyListStore);
		this.companyListStore.fetch();
		makeObservable(this, {
			item: observable,
			setItem: action.bound,
			addLog: action.bound,
		});

		this.service.get(projectId)
			.then(proj => this.setItem(proj))
			.catch(() => navigate('/projects'));
	}

	public addLog(amount: number) {
		const log = {
			id: guid(),
			createdAt: new Date().toISOString(),
			loggedMinutes: amount,
			projectId: this.item.id,
		} as ITimeLog;
		this.item.logs = [...this.item.logs, log];
		this.service.update(this.item);
	}
}