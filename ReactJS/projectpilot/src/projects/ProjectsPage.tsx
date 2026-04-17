import MOCK_PROJECTS from "./MockProjects";
import ProjectList from "./ProjectList";
import Project from "./Project";
import { useState } from "react";

function ProjectsPage() {

  const [projects, setProjects] = useState<Project[]>(MOCK_PROJECTS);

  const handleSaveProject = (project: Project) => {
    //console.log("Saving project:", project);
    // Here you would typically send the project data to a backend API to save it
    const updatedProjects: Project[] = projects.map((p) => p.id === project.id ? project : p);
    setProjects(updatedProjects);
  }

  return (
    <>
      <h1>Projects Page</h1>
      <hr/>
      {/* <pre>{JSON.stringify(MOCK_PROJECTS, null, 2)}</pre> */}
      {/* <ProjectList projects={MOCK_PROJECTS} /> */}
      {/* <ProjectList projects={MOCK_PROJECTS} onSave={handleSaveProject} /> */}
      <ProjectList projects={projects} onSave={handleSaveProject} />
    </>
  )
}

export default ProjectsPage;