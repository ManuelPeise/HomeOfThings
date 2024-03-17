import React from 'react';
import { ColorTypeEnum } from './enums/ColorTypeEnum';
import { FontSizeEnum } from './enums/FontSizeEnum';
import { RouteTypeEnum } from './enums/RouteTypeEnum';
import { UserRoleEnum } from './enums/UserRoleEnum';
import { ISideMenuConfiguration } from './interfaces/menu/ISideMenuItem';
import { AdminPanelSettings } from '@mui/icons-material';

export const getSideMenuConfiguration = (
  resourceCallback: (key: string) => string,
  userRole?: UserRoleEnum
): ISideMenuConfiguration => {
  return {
    title: process.env.REACT_APP_TITLE ?? '',
    subTitle: process.env.REACT_APP_SUB_TITLE ?? '',
    menuItems: [
      {
        key: 1,
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <AdminPanelSettings />,
        iconColor: ColorTypeEnum.LightGray,
        resourceKey: 'common.labelAdministration',
        textAccessor: resourceCallback.bind('common.labelAdministration'),
        sumItems: [
          {
            key: 11,
            textSize: FontSizeEnum.SM,
            textColor: ColorTypeEnum.White,
            to: RouteTypeEnum.FamilyAdministration,
            disabled: false,
            // userRole === undefined || userRole !== UserRoleEnum.SystemAdmin,
            resourceKey: 'common.labelFamilyAdministration',
            textAccessor: resourceCallback,
          },
          {
            key: 12,
            textSize: FontSizeEnum.SM,
            textColor: ColorTypeEnum.White,
            to: RouteTypeEnum.LoggingPage,
            disabled: false,
            // userRole === undefined ||
            // (userRole !== UserRoleEnum.SystemAdmin &&
            //   userRole !== UserRoleEnum.Admin),
            resourceKey: 'common.labelLogging',
            textAccessor: resourceCallback,
          },
        ],
      },
    ],
  };
};
