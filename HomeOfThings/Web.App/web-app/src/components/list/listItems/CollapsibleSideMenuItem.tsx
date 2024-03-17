import React from 'react';
import {
  StyledDrawerListItem,
  StyledDrawerListItemButton,
  StyledDrawerSubListItemButton,
} from '../../styledComponents';
import ListItemIcon from '../listItemIcons/ListItemIcon';
import ListItemText from '../text/ListItemText';
import { ColorTypeEnum } from '../../../lib/enums/ColorTypeEnum';
import { FontSizeEnum } from '../../../lib/enums/FontSizeEnum';
import { List, ListItemIcon as Icon } from '@mui/material';
import { ISideMenuSubItem } from '../../../lib/interfaces/menu/ISideMenuItem';
import { useNavigate } from 'react-router-dom';

interface IProps {
  id: number;
  title: string;
  textSize: FontSizeEnum;
  textColor: ColorTypeEnum;
  icon: JSX.Element;
  iconColor: ColorTypeEnum;
  disabled?: boolean;
  isExpanded: boolean;
  subItems: ISideMenuSubItem[];
  onClick: (key: number) => void;
  onClose: (state: boolean) => void;
}

const CollapsibleSideMenuItem: React.FC<IProps> = (props) => {
  const {
    id,
    title,
    textSize,
    textColor,
    icon,
    iconColor,
    disabled,
    isExpanded,
    subItems,
    onClick,
    onClose,
  } = props;

  const navigate = useNavigate();

  const handleOnItemClick = React.useCallback(
    (to: string) => {
      navigate(to);
      onClose(false);
    },
    [navigate, onClose]
  );

  return (
    <>
      <StyledDrawerListItem style={{ padding: 0 }}>
        <StyledDrawerListItemButton
          disabled={disabled}
          selected={isExpanded}
          onClick={onClick.bind(null, id)}
        >
          <ListItemIcon icon={icon} iconColor={iconColor} />
          <ListItemText
            text={title}
            textColor={textColor}
            textSize={textSize}
          />
        </StyledDrawerListItemButton>
      </StyledDrawerListItem>
      {isExpanded && (
        <List disablePadding>
          {subItems.map((item, index) => {
            return (
              <StyledDrawerListItem key={index} style={{ padding: 0 }}>
                <StyledDrawerSubListItemButton
                  disabled={item.disabled}
                  onClick={handleOnItemClick.bind(null, item.to)}
                >
                  <Icon />
                  <ListItemText
                    text={item.textAccessor(item.resourceKey)}
                    textColor={textColor}
                    textSize={item.textSize}
                  />
                </StyledDrawerSubListItemButton>
              </StyledDrawerListItem>
            );
          })}
        </List>
      )}
    </>
  );
};

export default CollapsibleSideMenuItem;
