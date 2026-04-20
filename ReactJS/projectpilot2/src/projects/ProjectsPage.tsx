//import MOCK_PROJECTS from "./MockProjects";
import ProjectList from "./ProjectList";
//import Project from "./models/Project";
//import { useState, useEffect } from "react";
//import projectAPI from "./services/projectAPI";
import { useProjects } from "./hooks/projectHooks";

function ProjectsPage() {

  // const [projects, setProjects] = useState<Project[]>(MOCK_PROJECTS);
  // const [loading, setLoading] = useState<boolean>(false);
  // const [error, setError] = useState<string | undefined>(undefined);
  // const [projects, setProjects] = useState<Project[]>([]);
  // const [currentPage, setCurrentPage] = useState<number>(1);

  // useEffect(() => {
  //   setLoading(true);
  //   projectAPI.get(1)
  //   .then((data) => {
  //     setError(undefined);
  //     setLoading(false);
  //     setProjects(data);
  //   })
  //   .catch((error) => {
  //     setError(error.message);
  //     setLoading(false);
  //     if(error instanceof Error) {
  //       setError(error.message);
  //     }
  //   });
  // }, [currentPage]);

  // useEffect(() => {
  //   async function loadProjects(){
  //     setLoading(true);
  //     try {
  //       //const data = await projectAPI.get(1);
  //       const data = await projectAPI.get(currentPage);
  //       // setError(undefined);
  //       // setProjects(data);
  //       if(currentPage === 1) {
  //         setProjects(data);
  //         setError(undefined);
  //       } else {
  //         setProjects((prevProjects) => [...prevProjects, ...data]);
  //       }
  //     } catch (error) {
  //       if(error instanceof Error) {
  //         setError(error.message);
  //       } else {
  //         setError("An unknown error occurred while fetching projects.");
  //       }
  //     }
  //     finally{
  //       setLoading(false);
  //     }
  //   }
  //   loadProjects();
  // }, [currentPage]);

  const {
    projects,
    loading,
    error,
    setCurrentPage,
    saveProject,
    saving,
    savingError
  } = useProjects();

  const handleMoreProjects = () => {
    setCurrentPage((prevPage) => prevPage + 1);
  };

  // const handleSaveProject = (project: Project) => {
  //   //console.log("Saving project:", project);
  //   // Here you would typically send the project data to a backend API to save it
  //   // const updatedProjects: Project[] = projects.map((p) => p.id === project.id ? project : p);
  //   // setProjects(updatedProjects);

  //   projectAPI.put(project)
  //   .then((updatedProject) => {
  //     const updatedProjects: Project[] = projects.map((p: Project) => p.id === updatedProject.id 
  //       ? new Project(updatedProject) : p);
  //     setProjects(updatedProjects);
  //   })
  //   .catch((error) => {
  //     if(error instanceof Error) {
  //       setError(`Failed to save project: ${error.message}`);
  //     }
  //   });
  // }

  return (
    <>
      <h1>Projects Page</h1>
      <hr/>
      {
        saving && (
          <span className="toast">Saving project...</span>
        )
      }
      {error && (
        <div className="row">
          <div className="card large error">
            <section>
              <p>
                <span className="icon-alert inverse"></span>
                {error}
              </p>
            </section>
          </div>
        </div>
      )}
      {
        savingError && (
          <div className="row">
            <div className="card large error">
              <section>
                <p>
                  <span className="icon-alert inverse"></span>
                  {savingError}
                </p>
              </section>
            </div>
          </div>
        )
      }
      {/* <pre>{JSON.stringify(MOCK_PROJECTS, null, 2)}</pre> */}
      {/* <ProjectList projects={MOCK_PROJECTS} /> */}
      {/* <ProjectList projects={MOCK_PROJECTS} onSave={handleSaveProject} /> */}
      {/* <ProjectList projects={projects} onSave={handleSaveProject} /> */}
      <ProjectList projects={projects} onSave={saveProject} />
      {
        !loading && !error && (
          <div className="row">
            <div className="col-sm-12">
              <div className="button-group fluid">
                <button className="button primary" onClick={handleMoreProjects}>
                  Load More Projects...
                </button>
              </div>
            </div>
          </div>
        )
      }
      {
        loading && (
          <div className="center-page">
            <span className="spinner primary"></span>
            <p>Loading projects...</p>
          </div>
        )
      }
    </>
  )
}

export default ProjectsPage;