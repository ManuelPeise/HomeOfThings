import React from 'react';
import { IListItem } from '../../../lib/interfaces/list/IListItem';
import { ListItemButton, ListItemText } from '@mui/material';

interface IProps {
  item: IListItem;
  selectedItemId: number;
  onClick: (id: number) => void;
}

const MenuListItem: React.FC<IProps> = (props) => {
  const { item, selectedItemId, onClick } = props;

  return (
    <ListItemButton
      style={{
        width: '100%',
        maxWidth: '100%',
        padding: '16px',
        backgroundColor: 'lightblue',
      }}
      selected={item.id === selectedItemId}
      disabled={item.id === selectedItemId}
      onClick={onClick.bind(null, item.id)}
    >
      <ListItemText disableTypography>{item.title}</ListItemText>
      <ListItemText disableTypography>{item.subTitle ?? ''}</ListItemText>
    </ListItemButton>
  );
};

export default MenuListItem;
