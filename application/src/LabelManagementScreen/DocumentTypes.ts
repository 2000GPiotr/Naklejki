import { UserBaseType } from "../UserManagementScreen/UserTypes";

export type DocumentTypeType = {
    symbol: string;
    description: string;
}

export type LabelType = {
    symbol: string;
    description: string;
    count: number;
}

export type LabelTypeBase = Omit<Partial<LabelType>,
'count'>

export type ItemType = {
    labelNumberPrefix: string;
    labelNumber: string;
    labelNumberSufix: string;
}

export type ItemFullType = ItemType & {
    labelTypeSymbol: string;
  };

export type ItemRangeType = {
    id: string;
    labelTypeSymbol: string; 
    firstItem: ItemType;
    lastItem: ItemType
}

export type DocumentHeaderType = {
    id: number;
    documentType: DocumentTypeType;
    year: number;
    number: number;
    date: Date;
    description: string;
    user: UserBaseType | null;
    itemList: ItemFullType[];
}

export type AddDocumentType = Omit<Partial<DocumentHeaderType>,
    'id' | 'documentType' | 'user' | 'itemList'>
    &{
        documentTypeSymbol: string;
        userId: number | null;
        itemsList: ItemRangeType[];  
    };

export type UpdateDocumentType = Omit<Partial<DocumentHeaderType>,
    'user' | 'itemList'>
    &{
        userId: number | null;
        date: Date
    };
    