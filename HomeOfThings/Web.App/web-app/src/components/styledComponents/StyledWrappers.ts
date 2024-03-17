import { Box, Grid, Paper, styled } from '@mui/material';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';

interface IProps {
  width?: string;
  height?: string;
  paddingTop?: string;
  padding?: string;
}

const StyledPageWrapper = styled(Box)<IProps>((props) => ({
  backgroundColor: ColorTypeEnum.LightGray,
  height: props.height,
  width: props.width,
  paddingTop: props.paddingTop,
  minWidth: '800px',
  maxWidth: '100%',
  overflow: 'hidden',
  [props.theme.breakpoints.up('xs')]: {
    fontSize: '.7rem',
  },
  [props.theme.breakpoints.up('xl')]: {
    fontSize: '7rem',
  },
  [props.theme.breakpoints.up('sm')]: {
    fontSize: '.7rem',
  },
  [props.theme.breakpoints.up('md')]: {
    fontSize: '1rem',
  },
  [props.theme.breakpoints.up('lg')]: {
    fontSize: '1.3rem',
  },
}));

interface IGridProps {
  width?: string;
  height?: string;
  marginTop?: string;
  backGround?: ColorTypeEnum;
}

const StyledGridContainer = styled(Grid)<IGridProps>((props) => ({
  height: props.height,
  width: props.width,
  marginTop: props.marginTop,
  backgroundColor: props.backGround,
  overflow: 'hidden',
}));

const StyledGridItem = styled(Grid)<IGridProps>((props) => ({
  height: props.height,
  width: props.width,
  marginTop: props.marginTop,
}));

const StyledPaperWrapper = styled(Paper)<IProps>((props) => ({
  width: props.width,
  height: props.height,
  padding: props.padding,
}));

export {
  StyledPageWrapper,
  StyledGridContainer,
  StyledGridItem,
  StyledPaperWrapper,
};
