import Project from "./models/Project";
import { Link } from "react-router-dom";

function formatDescription(description: string): string {
    const maxLength = 90; // Maximum number of characters to display
    return description.length > maxLength ? description.substring(0, maxLength) + '...' : description;
}

interface ProjectCardProps {
    project: Project;
    onEdit: (project: Project) => void;
}

//function ProjectCard({ project }: ProjectCardProps) {
function ProjectCard({ project, onEdit }: ProjectCardProps) {
    
    const handleEditClick = (projectBeingEdited: Project) => {
        // console.log("Edit button clicked for project:", projectBeingEdited);
        onEdit(projectBeingEdited); //Child-Parent communication: Pass the project being edited back to the parent component.
    };

    return(
        <>
            <div className="card">
                <img src={project.imageUrl} alt={project.name} className="card-img-top" />
                <section className="section dark">
                    <Link to={`/projects/${project.id}`}>
                        <h5 className="strong">
                        <strong>{project.name}</strong>
                        </h5>
                        {/* <p>{project.description}</p> */}
                        <p>{formatDescription(project.description)}</p>
                        <p>Budget: {project.budget.toLocaleString()}</p>
                    </Link>
                    <button className="bordered" onClick={() => handleEditClick(project)}>
                        <span className="icon-edit"></span>
                        Edit
                    </button>
                </section>
            </div>
        </>
    );
}

export default ProjectCard;