export type RoleType = {
    id: number;
    nazwa: string;
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

export type CreateUserType = {
    login: string;
    name: string;
    surname: string;
    password: string;
    rolesId: number[];
}

export type UpdateUserType = {
    id: number;
    login: string;
    name: string;
    surname: string;
    password: string;
    rolesId: number[];
}