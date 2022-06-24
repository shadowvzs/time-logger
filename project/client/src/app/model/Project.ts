import { IBaseEntity } from "../core/model/BaseEntity";
import { ITimeLog } from "./TimeLog";
import { ICompany } from "./Company";

export interface IProject extends IBaseEntity {
    name: string;
    deadline: string;
    companyId: string;
    completed: boolean;
}

export interface IProjectDto extends IBaseEntity {
    name: string;
    deadline: Date | null;
    completed: boolean;
    company?: ICompany;
    logs: ITimeLog[];

    totalSpentTime: number;
    isEnded: boolean;
}
