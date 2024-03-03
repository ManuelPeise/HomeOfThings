import React from "react";
import { StyledTextButton } from "../styledComponents";

interface IProps{
    disabled?: boolean
    title: string
    onClick: () => Promise<void> | void
}

const TextButton: React.FC<IProps> = (props) =>{
    const {disabled, title, onClick} = props

    return (<StyledTextButton
                disabled={disabled}
                variant="text"
                onClick={onClick}
                >{title}</StyledTextButton>)
}

export default TextButton