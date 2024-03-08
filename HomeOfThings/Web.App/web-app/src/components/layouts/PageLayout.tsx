import React from "react";
import { Outlet } from "react-router-dom";
import AppToolBar from "../appBars/AppToolBar";
import { StyledPageBody, StyledPageContainer } from "../styledComponents/StyledLayout";


const PageLayout: React.FC = () => {
  return (
    <StyledPageContainer>
      <AppToolBar />
      <StyledPageBody>
        <Outlet />
      </StyledPageBody>
    </StyledPageContainer>
  );
};

export default PageLayout;
