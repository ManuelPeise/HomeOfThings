import { Grid, Typography } from '@mui/material';
import React from 'react';
import { ColorTypeEnum } from '../../lib/enums/ColorTypeEnum';
import { FontSizeEnum } from '../../lib/enums/FontSizeEnum';

interface IProps {
  title: string;
  variant?: 'h3' | 'h4' | 'h5' | 'h6';
  justify?: 'center' | 'flex-start' | 'flex-end';
  padding: string;
  textColor?: ColorTypeEnum;
  fontSize?: FontSizeEnum;
  fontStyle?: 'italic' | 'normal';
  fontFamily?: 'cursive' | 'serif' | 'sans-serif';
}

const Title: React.FC<IProps> = (props) => {
  const {
    title,
    variant,
    padding,
    justify,
    textColor,
    fontSize,
    fontStyle,
    fontFamily,
  } = props;
  return (
    <Grid
      container
      justifyContent={justify ?? 'center'}
      style={{ padding: `${padding}rem`, color: textColor }}
    >
      <Typography
        style={{
          fontSize: fontSize,
          fontStyle: fontStyle,
          fontFamily: fontFamily,
        }}
        variant={variant}
      >
        {title}
      </Typography>
    </Grid>
  );
};

export default Title;
