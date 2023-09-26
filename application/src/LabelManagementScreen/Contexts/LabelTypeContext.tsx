import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../../Helpers";
import{ LabelTypeBase} from "../DocumentTypes"

export const LabelTypeContext = createContext<LabelTypeBase[]>([]);

export const LabelTypeProvider = ({ children }: {children: ReactNode;}) => {
  const [labelTypes, setLabelTypes] = useState<LabelTypeBase[]>([]);

  const fetchLabelTypes = (signal: AbortSignal) => {
    const url = "http://localhost:5021/LabelType";
    return fetchData(url, signal);
  };

  useEffect(() => {

    const controller = new AbortController();
    const signal = controller.signal;

    fetchLabelTypes(signal)
      .then((data) => setLabelTypes(data))
      .catch((error) => console.error("Error fetching roles:", error));
      return () => {controller.abort()};
  }, []);

  return (
    <LabelTypeContext.Provider value={labelTypes}>
      {children}
    </LabelTypeContext.Provider>
  );
};
