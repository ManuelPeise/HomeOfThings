import styled from "@emotion/styled";
import { Box, Grid, Paper } from "@mui/material";

export const StyledPageContainer = styled(Grid)({
    width:"100vw",
    height:"100vh",
})

export const StyledPageBody = styled(Grid)({
    width:"100vw",
    height:"100%"
})

export const StyledPageWrapper = styled(Grid)({
    padding:"2rem",
    paddingTop: "4rem",
    minWidth:"800px",
    width:"100%",
    height:"100%",
    overflow:"hidden",
})

export const StyledPageContent = styled(Grid)({
    height:"80%",
    marginTop:"3rem"
})

export const StyledSection = styled(Grid)({
   
})

export const StyledBox = styled(Box)({
    position:"relative",
    height:"auto",
    width:"100%"
})

export const StyledPaper = styled(Paper)({
    position:"relative",
    width:"100%",
    height:"100%",
    padding:"1rem",
    overflow:"hidden"
})