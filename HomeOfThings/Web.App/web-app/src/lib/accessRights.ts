import { UserRoleEnum } from './enums/UserRoleEnum';

export const userIsInRole = (
  requiredAccessRight: UserRoleEnum,
  userRoles: UserRoleEnum[]
) => {
  return userRoles.findIndex((x) => x === requiredAccessRight) !== -1;
};
