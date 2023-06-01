import React, { useState } from 'react';
import { postData } from './Helpers';

const LoginScreen = () => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const data = {username:{username}, password: {password}};
    postData('http://localhost:5021/Login', data)
        .then(responseData => {
            console.log(responseData);
        })
        .catch(error => {
            console.log('Error:', error);
        })
  };

  return (
    <div>
        <h1>Login</h1>
        <form onSubmit={handleSubmit}>
          <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} />
          <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
          <button type="submit">Zaloguj się</button>
        </form>
    </div>
    
  );
};

export default LoginScreen;
