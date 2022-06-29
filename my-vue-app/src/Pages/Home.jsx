import { useNavigate } from "react-router-dom";
import { NavigationButton } from "../components/NavigationButton";

export function Home()
{
    let navigate = useNavigate(); 
    const routeChangeCliente = () =>{ 
      let path = `cliente`; 
      navigate(path);
    }
    const routeChangeFilme = () =>{ 
      let path = `filme`; 
      navigate(path);
    }
    const routeChangeLocacao = () =>{ 
      let path = `locacao`; 
      navigate(path);
    }
  
    return (
        <div style ={{display: 'flex',  justifyContent:'center', alignItems:'center', height: '90vh'}}>            
            {NavigationButton(routeChangeCliente,"Cliente")}
            {NavigationButton(routeChangeFilme,"Filme")}
            {NavigationButton(routeChangeLocacao,"Locação")}
        </div>
    );
}