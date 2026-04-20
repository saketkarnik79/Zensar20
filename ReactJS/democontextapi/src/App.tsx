import './App.css';
import { useState, createContext } from 'react';
import Toolbar from './toolbar';

const themes = {
  light: {
    background: '#ffffff',
    foreground: '#000000'
  },
  dark: {
    background: '#242424',
    foreground: '#ffffff'
  }
};
const title = {title: 'Context API Example'};

const ThemeContext = createContext(themes.light);
const TitleContext = createContext(title);

function App() {

  const [themeName, setThemeName] = useState('light');
  const currentTheme = themes[themeName as 'light' | 'dark'];
  //console.log('App: ',  currentTheme);
  
  return (
    <>
      <select name='theme' title='Theme' value={themeName} 
        onChange={(event) => setThemeName(event.target.value as 'light' | 'dark')}>
        <option value="light">Light</option>
        <option value="dark">Dark</option>
      </select>
      <ThemeContext.Provider value={currentTheme}>
        <TitleContext.Provider value={title}>
          <Toolbar />
        </TitleContext.Provider>
      </ThemeContext.Provider>
      {/* <TitleContext.Provider value={title}>
        <Toolbar/>
      </TitleContext.Provider> */}
    </>
  )
}

export default App;
export { ThemeContext };
export { TitleContext };