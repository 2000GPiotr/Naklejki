import React from 'react';
import logo from './logo.svg';
import './App.css';
import { Routes, Route } from 'react-router-dom';
import Navbar from './Navbar';
import MainScreen from './MainScreen';
import UserList from './UserManagementScreen/UserList';
import StickList from './StickManagementScreen/StickScreen';
import RaportScreen from './RaportsScreen/RaportScreen';
import LoginForm from './LoginScreen';
import LoginScreen from './LoginScreen';

function App() {
  return (
    <div>
      <Navbar />

      <Routes>
        <Route path="/" Component={MainScreen} />
        <Route path="/UserManagementScreen" Component={UserList} />
        <Route path="/StickManagementScreen" Component={StickList} />
        <Route path="/RaportsScreen" Component={RaportScreen} />
        <Route path="/LoginScreen" Component={LoginScreen} />
      </Routes>
    </div>
  );
}

export default App;
