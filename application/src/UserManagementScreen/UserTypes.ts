export type RoleType = {
    Id: number;
    Nazwa: string;
    Description: string;
}

export type UserType = {
    Id: number;
    Login: string;
    Name: string;
    Surname: string;
    Roles: RoleType[];
    ShowDetails: Boolean;
}

export type CreateUserType = {
    Login: string;
    Name: string;
    Surname: string;
    Password: string;
    Roles: RoleType[];
}

export type UpdateUserType = {
    Id: number;
    Login: string;
    Name: string;
    Surname: string;
    Password: string;
    Roles: RoleType[];
}