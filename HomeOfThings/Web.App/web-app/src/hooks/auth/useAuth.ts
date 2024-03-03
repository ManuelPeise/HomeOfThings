import React from "react"
import { IAuthContext } from "../../lib/interfaces/auth/IAuthContext"
import { IUserData } from "../../lib/interfaces/auth/IUserData"
import { useStatelessApi } from "../api/useStatelessApi"
import { ApiEndpointEnum } from "../../lib/enums/ApiEndpointEnum"
import { ILoginData } from "../../lib/interfaces/auth/ILoginData"

const initialModel: IAuthContext = {
    userData: {
        email: "",
    },
    onLogin: async (model: ILoginData) => {},
    onLogout: async () =>{}
}

export const AuthContext = React.createContext(initialModel)

export const useAuth = () => {
    const [userData, setUserData] = React.useState<IUserData | null>(null)

    const loginApiService = useStatelessApi<IUserData>().create({
        serviceUrl: ApiEndpointEnum.PostLogin,
        parameters: "",
        requestOptions:{
            method: "POST",
            body:""
        }
    })

    // TODO implement api service for logout
    
    const handleLogin = React.useCallback(async (model: ILoginData) => {
        const response = await loginApiService.postWithContent({requestOptions:{method:"POST", body: JSON.stringify(model)}})

        setUserData(response)
    },[loginApiService])

    const handleLogout = React.useCallback(async () =>{

    },[])

    const getUserName = React.useCallback((): string | null =>{
        if(userData == null){
            return null
        }

        return userData.email
    },[userData])

    return{
        userData,
        handleLogin,
        handleLogout,
        getUserName
    }
}