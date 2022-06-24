import React from "react";
import { runInAction } from "mobx";
import { Container } from "inversify";
import {
	CheckCircleOutline as InProgressIcon,
	CheckCircle as CompletedIcon,
	DeleteForever as DeleteIcon
} from '@mui/icons-material';

import type { ICompanyListStore, IProjectListStore, IProjectService } from "../../di/interfaces/services";
import { TYPES } from "../../di/types/types";
import type { IProject, IProjectDto } from "../../model/Project";
import { ProjectListStore } from "../../services/ProjectListStore";
import { CompanyListStore } from "../../services/CompanyListStore";
import { SelectChangeEvent } from "@mui/material/Select";
import { Link } from "react-router-dom";
import { dateFormatter, minuteDurationFormatter } from "../../utils/formatters";

export interface IListConfig {
	id: string;
	title: string;
	style: React.CSSProperties;
	getValue: (item: IProjectDto) => React.ReactNode;
	onClick?: (item: IProjectDto) => void;

	getSortDir?: () => 'ASC' | 'DESC';
	setSortDir?: () => void;
}

const icons = [
	{
		Icon: InProgressIcon,
		style: { fill: 'blue' }
	},
	{
		Icon: CompletedIcon,
		style: { fill: 'green' }
	}
];

export class ProjectListViewStore {
	private sortDirection: Record<string, 'ASC' | 'DESC'> = {};
	public listStore: ProjectListStore;
	public companyListStore: CompanyListStore;
	public sortableFields = ['name', 'companyName', 'timeSpent', 'deadline', 'completed'];

	public listConfig: IListConfig[] = [
		{
			id: 'name',
			title: 'Project Name',
			getValue: (item: IProjectDto) => {
				if (!item || !item.name) { return '-'; }
				return (
					<Link to={`/projects/${item.id}`}>{item.name}</Link>
				);
			},
			style: { flex: 5, minWidth: 0, textAlign: 'center' },
		},
		{
			id: 'companyName',
			title: 'Company Name',
			getValue: (item: IProjectDto) => item.company?.name || '-',
			style: { flex: 5, minWidth: 0, textAlign: 'center' }
		},
		{
			id: 'timeSpent',
			title: 'Time Spent',
			getValue: (item: IProjectDto) => {
				return minuteDurationFormatter(item.totalSpentTime);
			},
			style: { flex: 4, minWidth: 0, textAlign: 'center' }
		},
		{
			id: 'deadline',
			title: 'Deadline',
			getValue: (item: IProjectDto) => {
				return (
					<p style={{ fontSize: 12, color: item.isEnded ? 'red' : 'inherit' }}>{dateFormatter(item.deadline!)}</p>
				);
			},
			style: { flex: 5, minWidth: 0, textAlign: 'center' }
		},
		{
			id: 'completed',
			title: 'Done',
			getValue: (item: IProjectDto) => {
				const { Icon, style } = icons[+item.completed];
				return (
					<>
						<Icon
							style={{ ...style, cursor: 'pointer' }}
							onClick={() => {
								runInAction(() => item.completed = !item.completed);
								this.listStore.service.update(item);
							}}
						/>
						<DeleteIcon
							style={{ fill: 'red', cursor: 'pointer', fontSize: 28 }}
							onClick={() => {
								this.listStore.service.delete(item.id);
								this.listStore.fetch();
							}}

						/>
					</>
				);
			},
			style: { flex: 2, minWidth: 0, textAlign: 'center' },
		},
	]

	constructor(container: Container) {
		this.listConfig
			.filter(x => this.sortableFields.includes(x.id))
			.forEach(config => {
				config.getSortDir = () => this.sortDirection[config.id] || 'ASC';
				config.setSortDir = () => this.sortHelper(config.id);
				this.sortDirection[config.id] = 'ASC';
			});
		this.listStore = container.get<IProjectListStore>(TYPES.IProjectListStore);
		this.listStore.setSort('deadline', 'ASC');
		this.companyListStore = container.get<ICompanyListStore>(TYPES.ICompanyListStore);
		this.companyListStore.fetch();
	}

	public sortHelper(key: string) {
		let { sortKey, sortDir } = this.listStore;
		if (sortKey === key) {
			sortDir = (['ASC', 'DESC'] as const)[+(sortDir === 'ASC')];
		} else {
			sortKey = key;
		}
		this.sortDirection[sortKey] = sortDir;
		this.listStore.setSort(sortKey, sortDir);
	}

	public onChangeCompanyFilter = (ev: SelectChangeEvent<string>): void => {
		const value = ev.target.value;
		this.listStore.setFilter('companyId', value);
	}

	public onAddProject = (rawProject: IProject): void => {
		const projectService = (this.listStore.service as IProjectService);
		const dto = projectService.rawToDto(rawProject)!;
		projectService.create(dto);
		this.listStore.fetch();
	}
}