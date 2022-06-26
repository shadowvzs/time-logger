import { IBaseCrudApi } from "../../api/api";
import { IBaseEntity } from "../model/BaseEntity";
import { PaginationResult } from "../model/PaginationResult";

export interface IBaseService<T extends IBaseEntity> {
    get: (id: string) => Promise<T>;
    getList: (params?: Record<string, string | number | boolean>) => Promise<PaginationResult<T>>;
    create: (item: T) => Promise<T>;
    update: (item: T) => Promise<T>;
    delete: (id: string) => Promise<void>;
}

export abstract class BaseService<T extends IBaseEntity> implements IBaseService<T> {
    constructor(protected _api: IBaseCrudApi) {
    }

    public async get(id: string) {
        const { url, method } = this._api.get(id);
        const response = await fetch(url, {
            method: method || 'GET',
        });
        const entity = await response.json() as T;
        return entity;
    }

    public async getList(params?: Record<string, string | number | boolean>): Promise<PaginationResult<T>> {
        let { url, method } = this._api.getList();

        if (params) {
            const queryParams = Object.entries(params).map(([key, value]) => `${key}=${String(value)}`).join('&');
            url += ['?', '&'][+url.includes('?')] + queryParams;
        }

        const response = await fetch(url, { method: method || 'GET' });
        return await response.json() as PaginationResult<T>;
    }

    public async create(item: T) {
        const { url, method } = this._api.create();
        const response = await fetch(url, {
            method: method || 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(item)
        });
        const entity = await response.json() as T;
        return entity;
    }

    public async update(item: T) {
        const { url, method } = this._api.update(item.id);
        const response = await fetch(url, {
            method: method || 'PUT',
            body: JSON.stringify(item),
            headers: {
                'content-type': 'application/json'
            },
        });
        const entity = await response.json() as T;
        return entity;
    }

    public async delete(id: string) {
        const { url, method } = this._api.delete(id);
        await fetch(url, {
            method: method || 'DELETE',
        });
    }
}
