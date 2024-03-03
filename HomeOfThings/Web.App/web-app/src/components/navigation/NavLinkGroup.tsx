import React from "react";
import { INavLink } from "../../lib/interfaces/navigation/INavLink";
import { Grid } from "@mui/material";
import NavLink from "./NavLink";

interface IProps{
    links: INavLink[]
    marginTopPx?: number
    justify?: "flex-start" | "center" | "flex-end"
}

const NavLinkGroup: React.FC<IProps> = (props) =>{
    const {links, marginTopPx, justify} = props

    return (<Grid container style={{display: "flex", flexDirection: "row", justifyContent:justify??"center", marginTop: `${marginTopPx}px`}}>
        {links.map((link, index) =>{
            return (
                <NavLink key={index} link={link}/>
            )
        })}
    </Grid>)
}

export default NavLinkGroup