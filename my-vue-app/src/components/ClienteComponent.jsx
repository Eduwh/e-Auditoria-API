import { Col } from "antd";

export function ClienteComponent(cliente)
{
    const style = { padding: '8px 0' };

    return (
        <Col className="gutter-row" span={6}>
            <div key={cliente.id} style={style}>{cliente.nome}</div>
        </Col>
    )
}