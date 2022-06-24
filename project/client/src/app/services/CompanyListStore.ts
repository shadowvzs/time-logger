import { injectable } from "inversify";

import { BaseListStore } from "../core/services/BaseListStore";
import { ICompanyListStore } from "../di/interfaces/services";
import { ICompany } from "../model/Company";
import { CompanyService } from "./CompanyService";

@injectable()
export class CompanyListStore extends BaseListStore<ICompany> implements ICompanyListStore {
    constructor() {
        super(new CompanyService());
    }
}