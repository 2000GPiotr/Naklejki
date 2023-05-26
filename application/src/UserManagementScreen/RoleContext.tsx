import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "./Helpers";
import { RoleType } from "./UserTypes";

export const RoleContext = createContext<RoleType[]>([]);


export const RoleProvider = ({ children }: {children: ReactNode;}) => {
  const [roles, setRoles] = useState([]);

  const fetchRoles = () => {
    const url = "http://localhost:5021/Role";
    return fetchData(url);
  };

  useEffect(() => {
    fetchRoles()
      .then((data) => setRoles(data))
      .catch((error) => console.error("Error fetching roles:", error));
  }, []);

  return (
    <RoleContext.Provider value={roles}>
      {children}
    </RoleContext.Provider>
  );
};
