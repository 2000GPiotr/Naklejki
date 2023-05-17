import React, { useState } from 'react';
import './ToDoList.css';
import ToDoItem from './ToDoItem';
import {ToDoItemType} from './ToDoTypes'
  

const ToDoList = () => {
  const [elements, setElements] = useState<ToDoItemType[]>([
    { id: '1', isCompleted: false, title: 'Z1' },
    { id: '2', isCompleted: false, title: 'Z2' },
    { id: '3', isCompleted: true, title: 'Z3' },
    { id: '4', isCompleted: false, title: 'Z4' },
    { id: '5', isCompleted: false, title: 'Z5' }
  ]);
  const [inputValue, setInputValue] = useState('');

  const markCompleted = (id: string) => {
    const index = elements.findIndex(x => x.id === id);
    const newElements = [...elements];
    newElements[index] = {
      ...newElements[index],
      isCompleted: true,
    };
    setElements(newElements);
  };
  
  function addItem() {
    const newItem = {
      id: Math.random().toString(),
      isCompleted: false,
      title: inputValue
    };
    const newElements = [newItem, ...elements];
    setElements(newElements);
    setInputValue('');
  }

  function inputHandler(event: React.ChangeEvent<HTMLInputElement>) {
    const newValue = event.target.value;
    setInputValue(newValue);
  }

  const elem = elements.map(e => (
    <ToDoItem key={e.id} elem={e} markCompleted={markCompleted} />
  ));

  return (
    <div>
      <h1>TODO</h1>
      <input type='text' value={inputValue} onChange={inputHandler} />
      <button onClick={addItem}>Dodaj do listy</button>
      {elem}
    </div>
  );
}

export default ToDoList;
