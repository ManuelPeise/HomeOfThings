import { Grid, Typography } from "@mui/material";
import React from "react";

interface IProps{
    title: string
    variant: "h3" | "h4" | "h5" | "h6"
    justify?:"center" | "flex-start" | "flex-end"
    padding: string
}

const Title: React.FC<IProps> = (props) =>{
    const {title, variant, padding, justify} = props
    return <Grid container justifyContent={justify??"center"} style={{padding:`${padding}rem`}}>
        <Typography variant={variant}>{title}</Typography>
    </Grid>
}

export default Title