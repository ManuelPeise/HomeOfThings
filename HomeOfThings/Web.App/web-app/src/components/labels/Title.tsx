import { Grid, Typography } from "@mui/material";
import React from "react";
import { ColorTypeEnum } from "../../lib/enums/ColorTypeEnum";
import { FontSizeEnum } from "../../lib/enums/FontSizeEnum";

interface IProps {
  title: string;
  variant?: "h3" | "h4" | "h5" | "h6";
  justify?: "center" | "flex-start" | "flex-end";
  padding: string;
  textColor?: ColorTypeEnum;
  fontSize?: FontSizeEnum;
}

const Title: React.FC<IProps> = (props) => {
  const { title, variant, padding, justify, textColor, fontSize } = props;
  return (
    <Grid
      container
      justifyContent={justify ?? "center"}
      style={{ padding: `${padding}rem`, color: textColor }}
    >
      <Typography style={{ fontSize: fontSize }} variant={variant}>
        {title}
      </Typography>
    </Grid>
  );
};

export default Title;
