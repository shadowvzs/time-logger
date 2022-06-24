import { injectable } from "inversify";

import { BaseService } from "../core/services/BaseService";
import { api } from "../api/api";
import { ICompanyService } from "../di/interfaces/services";
import { fakeDb } from "./dummyDb";
import { delayPromise } from "../utils/delayPromise";
import { ICompany } from "../model/Company";

@injectable()
export class CompanyService extends BaseService<ICompany> implements ICompanyService {
    constructor() {
        super(api.companies);
    }

    /* overwrite the base method which would call the endpoint and we use fake frontend db */
    public async get(id: string) {
        return fakeDb.companies.find(x => x.id === id) as ICompany;
    }

    public async getList() {
        const companies = fakeDb.companies;
        if (fakeDb.useFakeDelays) { await delayPromise(500, 1000); }
        return companies;
    }
}