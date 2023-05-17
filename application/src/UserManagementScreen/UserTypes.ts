const roles = ['admin', 'user', 'magasinier'] ;
export type RoleType = typeof roles[number];

export type UserType = {
    Id: number;
    Name: string;
    Surname: string;
    Roles: RoleType[];
    ShowDetails: Boolean;
}