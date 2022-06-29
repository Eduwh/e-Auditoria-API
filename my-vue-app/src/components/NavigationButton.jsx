export function NavigationButton(method, text)
{
    return (
        <button 
            onClick={method}
            style={
                {
                    backgroundColor: '#8257e6',
                    border: 0,
                    padding: '12px 24px',
                    marginRight: 20,
                    color: '#FFF'
                }
            }
        >{text}</button>
    )
}