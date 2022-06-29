import { NavigationButton } from "../components/NavigationButton";
import Axios from "axios";
import { useState } from "react";
import React from "react";
import { Divider, Row } from 'antd';
import { LocacaoComponent } from "../components/LocacaoComponent";
import { ClienteComponent } from "../components/ClienteComponent";
import { FilmeComponent } from "../components/FilmeComponent";

export function Locacao()
{
    const [locacaoes, setLocacoes] = useState([]);
    const [clientes, setClientes] = useState([]);
    const [filmes, setFilmes] = useState([]);

    const fetchLocacaoes = async () => {
        const { data } = await Axios.get(
        "https://localhost:7266/v1/locacoes"
        );
        const locacaoes = data.data;
        setLocacoes(locacaoes);
        console.log(locacaoes);
    };

    const fetchClientesComAtraso = async () =>{
        const {data} = await Axios.get(
            "https://localhost:7266/v1/locacoes/clientes-locacoes-atrasadas"
        );
        const clientes = data.data;
        setClientes(clientes);
        console.log(clientes);
    };

    const fetchFilmesSemLocacao = async () =>{
        const {data} = await Axios.get(
            "https://localhost:7266/v1/locacoes/sem-locacao"
        );
        const filmes = data.data;
        setFilmes(filmes);
        console.log(filmes);
    };

    const fetchTop5FilmesAno = async () =>{
        const {data} = await Axios.get(
            "https://localhost:7266/v1/locacoes/top5-filmes-ano"
        );
        const filmes = data.data;
        setFilmes(filmes);
        console.log(filmes);
    };

    const fetchBottom3FilmesAno = async () =>{
        const {data} = await Axios.get(
            "https://localhost:7266/v1/locacoes/bottom3-filmes-semana"
        );
        const filmes = data.data;
        setFilmes(filmes);
        console.log(filmes);
    };

    const fetchSegundoMelhorCliente = async () =>{
        const {data} = await Axios.get(
            "https://localhost:7266/v1/locacoes/segundo-melhor-cliente"
        );
        const cliente = data.data;
        setClientes([cliente]);
        console.log(cliente);        
    };

    return (       
        <div>            
            <Divider orientation="right"></Divider>
            <Row gutter={[16, 24]}>
                {locacaoes.map((locacao) => (
                    LocacaoComponent(locacao)
                ))}

                {clientes.map((cliente) => (
                    ClienteComponent(cliente)
                ))}

                {filmes.map((filme) => (
                    FilmeComponent(filme)
                ))}

            </Row>

            <div style ={{visibility: ( locacaoes.length == 0 && clientes.length == 0 && filmes.length == 0 ) ? 'visible' : 'hidden', display: 'flex',  justifyContent:'center', alignItems:'center', height: ( locacaoes.length == 0 && clientes.length == 0 && filmes.length == 0 ) ? '90vh' : '1vh'}}>
                {NavigationButton(fetchLocacaoes,"Pesquisar todos")}
                {NavigationButton(fetchLocacaoes,"Pesquisar por ID")}
                {NavigationButton(fetchLocacaoes,"Cadastrar")}
                {NavigationButton(fetchLocacaoes,"Atualizar")}
                {NavigationButton(fetchClientesComAtraso,"Clientes com atraso")}
                {NavigationButton(fetchFilmesSemLocacao,"Filmes sem locação")}
                {NavigationButton(fetchTop5FilmesAno,"Top 5 filmes do ano")}
                {NavigationButton(fetchBottom3FilmesAno,"Bottom 3 filmes do ano")}
                {NavigationButton(fetchSegundoMelhorCliente,"2º melhor cliente")}
            </div>
        </div>       
    );
}