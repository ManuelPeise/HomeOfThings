import { ColorTypeEnum } from '../../enums/ColorTypeEnum';
import { FontSizeEnum } from '../../enums/FontSizeEnum';
import { UserRoleEnum } from '../../enums/UserRoleEnum';

export interface ISideMenuConfiguration {
  title: string;
  subTitle: string;
  menuItems: ISideMenuItem[];
}

export interface ISideMenuItemBase {
  key: number;
  textSize: FontSizeEnum;
  textColor: ColorTypeEnum;
  resourceKey: string;
  textAccessor: (key: string) => string;
}

export interface ISideMenuItem extends ISideMenuItemBase {
  key: number;
  icon: JSX.Element;
  iconColor: ColorTypeEnum;
  sumItems: ISideMenuSubItem[];
}

export interface ISideMenuSubItem extends ISideMenuItemBase {
  disabled: boolean;
  to: string;
}
