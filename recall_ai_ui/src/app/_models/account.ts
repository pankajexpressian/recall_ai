import { Role } from './role';

export class Account {
    id: number = 0;
    userId = 0;
    title?: string;
    firstName?: string;
    lastName?: string;
    email?: string;
    role?: Role;
    jwtToken?: string;
}