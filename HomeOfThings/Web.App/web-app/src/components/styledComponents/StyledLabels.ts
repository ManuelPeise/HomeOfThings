import styled from '@emotion/styled';
import { Grid, Typography } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

export const StyledTitleWrapper = styled(Grid)({
  display: 'flex',
  padding: '1rem',
  paddingLeft: '4rem',
  width: '100%',
});

export const StyledPageTitleLabel = styled(Typography)({
  color: ColorTypeEnum.LightBlue,
  fontStyle: 'italic',
  fontFamily: 'cursive',
  paddingLeft: '1.2rem',
});
