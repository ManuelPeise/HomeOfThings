import {
  IUserData,
  IUserRegistration,
} from '../../../../lib/interfaces/auth/IUserData';

export interface IFamily {
  familyId: number;
  name: string;
  familyGuid: string;
  isActive: boolean;
  users: IUserData[];
  createdAt: string;
  createdBy: string;
}

export interface IFamilyRegistration {
  familyId: number;
  name: string;
  familyGuid: string;
  isActive: boolean;
  userRegistrationModel: IUserRegistration;
  createdAt: string;
  createdBy: string;
}
