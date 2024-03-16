import { UserRoleEnum } from '../../enums/UserRoleEnum';

export interface IUserData {
  userId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date | null;
  email: string;
  userRoles: UserRoleEnum[];
  isActive: boolean;
}

export interface IUserRegistration {
  userId: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date | null;
  email: string;
  userRole: UserRoleEnum;
  isActive: boolean;
}
