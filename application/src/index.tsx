import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
// import App from './App';
import reportWebVitals from './reportWebVitals';
// import ToDoList from './ToDo/ToDoList';
import { RoleProvider } from './UserManagementScreen/RoleContext';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { LabelTypeProvider } from './LabelManagementScreen/Contexts/LabelTypeContext';
import { UserProvider } from './LabelManagementScreen/Contexts/UserContext';
import { DocumentTypeProvider } from './LabelManagementScreen/Contexts/DocumentTypeContext';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
    <React.StrictMode>
      <RoleProvider>
        <LabelTypeProvider>
          <DocumentTypeProvider>
            <UserProvider>
              <BrowserRouter>
                <App/>
              </BrowserRouter>
            </UserProvider>
          </DocumentTypeProvider>
        </LabelTypeProvider>
      </RoleProvider>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
