import { Col } from "antd";

export function FilmeComponent(filme)
{
    const style = { padding: '8px 0' };

    return (
        <Col className="gutter-row" span={6}>
            <div key={filme.id} style={style}>{filme.titulo}</div>
        </Col>
    )
}