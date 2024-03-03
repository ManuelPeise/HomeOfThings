import { ApiEndpointEnum } from "../../enums/ApiEndpointEnum"

export interface IApiOptions{
    serviceUrl: ApiEndpointEnum
    parameters: null | string
    requestOptions: RequestInit
}