import { Grid } from "@mui/material";
import React from "react";
import { Outlet } from "react-router-dom";
import AppToolBar from "../appBars/AppToolBar";
import "../../lib/style/page.css";

const PageLayout: React.FC = () => {
  return (
    <Grid container>
      <AppToolBar />
      <Grid className="pageBody" item xs={12} style={{ marginTop: "4rem" }}>
        <Outlet />
      </Grid>
    </Grid>
  );
};

export default PageLayout;
