import React from "react"
import { IApiOptions } from "../../lib/interfaces/api/IApiOptions"
import { IStatelessApi } from "../../lib/interfaces/api/IStatelessApi"

export const useStatelessApi = <T>() =>{

    const apiOptionsRef = React.useRef<IApiOptions>({} as IApiOptions)
    
    const get = React.useCallback(async (options?: IApiOptions): Promise<T | null> =>{
        
        if(options !== undefined){
            apiOptionsRef.current = {...apiOptionsRef.current, ...options}
        }
        
        const response = await fetch(
            apiOptionsRef.current?.serviceUrl, 
            {
                method: "GET", 
                mode: "cors",  
                headers: {
            "Content-Type": "application/json",
          }}).then(async (res) =>{

            if(res.ok){
                const parsedObject: T = await JSON.parse(JSON.stringify(res.json))

                return parsedObject
            }

            return null
          })

          return response
    },[])

    const post = React.useCallback(async (options: IApiOptions, body: string): Promise<void> =>{
        
        if(options !== undefined){
            apiOptionsRef.current = {...apiOptionsRef.current, ...options}
        }
        
        await fetch(
            apiOptionsRef.current?.serviceUrl, 
            {
                method: "POST", 
                mode: "cors",  
                headers: {
                    "Content-Type": "application/json",
                },
                body: body
        })

         
    },[])

    const rebind = React.useCallback(async () =>{
        return await get()
    },[get])

    const create = React.useCallback((options: IApiOptions): IStatelessApi<T> => {
        apiOptionsRef.current = options

        return{
            get,
            post,
            rebind
        }
    },[get, post, rebind])

    return {
        create
    }
}