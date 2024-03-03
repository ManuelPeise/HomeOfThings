import styled from "@emotion/styled";
import { Button, TextField, Typography } from "@mui/material";

// Buttons

export const StyledTextButton = styled(Button)(({theme}) =>({
    color: "blue",
    fontWeight:"bold",
    opacity:.8,
    "&:focus":{
        opacity:1
    },
    "&:hover":{
        opacity: 1,
        fontWeight:"bold",
        backgroundColor: "transparent"
    },
    "&.Mui-disabled":{
        opacity: .5
    }
}))

// Textfields

export const UnderlinedTextBox = styled(TextField)(({theme}) =>({
    "&& .MuiInputBase-input":{
        color: "blue",
        fontSize: "1.5rem",
        opacity:.7,
        "&:focus":{
            opacity:1
        },
        "&:hover":{},
        "&.Mui-disabled":{
            opacity: .5
        }
    }
}))

// Links

export const StyledLabel = styled(Typography)({
    color: "black",
    fontSize: ".8rem",
    fontWeight:"bold",
    textDecoration: "none",
    padding: "0 10px",
    "&:hover":{
        cursor: "pointer",
        color: "blue",
        fontWeight: "bolder"
    }
})