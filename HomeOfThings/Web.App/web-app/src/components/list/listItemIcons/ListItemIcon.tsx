import React from "react";
import { StyledListItemIcon } from "../../styledComponents";
import { ColorTypeEnum } from "../../../lib/enums/ColorTypeEnum";

interface IProps {
  icon: JSX.Element;
  iconColor: ColorTypeEnum;
}

const ListItemIcon: React.FC<IProps> = (props) => {
  const { icon, iconColor } = props;

  return (
    <StyledListItemIcon style={{ color: iconColor }}>{icon}</StyledListItemIcon>
  );
};

export default ListItemIcon;
