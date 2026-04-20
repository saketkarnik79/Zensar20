import {useState, useEffect} from 'react';
import Project from '../models/Project';
import projectAPI from '../services/projectAPI';

 function useProjects() {
    const [projects, setProjects] = useState<Project[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | undefined>(undefined);
    const [currentPage, setCurrentPage] = useState<number>(1);
    const [saving, setSaving] = useState<boolean>(false);
    const [savingError, setSavingError] = useState<string | undefined>(undefined);

    useEffect(() => {
        async function loadProjects() {
            setLoading(true);
            try{
                const data = await projectAPI.get(currentPage);
                if(currentPage === 1){
                    setProjects(data);
                } else {
                    setProjects(prevProjects => [...prevProjects, ...data]);
                }
            }
            catch(error: Error | unknown){
                setError(error instanceof Error ? error.message : 'An unknown error occurred');
            }
            finally{
                setLoading(false);
            }
        }
        loadProjects();
    }, [currentPage]);

    const saveProject =(project: Project) => {
        setSaving(true);
        projectAPI.put(project)
            .then((updatedProject) => {
                const updatedProjects = projects.map(p => p.id === project.id 
                    ? new Project(updatedProject) : p);
                setProjects(updatedProjects);
            })
            .catch((error: Error | unknown) => {
                setSavingError(error instanceof Error ? error.message : 'An unknown error occurred');
            })
            .finally(() => {
                setSaving(false);
            });
    };
    return {
        projects,
        loading,
        error,
        currentPage,
        setCurrentPage,
        saving,
        savingError,
        saveProject
    }
}

export {useProjects};