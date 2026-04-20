import {useEffect, useState} from "react";
import projectAPI from "./services/projectAPI";
import Project from "./models/Project";
import ProjectDetail from "./ProjectDetail";
import {useParams} from "react-router-dom";

function ProjectPage() {
    const [loading, setLoading] = useState<boolean>(false);
    const [project, setProject] = useState<Project | null>(null);
    const [error, setError] = useState<string | undefined>(undefined);

    const params = useParams();

    const projectId = Number(params.id);

    useEffect(() => {
        async function loadProject(){
            setLoading(true);
            projectAPI.find(projectId)
            .then((data) => {
                setProject(data);
                setError(undefined);
            })
            .catch((error) => {
                if(error instanceof Error) {
                    setError(error.message);
                }
            })
            .finally(() => {
                setLoading(false);
            });
        }
        loadProject();
    }, [projectId]);

    return (
        <>
            <h1>Project Details</h1>

            {
                loading && (
                    <div className='center-page'>
                        <span className='spinner primary'></span>
                        <p>Loading project details...</p>
                    </div>
                )
            }

            <div className='row'>
                {
                    error && (
                        <div className='card large error'>
                            <section>
                                <p>
                                    <span className='icon-alert inverse'></span>
                                    {error}
                                </p>
                            </section>
                        </div>
                    )
                }
            </div>

            {project && (
                <ProjectDetail project={project} />
            )}
        </>
    );
}

export default ProjectPage;
