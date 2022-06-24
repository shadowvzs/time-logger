import { IBaseEntity } from "../core/model/BaseEntity";

export interface ITimeLog extends IBaseEntity {
    createdAt: string;
    loggedMinutes: number;
    projectId: string;
}