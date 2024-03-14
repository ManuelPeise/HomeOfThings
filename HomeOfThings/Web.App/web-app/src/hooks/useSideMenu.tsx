import React from 'react';
import { IUserData } from '../lib/interfaces/auth/IUserData';
import { ISideMenuItem } from '../lib/interfaces/menu/ISideMenuItem';
import { FontSizeEnum } from '../lib/enums/FontSizeEnum';
import { ColorTypeEnum } from '../lib/enums/ColorTypeEnum';
import { RouteTypeEnum } from '../lib/enums/RouteTypeEnum';
import { AdminPanelSettings, Home } from '@mui/icons-material';
import { UserRoleEnum } from '../lib/enums/UserRoleEnum';

export const useSideMenu = (
  userData: IUserData | null,
  userRoles: UserRoleEnum[]
) => {
  const userDataRef = React.useRef<IUserData | null>(null);

  React.useEffect(() => {
    if (userData !== undefined) {
      userDataRef.current = userData;
    }
  }, [userData]);

  const getSystemAdminMenuItems = React.useCallback((): ISideMenuItem[] => {
    return [
      {
        key: 2,
        sortOrder: 2,
        title: 'System Administration',
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <AdminPanelSettings />,
        iconColor: ColorTypeEnum.LightGray,
        disabled: userDataRef.current == null,
        sumItems: [
          {
            title: 'Family Administration',
            textSize: FontSizeEnum.SM,
            to: RouteTypeEnum.FamilyAdministration,
          },
        ],
      },
    ];
  }, []);

  const items = React.useMemo((): ISideMenuItem[] => {
    return [
      {
        key: 1,
        sortOrder: 1,
        title: 'Home',
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <Home />,
        iconColor: ColorTypeEnum.LightGray,
        disabled: userDataRef.current == null,
        sumItems: [
          {
            title: 'Home',
            textSize: FontSizeEnum.SM,
            to: RouteTypeEnum.Home,
          },
        ],
      },
      ...getSystemAdminMenuItems(),
    ];
  }, [getSystemAdminMenuItems]);

  return {
    menuItems: items,
  };
};
