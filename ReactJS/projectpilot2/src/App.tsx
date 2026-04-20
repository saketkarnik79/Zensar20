import './App.css'
import ProjectsPage from './projects/ProjectsPage';
import HomePage from './home/HomePage';
import {BrowserRouter, Routes, Route, NavLink} from 'react-router-dom';
import ProjectPage from './projects/ProjectPage';

function App() {

  return (
    <>
      {/* <h1>Ready To React!</h1> */}
      {/* <blockquote cite="Benjamin Franklin">
        Tell me and I forget. Teach me and I remember. Involve me and I learn.
      </blockquote> */}
      {/* <div className='container'>
        <ProjectsPage />
      </div> */}
      <BrowserRouter>
        <header className='sticky'>
          <span className='logo'>
            <img src='assets/logo-3.svg' alt="Logo"  width='49' height='99'/>
          </span>
          <NavLink to='/' className='button rounded'>
            <span className='icon-home'></span>
            Home
          </NavLink>
          <NavLink to='/projects' className='button rounded'>
            <span className='icon-briefcase'></span>
            Projects
          </NavLink>
        </header>
        <div className='container'>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/projects" element={<ProjectsPage />} />
            <Route path="/projects/:id" element={<ProjectPage />} />
          </Routes>
        </div>
      </BrowserRouter>
    </>
  )
}

export default App;
