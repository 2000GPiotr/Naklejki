export type RoleType = {
    id: number;
    name: string;
    description: string;
}

export type UserType = {
    id: number;
    login: string;
    name: string;
    surname: string;
    roles: RoleType[];
    ShowDetails: Boolean;
}

export type UserBaseType = Omit<Partial<UserType>,
'roles' | 'ShowDetails' | 'login'>

export type CreateUserType = Omit<Partial<UserType>,
'id' | 'ShowDetails' | 'roles'> 
& {
    password: string;
    rolesId: number[];
};


export type UpdateUserType = Omit<Partial<UserType>,
'ShowDetails' | 'roles'> 
& {
    password: string;
    rolesId: number[];
};
