import { expect } from 'chai';
import { it } from 'mocha';

import 'reflect-metadata';

import { myContainer } from '../../src/app/di/container';
import { ICompanyService, IProjectService } from '../../src/app/di/interfaces/services';
import { TYPES } from '../../src/app/di/types/types';
import { ICompany } from '../../src/app/model/Company';
import type { IProject, IProjectDto } from '../../src/app/model/Project';
import { ITimeLog } from '../../src/app/model/TimeLog';
import { guid } from '../../src/app/utils/guid';

let companyService: ICompanyService;
let projectService: IProjectService;

before(async () => {
  projectService = myContainer.get<IProjectService>(TYPES.IProjectService);
  companyService = myContainer.get<ICompanyService>(TYPES.ICompanyService);
  console.info('Project & Company service was loaded');
});

describe("Projects", function () {
  const companies: ICompany[] = [];
  let companyId: string;
  let projectId: string = guid();

  describe("Preparation", function () {
    it("load companies", async () => {
      const companyList = await companyService.getList();
      companies.push(...companyList);
      expect(companies.length).to.greaterThan(0);
      companyId = companies[0].id;
    });
  });

  describe("Create new project", function () {
    it("save project", async () => {
      const rawProject: IProject = {
        id: projectId,
        name: 'Test Project',
        completed: false,
        companyId: companyId,
        deadline: new Date(Date.now() + 1000 * 60 * 60 * 24 * 14).toISOString(),
      };

      const dto = projectService.rawToDto(rawProject)!;
      await projectService.create(dto);
    });
  });

  describe("Get the new project for Db", function () {
    it("save project", async () => {
      const item: IProjectDto = await projectService.get(projectId);
      expect(Boolean(item)).to.true;
    });
  });

  describe("List all project for same company", function () {
    it("save project", async () => {
      const filters = { companyId };
      const projects = await projectService.getList({ ...filters, sortKey: 'createdAt', sortDir: 'DESC' });
      expect(projects.length).to.greaterThan(0);
      expect(projects.some(x => x.id === projectId)).to.true;
    });
  });

  describe("Register +2h time for the project", function () {
    it("update project", async () => {
      const project = await projectService.get(projectId);
      const oldTimeSpent = project.totalSpentTime;
      const newLog = {
        id: guid(),
        createdAt: new Date().toISOString(),
        loggedMinutes: 120,
        projectId: projectId,
      } as ITimeLog;
      project.logs.push(newLog);
      await projectService.update(project);
      const updatedProject = await projectService.get(projectId);
      expect(updatedProject.totalSpentTime).to.deep.equal(oldTimeSpent + 120);
    });
  });

  describe("Clean up", function () {
    it("delete the test project", async () => {
      await projectService.delete(projectId);
      let project: IProjectDto | null = null;
      try {
        project = await projectService.get(projectId);
      } catch (err) {
        // we catch the error
      }
      expect(Boolean(project)).to.false;
    });
  });
});