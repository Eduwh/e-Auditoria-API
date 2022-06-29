import
{
    BrowserRouter as Router,
    Routes,
    Route    
}from "react-router-dom";


import { Cliente } from "./Pages/Cliente";
import { Filme } from "./Pages/Filme";
import { Home } from "./Pages/Home";
import { Locacao } from "./Pages/Locacao";

export function AppRoutes(){
    return(
        <Router>
            <Routes>
                <Route path='/' element={<Home/>}/>
                <Route path='/filme' element={<Filme/>}/>
                <Route path='/cliente' element={<Cliente/>}/>
                <Route path='/locacao' element={<Locacao/>}/>
            </Routes>
        </Router>
    )
}