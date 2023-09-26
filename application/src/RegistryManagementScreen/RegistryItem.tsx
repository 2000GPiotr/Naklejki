import { useState } from "react";
import { RegistryItemType } from "./RegistryTypes"
import './Styles/RegistryManagementScreen.css';
type PropsType = {
    registryItem: RegistryItemType;
}

const RegistryItem = (props: PropsType) => {
    const {registryItem} = props;

    const[showDetails, setShowDetails] = useState<boolean>(false);

    const toogleDetailsShow = () => setShowDetails(!showDetails);

    const itemDetails = (
        <div>
            <div>{registryItem.user.name + ' ' + registryItem.user.surname}</div>
            <div>{registryItem.labelStatus.symbol}</div>
            <div>{new Date(registryItem.labelEndTime).toISOString().split("T")[0]}</div>
        </div>
    );

    return(
        <div onClick={toogleDetailsShow} className="registryItemCard">
            <h3>
                {
                registryItem.labelTypeSymbol + " " + 
                registryItem.labelNumberPrefix + " " + 
                registryItem.labelNumber + " " + 
                registryItem.labelNumberSufix
                }
            </h3>
            <div>
                {showDetails ? itemDetails : null}
            </div>
            <button onClick={toogleDetailsShow}>Details</button>
        </div>
    );
}

export default RegistryItem;