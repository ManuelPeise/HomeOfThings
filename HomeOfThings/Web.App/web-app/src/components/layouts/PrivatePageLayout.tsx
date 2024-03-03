import { Grid } from "@mui/material";
import React from "react";
import { AuthContext } from "../../hooks/auth/useAuth";
import { Outlet, useNavigate } from "react-router-dom";

const PrivatePageLayout: React.FC = () =>{
    const navigate = useNavigate();
    const {userData} = React.useContext(AuthContext)

    React.useEffect(() =>{
        if(userData == null || userData.email === undefined){
            navigate("/auth")
        }
    },[userData, navigate])

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

export default PrivatePageLayout