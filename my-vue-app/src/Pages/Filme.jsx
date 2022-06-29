import { NavigationButton } from "../components/NavigationButton";
import Axios from "axios";
import { useState } from "react";
import React from "react";
import { Divider, Row } from 'antd';
import { FilmeComponent } from "../components/FilmeComponent";

export function Filme()
{    
    const [filmes, setFilmes] = useState([]);
    const fetchFilmes = async () => {
        const { data } = await Axios.get(
        "https://localhost:7266/v1/filmes"
        );
        const filmes = data.data;
        setFilmes(filmes);
        console.log(filmes);
    };

    return (       
        <div>            
            <Divider orientation="right"></Divider>
            <Row gutter={[16, 24]}>
                {filmes.map((filme) => (
                    FilmeComponent(filme)
                ))}
            </Row>

            <div style ={{visibility: filmes.length == 0 ? 'visible' : 'hidden', display: 'flex',  justifyContent:'center', alignItems:'center', height: filmes.length == 0 ? '90vh' : '1vh'}}>
                {NavigationButton(fetchFilmes,"Pesquisar todos")}
                {NavigationButton(fetchFilmes,"Pesquisar por ID")}
                {NavigationButton(fetchFilmes,"Cadastrar")}
                {NavigationButton(fetchFilmes,"Atualizar")}
                {NavigationButton(fetchFilmes,"Deletar")}
            </div>
        </div>       
    );
}