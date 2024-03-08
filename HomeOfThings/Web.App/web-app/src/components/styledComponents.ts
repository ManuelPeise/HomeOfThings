import styled from "@emotion/styled";
import { AppBar, Box, Drawer, Grid, List, ListItem, ListItemButton, ListItemIcon, ListItemText,  TextField, Typography } from "@mui/material";

// Textfields

export const UnderlinedTextBox = styled(TextField)(({theme}) =>({
    "&.MuiInputBase-input":{
        color: "blue",
        fontSize: "1.5rem",
        opacity:.7,
        "&:focus":{
            opacity:1
        },
        "&:hover":{},
        "&.Mui-disabled":{
            opacity: .5,
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

// AppBar

export const StyledAppBar = styled(AppBar)({
    backgroundColor:"black",
    position: '-webkit-sticky',
    top: 0,
    left:0, 
})

// Drawer

export const StyledDrawer = styled(Drawer)({
    "& .MuiDrawer-paper":{
        backgroundColor:"#000000"
    }
})

export const StyledDrawerContainer = styled(Box)({
    backgroundColor:"red",
    maxWidth: "20vw",
    minWidth: "300px",
    width: "15vw"
})

export const StyledDrawerList = styled(List)({
    background: "#000000",
})

export const StyledDrawerListItem = styled(ListItem)({
    paddingLeft: "1rem",
    paddingRight: "1rem",
    "&:hover":{
        opacity: .5
    },
})

export const StyledDrawerListItemButton = styled(ListItemButton)({
    "&:hover":{
        backgroundColor: "transparent"
    },
    "&.Mui-disabled":{
        
    }
})

export const StyledGrid = styled(Grid)({

})

// ListItems
export const StyledListItemIcon = styled(ListItemIcon)({})

export const StyledListItemText = styled(ListItemText)({})