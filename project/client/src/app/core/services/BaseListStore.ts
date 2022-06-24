import { action, makeObservable, observable, runInAction } from "mobx";
import { IBaseEntity } from "../model/BaseEntity";
import { IBaseService } from "./BaseService";

export interface IBaseListStore<T extends IBaseEntity> {
    sortKey: string;
    sortDir: 'ASC' | 'DESC';
    items: T[];
    isLoading: boolean;
    filters: Record<string, any>;
    service: IBaseService<T>;
    fetch: () => Promise<T[]>;
    setItems: (items: T[]) => void;
    setFilter: (ket: string, value: any) => void;
    setFilters: (filters: Record<string, any>) => void;
    setSort: (sortKey: string, sortDir: 'ASC' | 'DESC') => void;
}

export class BaseListStore<T extends IBaseEntity> implements IBaseListStore<T> {
    public items: T[] = [];
    public isLoading: boolean = false;
    public filters: Record<string, any> = {};
    public sortKey: string;
    public sortDir: 'ASC' | 'DESC';
   
    constructor(public service: IBaseService<T>) {
        makeObservable(this, {
            items: observable,
            isLoading: observable,
            filters: observable,
            sortKey: observable,
            sortDir: observable,
            fetch: action.bound,
            setItems: action.bound,
            setFilters: action.bound,
            setSort: action.bound,
        });
    }

    public setItems(items: T[]) { this.items = items; }
    public setFilters(filters: Record<string, any>) { 
        this.filters = filters;
        this.fetch();
    }
    public setFilter(key: string, value: any) { 
        this.setFilters({ ...this.filters, [key]: value });
    }

    public setSort(sortKey: string, sortDir: 'ASC' | 'DESC') { 
        this.sortKey = sortKey;
        this.sortDir = sortDir;
        this.fetch();
    }

    public async fetch() {
        this.isLoading = true;
        const list = await this.service.getList({ ...this.filters, sortKey: this.sortKey, sortDir: this.sortDir })
            .finally(() => runInAction(() => this.isLoading = false));
        this.setItems(list);
        return list;
    }
}