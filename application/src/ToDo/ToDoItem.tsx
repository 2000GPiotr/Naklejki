import React from "react"
import {ToDoItemType} from './ToDoTypes'

type PropsType = {
    elem: ToDoItemType;
    markCompleted: (id: string) => void;
  };

const ToDoItem = (props: PropsType) => {
    const markCompleted = () => props.markCompleted(props.elem.id)

    return(
        <div className={`card ${props.elem.isCompleted ? "completed" : ""}`} key={props.elem.id}>
            <h2>{props.elem.title}</h2>
            <button onClick={markCompleted}>Zakończone</button>
        </div>
    ) 
}

export default ToDoItem