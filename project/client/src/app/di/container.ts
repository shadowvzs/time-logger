import { Container } from 'inversify';

import { TYPES } from './types/types';
import type { ICompanyListStore, ICompanyService, IConfig, IProjectListStore, IProjectService } from './interfaces/services';

import { ProjectService } from '../services/ProjectService';
import { ProjectListStore } from '../services/ProjectListStore';
import { config } from '../global/config';
import { CompanyService } from '../services/CompanyService';
import { CompanyListStore } from '../services/CompanyListStore';

const myContainer = new Container({ skipBaseClassChecks: true });
myContainer.bind<IConfig>(TYPES.IConfig).toConstantValue(config);

myContainer.bind<IProjectService>(TYPES.IProjectService).to(ProjectService).inSingletonScope();
myContainer.bind<IProjectListStore>(TYPES.IProjectListStore).to(ProjectListStore).inSingletonScope();
myContainer.bind<ICompanyService>(TYPES.ICompanyService).to(CompanyService).inSingletonScope();
myContainer.bind<ICompanyListStore>(TYPES.ICompanyListStore).to(CompanyListStore).inSingletonScope();

export { myContainer };