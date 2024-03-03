import React from "react"
import { ApiEndpointEnum } from "../../lib/enums/ApiEndpointEnum"

export const useEndpoint = () =>{

    const baseUrlRef = React.useRef<string>("")

    React.useEffect(() =>{
        if(process.env.REACT_APP_API_BASEURL !== undefined){
            baseUrlRef.current = process.env.REACT_APP_API_BASEURL
        }
    },[])

    const getServiceUrl = React.useCallback((endpoint: ApiEndpointEnum) =>{
        switch(endpoint){
            case ApiEndpointEnum.PostLogin:
                return `${baseUrlRef.current}${ApiEndpointEnum.PostLogin}`
            case ApiEndpointEnum.PostRegistration:
                return `${baseUrlRef.current}${ApiEndpointEnum.PostLogin}`
            default:
                return `${baseUrlRef.current}`
        }
    },[])

    return {
        getServiceUrl
    }
}