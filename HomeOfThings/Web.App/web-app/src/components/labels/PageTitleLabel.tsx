import React from "react";
import { StyledPageTitleLabel, StyledTitleWrapper } from "../styledComponents/StyledLabels";

interface IProps{
    title: string
    id:string
}

const PageTitleLabel: React.FC<IProps> = (props) =>{
    const {title, id} = props

    return (
        <StyledTitleWrapper id={id}>
            <StyledPageTitleLabel variant="h3">{title}</StyledPageTitleLabel>
        </StyledTitleWrapper>
    )
}

export default PageTitleLabel