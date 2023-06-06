import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../Helpers";
import { RoleType } from "./UserTypes";

export const RoleContext = createContext<RoleType[]>([]);


export const RoleProvider = ({ children }: {children: ReactNode;}) => {
  const [roles, setRoles] = useState([]);

  const fetchRoles = (signal: AbortSignal) => {
    const url = "http://localhost:5021/Role";
    return fetchData(url, signal);
  };

  useEffect(() => {

    const controller = new AbortController();
    const signal = controller.signal;

    fetchRoles(signal)
      .then((data) => setRoles(data))
      .catch((error) => console.error("Error fetching roles:", error));
      return () => {controller.abort()};
  }, []);

  return (
    <RoleContext.Provider value={roles}>
      {children}
    </RoleContext.Provider>
  );
};
