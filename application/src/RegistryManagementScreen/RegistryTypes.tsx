import { UserBaseType } from "../UserManagementScreen/UserTypes";

export type RegistryItemType = {
    labelTypeSymbol: string;
    labelNumberPrefix: string;
    labelNumber: string;
    labelNumberSufix: string;
    labelEndTime: Date;
    user: UserBaseType;
    labelStatus: LabelStatusType;
}

export type LabelStatusType = {
    symbol: string;
    description: string;
}