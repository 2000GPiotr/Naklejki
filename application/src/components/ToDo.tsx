import React from 'react';

class ToDo extends React.Component {
    state = {
        elements: [
            { id: '1', title: 'Z1' },
            { id: '2', title: 'Z2' },
            { id: '3', title: 'Z3' }
        ]
    }
    render() {
        const elements = this.state.elements.map(e => {
            return <div key={e.id}>{e.title}</div>
        })
        return (
            <div>
                ToDo App
                {elements}
            </div>
            )
    }
}

export default ToDo;