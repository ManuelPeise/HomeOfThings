import React from "react";
import { IUserData } from "../lib/interfaces/auth/IUserData";
import { ISideMenuItem } from "../lib/interfaces/menu/ISideMenuItem";
import { FontSizeEnum } from "../lib/enums/FontSizeEnum";
import {
  GamepadRounded,
  MoneyRounded,
  AccountCircle,
} from "@mui/icons-material";
import { ColorTypeEnum } from "../lib/enums/ColorTypeEnum";
import { RouteTypeEnum } from "../lib/enums/RouteTypeEnum";

export const useSideMenu = (userData: IUserData | null) => {
  const userDataRef = React.useRef<IUserData | null>(null);

  React.useEffect(() => {
    if (userData !== undefined) {
      userDataRef.current = userData;
    }
  }, [userData]);

  const items = React.useMemo((): ISideMenuItem[] => {
    return [
      {
        key: 0,
        sortOrder: 0,
        title: "Spiele",
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <GamepadRounded />,
        iconColor: ColorTypeEnum.LightGray,
        disabled: userDataRef.current == null,
        sumItems: [
          {
            title: "Playground",
            textSize: FontSizeEnum.SM,
            to: RouteTypeEnum.PlayGround,
          },
          { title: "Tic Tac Toe", textSize: FontSizeEnum.SM, to: "" },
        ],
      },
      {
        key: 2,
        sortOrder: 2,
        title: "Finanzen",
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <MoneyRounded />,
        iconColor: ColorTypeEnum.LightGray,
        disabled: userDataRef.current == null,
        sumItems: [
          { title: "Planung", textSize: FontSizeEnum.SM, to: "" },
          { title: "Vergleich", textSize: FontSizeEnum.SM, to: "" },
        ],
      },
      {
        key: 1,
        sortOrder: 1,
        title: "Account",
        textSize: FontSizeEnum.MD,
        textColor: ColorTypeEnum.White,
        icon: <AccountCircle />,
        iconColor: ColorTypeEnum.LightGray,
        disabled: userDataRef.current == null,
        sumItems: [
          {
            title: "Übersicht",
            textSize: FontSizeEnum.SM,
            to: RouteTypeEnum.Account,
          },
        ],
      },
    ];
  }, []);

  return {
    menuItems: items,
  };
};
