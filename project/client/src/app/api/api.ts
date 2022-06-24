import { config } from "../global/config";

export interface ApiRequestData {
	url: string;
	method?: 'GET' | 'POST' | 'PUT' | 'DELETE';
}

export interface IBaseCrudApi {
	get: (id: string) => ApiRequestData;
	getList: () => ApiRequestData;
	create: () => ApiRequestData;
	update: (id: string) => ApiRequestData;
	delete: (id: string) => ApiRequestData;
}

export const api = {
	companies: {
		get: (id: string) => ({
			url: `${config.BASE_URL}/companies/${id}`
		}),
		getList: () => ({
			url: `${config.BASE_URL}/companies`
		}),
		create: () => ({
			url: `${config.BASE_URL}/companies`
		}),
		update: (id: string) => ({
			url: `${config.BASE_URL}/companies/${id}`
		}),
		delete: (id: string) => ({
			url: `${config.BASE_URL}/companies/${id}`
		}),
	},
	projects: {
		get: (id: string) => ({
			url: `${config.BASE_URL}/projects/${id}`
		}),
		getList: () => ({
			url: `${config.BASE_URL}/projects`
		}),
		create: () => ({
			url: `${config.BASE_URL}/projects`
		}),
		update: (id: string) => ({
			url: `${config.BASE_URL}/projects/${id}`
		}),
		delete: (id: string) => ({
			url: `${config.BASE_URL}/projects/${id}`
		}),
	} as IBaseCrudApi
}
