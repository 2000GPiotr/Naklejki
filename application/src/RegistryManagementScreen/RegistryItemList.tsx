import { useEffect, useState } from "react";
import { RegistryItemType } from "./RegistryTypes";
import { useNavigate } from "react-router-dom";
import { fetchData } from "../Helpers";
import RegistryItem from "./RegistryItem";

const RegistryItemList = () => {
    const [registry, setRegistry] = useState<RegistryItemType[]>([]);

    const navigate = useNavigate();

    useEffect(() => {
        const controller = new AbortController();
        
        var init = async () => 
        {
          const url = 'http://localhost:5021/Registry';
          console.log('RegistryList render');
  
          const signal = controller.signal;
  
          try {
            var data = await fetchData(url, signal);
            console.log(data);
            setRegistry(data);
          }
          catch (error) {
            console.error('Error fetching registry:', error);
          }
        }
        init();
        
        return () => {controller.abort()};
      }, []);

      const registryList = registry.map(i => (
        <RegistryItem registryItem={i} />
      ));

    return(
        <div>
            <h1>Registry</h1>
            {registryList}
        </div>

    );
}

export default RegistryItemList