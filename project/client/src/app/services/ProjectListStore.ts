import { injectable } from "inversify";

import { BaseListStore } from "../core/services/BaseListStore";
import { IProjectListStore } from "../di/interfaces/services";
import { IProjectDto } from "../model/Project";
import { ProjectService } from "./ProjectService";

@injectable()
export class ProjectListStore extends BaseListStore<IProjectDto> implements IProjectListStore {
    constructor() {
        super(new ProjectService());
    }
}