import React from "react";
import { INavLink } from "../../lib/interfaces/navigation/INavLink";
import { StyledLabel } from "../styledComponents";
import { useNavigate } from "react-router-dom";

interface IProps{
    link: INavLink
}

const NavLink: React.FC<IProps> = (props) =>{
    const {link} = props

    const navigate = useNavigate()

    const handleNavigate = React.useCallback(() => {
        navigate(link.to)
    },[link, navigate])

    return <StyledLabel variant="button" onClick={handleNavigate}>{link.title}</StyledLabel>
}

export default NavLink