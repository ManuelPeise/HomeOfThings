import React from 'react';
import { IUserData } from '../lib/interfaces/auth/IUserData';
import { ISideMenuConfiguration } from '../lib/interfaces/menu/ISideMenuItem';
import { UserRoleEnum } from '../lib/enums/UserRoleEnum';
import { useI18n } from './useI18n';
import { getSideMenuConfiguration } from '../lib/sideMenuConfiguration';

export const useSideMenu = (
  userData: IUserData | null,
  userRoles: UserRoleEnum[]
) => {
  const userDataRef = React.useRef<IUserData | null>(null);

  const { getResource } = useI18n();

  React.useEffect(() => {
    if (userData !== undefined) {
      userDataRef.current = userData;
    }
  }, [userData]);

  const menuItems = React.useMemo((): ISideMenuConfiguration => {
    return getSideMenuConfiguration(getResource);
  }, [getResource]);

  return {
    sideMenu: menuItems,
  };
};
