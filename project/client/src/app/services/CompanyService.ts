import { injectable } from "inversify";

import { BaseService } from "../core/services/BaseService";
import { api } from "../api/api";
import type { ICompanyService } from "../di/interfaces/services";
import type { ICompany } from "../model/Company";

@injectable()
export class CompanyService extends BaseService<ICompany> implements ICompanyService {
    constructor() {
        super(api.companies);
    }
}