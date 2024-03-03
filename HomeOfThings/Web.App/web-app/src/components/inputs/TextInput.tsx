import React from "react";
import { UnderlinedTextBox } from "../styledComponents";

interface IProps{
    disabled?: boolean
    fullWidth?: boolean
    title?: string
    value: string
    type?: "text" | "password",
    onChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}

const TextInput: React.FC<IProps> = (props) =>{
    const {disabled, fullWidth, title, type, value, onChange} = props

    return(
        <UnderlinedTextBox
            disabled={disabled}
            type={type?? "text"} 
            variant="standard" 
            fullWidth={fullWidth}
            value={value}
            label={title}
            onChange={onChange}/>
    )
}

export default TextInput