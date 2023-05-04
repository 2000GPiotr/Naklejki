import React from 'react';

class ReactComponent extends React.Component {
    state = {
        elements: [
            { id: '1', title: 'Z1' },
            { id: '2', title: 'Z2' },
            { id: '3', title: 'Z3' },        ]
    }

    render() {
        const elem = this.state.elements.map(e => { 
            return <div>{e.title}</div>
                })

        return (
            <div>
                TODO
                {elem}
            </div>)
    }
}

export default ReactComponent;