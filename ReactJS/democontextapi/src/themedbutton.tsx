import { ThemeContext, TitleContext } from './App';
import { useContext } from 'react';


function ThemedButton(){
    //console.log(ThemeContext);
     const {background, foreground} = useContext(ThemeContext);
     const {title} = useContext(TitleContext);
   
    return (
        <button style={{backgroundColor: background, color: foreground}}>
            {title}
        </button>
    );
}

export default ThemedButton;