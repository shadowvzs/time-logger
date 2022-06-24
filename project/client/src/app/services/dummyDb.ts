import { ICompany } from "../model/Company";
import { IProject } from "../model/Project";
import { ITimeLog } from "../model/TimeLog";

const companiesTable: ICompany[] = [
    {
        id: '01e3903b-fabf-43bf-ad1f-550eee74f6bc',
        name: 'Tesco',
    },
    {
        id: '6dd0b608-04a8-42e1-bcaf-971367bd8302',
        name: 'ING',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1ae2',
        name: 'Porche',
    },
    {
        id: 'c6aee1bb-a570-49f4-b3b8-6448e336c42b',
        name: 'BMW',
    },
    {
        id: 'be8a467f-0f93-4993-b516-5ba58e88abf0',
        name: 'Nike',
    },
    {
        id: 'daa4e8ca-929f-43f1-816d-c580f11ff905',
        name: 'Addidas',
    },
];

const projectsTable: IProject[] = [
    {
        id: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        name: 'External portal',
        deadline: '2022-07-22T09:00:00.898Z',
        companyId: '01e3903b-fabf-43bf-ad1f-550eee74f6bc',
        completed: false,
    },
    {
        id: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        name: 'Main project',
        deadline: '2022-07-12T15:00:00.898Z',
        companyId: '01e3903b-fabf-43bf-ad1f-550eee74f6bc',
        completed: false,
    },
    {
        id: '5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775',
        name: 'Proctocol Update',
        deadline: '2022-08-10T12:00:00.898Z',
        companyId: '6dd0b608-04a8-42e1-bcaf-971367bd8302',
        completed: false,
    },
    {
        id: '2593faee-7b0d-4a56-81d8-9466c82a2ac4',
        name: 'Car Preview',
        deadline: '2022-07-01T16:00:00.898Z',
        companyId: '01cfd494-fca0-4a3f-9a2d-1763d62f1ae2',
        completed: false,
    },
    {
        id: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        name: 'SSO Auth',
        deadline: '2022-06-28T16:00:00.898Z',
        companyId: 'c6aee1bb-a570-49f4-b3b8-6448e336c42b',
        completed: false,
    },
    {
        id: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        name: 'Project Update',
        deadline: '2022-07-05T18:00:00.898Z',
        companyId: 'c6aee1bb-a570-49f4-b3b8-6448e336c42b',
        completed: false,
    },
    {
        id: 'b23817f7-1eae-4de4-bd4a-a1d8544604ee',
        name: 'Admin Panel',
        deadline: '2022-07-09T11:00:00.898Z',
        companyId: 'c6aee1bb-a570-49f4-b3b8-6448e336c42b',
        completed: false,
    },
    {
        id: '7f650e8b-f17c-48e5-a343-e7658d9feb39',
        name: 'Shoe Designer Tool',
        deadline: '2022-08-01T07:00:00.898Z',
        companyId: 'be8a467f-0f93-4993-b516-5ba58e88abf0',
        completed: false,
    },
    {
        id: '0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1',
        name: 'Site update',
        deadline: '2022-07-14T10:00:00.898Z',
        companyId: 'daa4e8ca-929f-43f1-816d-c580f11ff905',
        completed: true,
    },
];

const timeLogs: ITimeLog[] = [
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a00',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 30,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a01',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 60,
        createdAt: '2022-07-15T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a02',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 90,
        createdAt: '2022-07-16T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a03',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 60,
        createdAt: '2022-07-17T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a04',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 100,
        createdAt: '2022-07-18T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a05',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 20,
        createdAt: '2022-07-19T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a06',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 50,
        createdAt: '2022-07-20T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a07',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 60,
        createdAt: '2022-07-22T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a08',
        projectId: '1c070edb-5e19-43f7-9727-cbc585524ebb',
        loggedMinutes: 40,
        createdAt: '2022-07-23T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a10',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 120,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a11',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 60,
        createdAt: '2022-07-15T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a12',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 90,
        createdAt: '2022-07-16T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a13',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 120,
        createdAt: '2022-07-17T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a14',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 130,
        createdAt: '2022-07-18T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a15',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 200,
        createdAt: '2022-07-19T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a16',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 160,
        createdAt: '2022-07-20T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a17',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 210,
        createdAt: '2022-07-22T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a18',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 240,
        createdAt: '2022-07-23T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a19',
        projectId: 'c76cab95-4a52-4344-a803-ab78e06c59fd',
        loggedMinutes: 60,
        createdAt: '2022-07-24T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a20',
        projectId: '5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775',
        loggedMinutes: 120,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a21',
        projectId: '5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775',
        loggedMinutes: 60,
        createdAt: '2022-07-15T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a22',
        projectId: '5bb3e3fb-35e6-4d5a-b2ba-f5da9eeac775',
        loggedMinutes: 90,
        createdAt: '2022-07-16T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a30',
        projectId: '2593faee-7b0d-4a56-81d8-9466c82a2ac4',
        loggedMinutes: 120,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a31',
        projectId: '2593faee-7b0d-4a56-81d8-9466c82a2ac4',
        loggedMinutes: 60,
        createdAt: '2022-07-15T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a40',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 20,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a41',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 35,
        createdAt: '2022-07-13T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a42',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 150,
        createdAt: '2022-07-14T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a43',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 135,
        createdAt: '2022-07-18T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a44',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 170,
        createdAt: '2022-07-20T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a45',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 120,
        createdAt: '2022-07-21T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a46',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 90,
        createdAt: '2022-07-22T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a47',
        projectId: '59dedd79-bce9-4c6e-8004-e91196dc7d3b',
        loggedMinutes: 100,
        createdAt: '2022-07-24T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a50',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 35,
        createdAt: '2022-07-01T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a51',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 55,
        createdAt: '2022-07-02T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a52',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 115,
        createdAt: '2022-07-03T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a53',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 45,
        createdAt: '2022-07-05T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a54',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 40,
        createdAt: '2022-07-08T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a55',
        projectId: 'd8d28769-5d6b-4f36-b1e2-6df9f9fec2a6',
        loggedMinutes: 50,
        createdAt: '2022-07-09T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a60',
        projectId: 'b23817f7-1eae-4de4-bd4a-a1d8544604ee',
        loggedMinutes: 480,
        createdAt: '2022-06-01T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a61',
        projectId: 'b23817f7-1eae-4de4-bd4a-a1d8544604ee',
        loggedMinutes: 300,
        createdAt: '2022-06-08T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a62',
        projectId: 'b23817f7-1eae-4de4-bd4a-a1d8544604ee',
        loggedMinutes: 360,
        createdAt: '2022-06-13T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a63',
        projectId: 'b23817f7-1eae-4de4-bd4a-a1d8544604ee',
        loggedMinutes: 300,
        createdAt: '2022-06-15T10:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a70',
        projectId: '7f650e8b-f17c-48e5-a343-e7658d9feb39',
        loggedMinutes: 120,
        createdAt: '2022-07-01T10:00:00.898Z',
    },

    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a80',
        projectId: '0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1',
        loggedMinutes: 180,
        createdAt: '2022-07-02T15:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a81',
        projectId: '0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1',
        loggedMinutes: 240,
        createdAt: '2022-07-04T15:00:00.898Z',
    },
    {
        id: '01cfd494-fca0-4a3f-9a2d-1763d62f1a82',
        projectId: '0d9fb1ae-7e9a-4c07-9112-56199bb9a6f1',
        loggedMinutes: 210,
        createdAt: '2022-07-05T15:00:00.898Z',
    },
];

export const fakeDb = {
    companies: companiesTable,
    projects: projectsTable,
    logs: timeLogs,
    useFakeDelays: true
};
