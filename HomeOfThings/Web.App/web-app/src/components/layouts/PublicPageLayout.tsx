import { Grid } from "@mui/material";
import React from "react";
import { Outlet } from "react-router-dom";

const PublicPageLayout: React.FC = () =>{

    return (
        <Grid container>
            <Grid item xs={12}>
                {/* header */}
            </Grid>
            <Grid item xs={12}>
                <Outlet/>
            </Grid>
        </Grid>
    )
}

export default PublicPageLayout