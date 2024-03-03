import React from 'react'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import LandingPage from '../landing/LandingPage'

const AppRouter: React.FC = () => {

    return(
        <BrowserRouter>
            <Routes>
                <Route path='' Component={LandingPage}/>
            </Routes>
        </BrowserRouter>
    )
}

export default AppRouter