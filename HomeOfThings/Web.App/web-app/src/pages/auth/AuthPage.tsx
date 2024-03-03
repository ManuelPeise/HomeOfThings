import { Grid } from "@mui/material";
import React from "react";
import LoginContainer from "./components/LoginContainer";
import "../../lib/style/page.css"
import RegisterComponent from "./components/RegisterComponent";

const AuthPage: React.FC = () =>{
    const [component, setComponent] = React.useState<string>("login")

    const handleComponentChange = React.useCallback((component: "login" | "register") =>{
        console.log(component)
        setComponent(component)
    },[])

    return (<Grid container className="authPageBody">
        <Grid className="authPageWrapper" item xs={3}>
            {component === "login" && (
                <LoginContainer onComponentChange={handleComponentChange}/>
            )}
            {component === "register" && (
               <RegisterComponent onComponentChange={handleComponentChange}/>
            )}
        </Grid>
    </Grid>)
}

export default AuthPage