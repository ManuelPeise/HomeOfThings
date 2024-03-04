import React from "react";
import { ColorTypeEnum } from "../../../lib/enums/ColorTypeEnum";
import { StyledListItemText } from "../../styledComponents";
import { FontSizeEnum } from "../../../lib/enums/FontSizeEnum";
import { Typography } from "@mui/material";

interface IProps{
    text: string
    textColor: ColorTypeEnum
    textSize: FontSizeEnum
}

const ListItemText: React.FC<IProps> = (props) =>{
    const {text, textColor, textSize} = props

    return (<StyledListItemText>
        <Typography style={{color: textColor, fontSize: `${textSize}px`}}>
            {text}
        </Typography>
    </StyledListItemText>)
}

export default ListItemText