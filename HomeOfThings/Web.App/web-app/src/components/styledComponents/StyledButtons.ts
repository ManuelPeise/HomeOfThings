import styled from '@emotion/styled';
import { Button, IconButton } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledButton = styled(Button)({
  backgroundColor: 'transparent',
  border: 'none',
  color: 'blue',
  fontWeight: 'bold',
  opacity: 0.8,
  borderRadius: 20,
  fontSize: '1.1rem',
  '&.Mui-disabled': {
    backgroundColor: 'transparent',
    color: 'lightGray',
    opacity: 0.5,
  },
  '&:focus': {
    opacity: 1,
  },
  '&:hover': {
    opacity: 1,
    fontWeight: 'bold',
    backgroundColor: ColorTypeEnum.Transparent,
  },
});

export const RoundedButton = styled(Button)({
  backgroundColor: ColorTypeEnum.Transparent,
  border: 'none',
  fontWeight: '400',
  borderRadius: 20,
  fontSize: '1.1rem',
  padding: '2px 10px',
  color: ColorTypeEnum.LightBlue,
  '&.Mui-disabled': {
    backgroundColor: ColorTypeEnum.Transparent,
    color: ColorTypeEnum.LightGray,
    cursor: 'not-allowed',
  },
  '&:focus': {
    opacity: 1,
  },
  '&:hover': {
    opacity: 1,
    color: ColorTypeEnum.LightBlue,
    fontWeight: '400',
  },
});

export const StyledIconButton = styled(IconButton)({
  '&:hover': {
    cursor: 'pointer',
  },
  '&.Mui-disabled': {
    opacity: 0.5,
    cursor: 'not-allowed',
  },
});
