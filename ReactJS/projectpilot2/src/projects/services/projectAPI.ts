import Project from "../models/Project";
const API_BASE_URL = "http://localhost:4000/projects";

function translateStatusToErrorMessage(status: number): string {
    switch(status) {
        case 401: return "Please log in to access this resource.";
        case 403: return "You do not have permission to access this resource.";
        default: return `An error occurred (status code: ${status}). Please try again later.`;
    }
}

function checkStatus(response: Response): Response {
    if(response.ok) {
        return response;
    } else {
        const httpErrorInfo = {
            status: response.status,
            statusText: response.statusText,
            url: response.url
        };
        console.error(`Log server http error: ${JSON.stringify(httpErrorInfo)}`);
        const errorMessage = translateStatusToErrorMessage(response.status);
        throw new Error(errorMessage);
    }
}

function parseJSON(response: Response) {
    return response.json();
}


function delay(ms: number) {
    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    return function(x: any): Promise<any> {
        return new Promise(resolve => setTimeout(() => resolve(x), ms));
    }
}

// eslint-disable-next-line @typescript-eslint/no-explicit-any
function convertToProjectModel(item: any): Project {
    return new Project(item);
}

// eslint-disable-next-line @typescript-eslint/no-explicit-any
function convertToProjectModels(res: {data: any[]}): Project[] {
    const projects: Project[] = (res.data).map(convertToProjectModel);
    return projects;
}

const projectAPI = {
    get(page: number = 1, limit: number = 9){
        return fetch(`${API_BASE_URL}?_page=${page}&_per_page=${limit}`)
            .then(delay(2000))
            .then(checkStatus)
            .then(parseJSON)
            .then(convertToProjectModels)
            .catch((error: TypeError) => {
                console.error(`Error fetching projects: ${error.message}`);
                throw error;
            });
    },
    find(id: number){
        return fetch(`${API_BASE_URL}/${id}`)
            .then(delay(2000))
            .then(checkStatus)
            .then(parseJSON)
            .then(convertToProjectModel)
            .catch((error: TypeError) => {
                console.error(`Error fetching project with id ${id}: ${error.message}`);
                throw error;
            });
    },
    put(project: Project) {
         return fetch(`${API_BASE_URL}/${project.id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(project)
         })
        .then(delay(2000))
        .then(checkStatus)
        .then(parseJSON)
        .catch((error: TypeError) => {
            console.error(`Error fetching projects: ${error.message}`);
            throw error;
        });
    }
};

export default projectAPI;