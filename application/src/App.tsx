import React from 'react';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Navbar from './Navbar';
import MainScreen from './MainScreen';
import UserList from './UserManagementScreen/UserList';
import LabelList from './LabelManagementScreen/LabelScreen';
import RaportScreen from './RaportsScreen/RaportScreen';
import LoginScreen from './LoginScreen';
import UserAdd from './UserManagementScreen/UserAdd';
import UserEdit from './UserManagementScreen/UserEdit';

function App() {
  return (
    <div>
      <Navbar />

      <Routes>
        <Route path="/" Component={MainScreen} />
        <Route path="/UserManagementScreen" Component={UserList} />
        <Route path="/UserManagementScreen/Add" Component={UserAdd} />
        <Route path="/UserManagementScreen/Edit" Component={UserEdit} />
        <Route path="/LabelManagementScreen" Component={LabelList} />
        <Route path="/RaportsScreen" Component={RaportScreen} />
        <Route path="/LoginScreen" Component={LoginScreen} />
      </Routes>
    </div>
  );
}

export default App;
