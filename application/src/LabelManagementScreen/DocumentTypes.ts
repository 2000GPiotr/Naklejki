
export type DocumentType = {
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

export type ItemRangeType = {
    id: string;
    labelTypeSymbol: string; 
    firstItem: ItemType;
    lastItem: ItemType
}

export type AddDocumentType = {
    documentTypeSymbol: string;
    year: number;
    number: number;
    date: Date;
    description: string;
    userId: number | null;
    itemsList: ItemRangeType[];    
}