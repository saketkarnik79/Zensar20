import MOCK_PROJECTS from "./MockProjects";

function ProjectsPage() {
  return (
    <>
      <h1>Projects Page</h1>
      <hr/>
      <pre>{JSON.stringify(MOCK_PROJECTS, null, 2)}</pre>
    </>
  )
}

export default ProjectsPage;