import React from 'react'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import AuthPage from '../auth/AuthPage'
import { AuthContext, useAuth } from '../../hooks/auth/useAuth'
import PrivatePageLayout from '../../components/layouts/PrivatePageLayout'
import LandingPage from '../landing/LandingPage'
import { RouteTypeEnum } from '../../lib/enums/RouteTypeEnum'
import PublicPageLayout from '../../components/layouts/PublicPageLayout'


const AppRouter: React.FC = () => {

    const {userData, handleLogin, handleLogout} = useAuth()
    return(
        <AuthContext.Provider value={{userData: userData, onLogin: handleLogin, onLogout: handleLogout}}>
            <BrowserRouter>
                <Routes>
                    <Route path={RouteTypeEnum.Home} Component={PrivatePageLayout}>
                        <Route path={RouteTypeEnum.Home} Component={LandingPage}/>
                    </Route>
                    <Route path={RouteTypeEnum.Home} Component={PublicPageLayout}>
                        <Route path={RouteTypeEnum.Auth} Component={AuthPage}/>
                    </Route>
                </Routes>
            </BrowserRouter>
        </AuthContext.Provider>
    )
}

export default AppRouter