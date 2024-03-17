import styled from '@emotion/styled';
import { List, ListItemButton, ListItemText } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledList = styled(List)({
  '&.MuiList-root': {
    height: '100%',
    padding: 0,
    margin: 0,
    minWidth: '300px',
  },
});

export const StyledListItem = styled(ListItemButton)({
  minWidth: '500px',
  '&.MuiListItemButton-root': {
    width: '100%',
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'flex-start',
  },
  '&.Mui-selected': {
    backgroundColor: ColorTypeEnum.Transparent,
    opacity: 0.3,
  },
});

export const StyledListItemTitle = styled(ListItemText)({
  '&.MuiListItemText-root': {
    width: '100%',
    maxWidth: '100%',
    fontSize: '1.4em',
    color: ColorTypeEnum.Black,
  },
});

export const StyledListItemSubTitle = styled(ListItemText)({
  '&.MuiListItemText-root': {
    width: '100%',
    maxWidth: '100%',
    fontSize: '1em',
    color: ColorTypeEnum.Gray,
  },
});
