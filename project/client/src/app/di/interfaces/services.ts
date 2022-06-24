import { IBaseListStore } from "../../core/services/BaseListStore";
import { IBaseService } from "../../core/services/BaseService";
import { ICompany } from "../../model/Company";
import { IProject, IProjectDto } from "../../model/Project";

export interface IProjectService extends IBaseService<IProjectDto> {
    rawToDto: (item?: IProject) => IProjectDto | undefined;     
    dtoToRaw: (item?: IProjectDto) => IProject | undefined;
}

export interface IProjectListStore extends IBaseListStore<IProjectDto> {

}

export interface ICompanyService extends IBaseService<ICompany> {

}

export interface ICompanyListStore extends IBaseListStore<ICompany> {

}


export interface IConfig {
    BASE_URL: string;
    SITE_NAME: string;
}