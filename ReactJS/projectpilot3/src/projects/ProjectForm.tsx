import Project from "./models/Project";
import {type SyntheticEvent, useState } from "react";
import {useDispatch} from "react-redux";
import {saveProject} from "./state/projectActions";
import {type ThunkDispatch} from "redux-thunk";
import {type ProjectState} from "./state/projectTypes";
import {type AnyAction} from "redux";

interface ProjectFormProps {
    project: Project;
    //onSave: (project: Project) => void;
    onCancel: () => void;
}

//function ProjectForm() {
// function ProjectForm({onCancel}: ProjectFormProps) {
//function ProjectForm({onSave, onCancel}: ProjectFormProps) {
function ProjectForm({project: initialProject, onCancel}: ProjectFormProps) {

    const [project, setProject] = useState(initialProject);
    const [errors, setErrors] = useState({ name: '', description: '', budget: '' });

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const dispatch = useDispatch<ThunkDispatch<ProjectState, any, AnyAction>>();

    function validate(project: Project) {
        const errors = { name: '', description: '', budget: '' };
        if(project.name.trim().length === 0) {
            errors.name = "Project name is required.";
        }
        if(project.name.trim().length > 0 && project.name.trim().length < 3) {
            errors.name = "Project name must be at least 3 characters.";
        }
        if(project.description.trim().length === 0) {
            errors.description = "Project description is required.";
        }
        if(project.budget <= 0) {
            errors.budget = "Project budget must be more than 0.";
        }
        return errors;
    }

    function isValid(): boolean{
        return(
            errors.name.length === 0 
            && errors.description.length === 0 
            && errors.budget.length === 0
        );
    }

    const handleSubmit = (event: SyntheticEvent) => {
        event.preventDefault();
        
        // onSave(new Project({
        //     name: "New Project", 
        //     description: "Project Description", 
        //     budget: 1000, 
        //     isActive: true
        // }));

        // onSave(project);
        if(!isValid()) return;
        //onSave(project);
        dispatch(saveProject(project));
    };

    // eslint-disable-next-line @typescript-eslint/no-explicit-any
    const handleChange = (event: any) => {
        const { type, name, value, checked } = event.target;
        //If input type is checkbox, use checked value, otherwise use value
        let updatedValue = type === "checkbox" ? checked : value;

        //If input type is number, convert value to number
        if (type === "number") {
            updatedValue = Number(updatedValue);
        }

        const change= {
            [name]: updatedValue
        };

        let updatedProject: Project;
        //Need to do functional update to ensure we have the latest state value based previous 
        // project state

        setProject((prevProject) => {
            updatedProject = new Project({
                ...prevProject,
                ...change
            });
            return updatedProject;
        });
        setErrors(() => validate(updatedProject));
    };

    return(
        <>
            {/* <form className="input-group vertical"> */}
            <form className="input-group vertical" onSubmit={handleSubmit}>
                <label htmlFor="name">Project Name</label>
                <input type="text" id="name" name="name" placeholder="Enter Project Name"
                    value = {project.name} onChange={handleChange} />
                {
                    errors.name.length > 0 && (
                        <div className="card error">
                            <p>{errors.name}</p>
                        </div>
                    )
                }
                <label htmlFor="description">Project Description</label>
                <textarea id="description" name="description" placeholder="Enter Project Description"
                    value = {project.description} onChange={handleChange}></textarea>
                {
                    errors.description.length > 0 && (
                        <div className="card error">
                            <p>{errors.description}</p>
                        </div>
                    )
                }
                <label htmlFor="budget">Project Budget</label>
                <input type="number" id="budget" name="budget" placeholder="Enter Project Budget"
                    value = {project.budget} onChange={handleChange} />
                {
                    errors.budget.length > 0 && (
                        <div className="card error">
                            <p>{errors.budget}</p>
                        </div>
                    )
                }
                <label htmlFor="isActive">Is Project Active?</label>
                <input type="checkbox" id="isActive" name="isActive" 
                    checked={project.isActive} onChange={handleChange} />
                <div className="input-group">
                    <button type="submit" className="primary bordered medium" disabled={!isValid()}>
                        Save Project
                    </button>
                    <span />
                    {/* <button type="button" className="bordered medium">Cancel</button> */}
                    <button type="button" className="bordered medium" onClick={onCancel}>Cancel</button>
                </div>

            </form>
        </>
    );
}

export default ProjectForm;