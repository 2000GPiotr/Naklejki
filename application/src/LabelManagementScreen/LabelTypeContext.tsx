import React, { ReactNode, createContext, useEffect, useState } from "react";
import { fetchData } from "../Helpers";
import{ LabelTypeBase} from "./DocumentTypes"

export const LabelTypeContext = createContext<LabelTypeBase[]>([]);

export const LabelTypeProvider = ({ children }: {children: ReactNode;}) => {
  const [labelTypes, setLabelTypes] = useState<LabelTypeBase[]>([]);

  useEffect(() => {
    setLabelTypes([{symbol:"S1", description: "Desc 1"}, {symbol:"S2", description: "Desc 2"}]);
  }, []);
  

  return (
    <LabelTypeContext.Provider value={labelTypes}>
      {children}
    </LabelTypeContext.Provider>
  );
};
