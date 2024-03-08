import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AuthPage from "../auth/AuthPage";
import { AuthContext, useAuth } from "../../hooks/auth/useAuth";
import LandingPage from "../landing/LandingPage";
import { RouteTypeEnum } from "../../lib/enums/RouteTypeEnum";
import PageLayout from "../../components/layouts/PageLayout";
import PlayGround from "../playground/PlayGround";
import AccountDetailPage from "../account/AccountDetailPage";
import ExpenseOverviewPage from "../finance/expenseOverview/ExpenseOverviewPage";

const AppRouter: React.FC = () => {
  const { userData, handleLogin, handleLogout } = useAuth();
  return (
    <AuthContext.Provider
      value={{
        userData: userData,
        onLogin: handleLogin,
        onLogout: handleLogout,
      }}
    >
      <BrowserRouter>
        <Routes>
          <Route path={RouteTypeEnum.Auth} Component={AuthPage} />
          <Route path={RouteTypeEnum.Home} Component={PageLayout}>
            <Route path={RouteTypeEnum.Home} Component={LandingPage} />
            <Route path={RouteTypeEnum.PlayGround} Component={PlayGround} />
            <Route path={RouteTypeEnum.Account} Component={AccountDetailPage} />
            <Route
              path={RouteTypeEnum.ExpenseOverview}
              Component={ExpenseOverviewPage}
            />
          </Route>
        </Routes>
      </BrowserRouter>
    </AuthContext.Provider>
  );
};

export default AppRouter;
