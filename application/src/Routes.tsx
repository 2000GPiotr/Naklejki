import React from 'react';
import { Routes, Route } from 'react-router-dom';
import MainScreen from './MainScreen';
import UserList from './UserManagementScreen/UserList';
import RaportScreen from './RaportsScreen/RaportScreen';
import LoginScreen from './LoginScreen';
import UserAdd from './UserManagementScreen/UserAdd';
import UserEdit from './UserManagementScreen/UserEdit';
import DocumentList from './LabelManagementScreen/DocumentsList';
import DocumentAdd from './LabelManagementScreen/DocumentAdd';
import DocumentEdit from './LabelManagementScreen/DocumentEdit';
import RegistryItemList from './RegistryManagementScreen/RegistryItemList';

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<MainScreen />} />

      <Route path="/Users" element={<UserList />} />
      <Route path="/Users/Add" element={<UserAdd />} />
      <Route path="/Users/Edit" element={<UserEdit />} />

      <Route path="/Documents" element={<DocumentList />} />
      <Route path="/Documents/Add" element={<DocumentAdd/>}/>
      <Route path="/Documents/Edit" element={<DocumentEdit/>}/>

      <Route path="/RaportsScreen" element={<RaportScreen />} />
      <Route path="/LoginScreen" element={<LoginScreen />} />
      <Route path="/Test" element={<DocumentList />} />

      <Route path="/Registry" element={<RegistryItemList />} />
    </Routes>
  );
};

export default AppRoutes;