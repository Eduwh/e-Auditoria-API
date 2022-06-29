import { useNavigate } from "react-router-dom";
import { NavigationButton } from "../components/NavigationButton";
import Axios from "axios";
import { useState } from "react";
import React from "react";
import { Divider, Row } from 'antd';
import { ClienteComponent } from "../components/ClienteComponent";

export function Cliente()
{
    const style = { background: '#0092ff', padding: '8px 0' };
    const [clientes, setClientes] = useState([]);

    const fetchClientes = async () => {
        const { data } = await Axios.get(
        "https://localhost:7266/v1/clientes"
        );
        const clientes = data.data;
        setClientes(clientes);
        console.log(    clientes);
    };

    return (    
        <div>            
            <Divider orientation="right"></Divider>
            <Row gutter={[16, 24]}>
                {clientes.map((cliente) => (
                    ClienteComponent(cliente)
                ))}
            </Row>

            <div style ={{visibility: clientes.length == 0 ? 'visible' : 'hidden', display: 'flex',  justifyContent:'center', alignItems:'center', height: clientes.length == 0 ? '90vh' : '1vh'}}>
                {NavigationButton(fetchClientes,"Pesquisar todos")}
                {NavigationButton(fetchClientes,"Pesquisar por ID")}
                {NavigationButton(fetchClientes,"Cadastrar")}
                {NavigationButton(fetchClientes,"Atualizar")}
                {NavigationButton(fetchClientes,"Deletar")}
            </div>
        </div>    
    );
}