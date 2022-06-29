import { Col } from "antd";
import Moment from 'moment';

export function LocacaoComponent(locacao)
{
    const style = { padding: '8px 0' };

    return (
        <Col className="gutter-row" span={6}>
            <div key={locacao.id} style={style}>Data de Locacação: {Moment( locacao.dataLocacao ).format('DD-MM-yyyy')} - Data de Devolução: {Moment( locacao.dataDevolucao ).format('DD-MM-yyyy')} - {locacao.cliente.nome} - {locacao.filme.titulo}</div>
        </Col>
    )
}