import Project from "./Project";
import ProjectCard from "./ProjectCard";
import ProjectForm from "./ProjectForm";
import { useState } from "react"; //importing useState hook from React

interface ProjectListProps {
    projects: Project[];
    onSave: (project: Project) => void;
}

//function ProjectList({ projects }: ProjectListProps ) {
function ProjectList({ projects, onSave }: ProjectListProps ) {

    const [projectBeingEdited, setProjectBeingEdited] = useState<Project | null>(null);

    const handleEdit = (project: Project) => {
        //console.log("Edit button clicked for project:", project);
        setProjectBeingEdited(project);
    };

    const cancelEditing = () => {
        setProjectBeingEdited(null);
    };

    return (
        <>
            {/* <pre>{JSON.stringify(projects, null, 2)}</pre> */}
            {/* <ul className="row">
                {
                    projects.map(project => (
                        <li key={project.id}>
                            {project.name}
                        </li>
                    ))
                }
            </ul> */}
            <div className="row">
                {
                    projects.map(project => (
                        <div key={project.id} className="cols-sm">
                            {/* <div className="card">
                                <img src={project.imageUrl} alt={project.name} className="card-img-top" />
                                <section className="section dark">
                                    <h5 className="strong">
                                        <strong>{project.name}</strong>
                                    </h5>
                                    <p>{project.description}</p>
                                    <p>Budget: {project.budget.toLocaleString()}</p>
                                </section>
                            </div> */}
                            {/* <ProjectCard project={project} /> */}
                            {/* <ProjectCard project={project} onEdit={handleEdit} />
                            <ProjectForm /> */}
                            {
                                project === projectBeingEdited
                                    // ? <ProjectForm />
                                    // ? <ProjectForm onCancel={cancelEditing} />
                                    ? <ProjectForm onCancel={cancelEditing} onSave={onSave} 
                                        project={project} />
                                    : <ProjectCard project={project} onEdit={handleEdit} />
                            }
                        </div>
                    ))
                }
            </div>
        </>
    );
};

export default ProjectList;