import { IApiOptions } from "./IApiOptions";

export interface IStatelessApi<T>{
    get: (options?: IApiOptions) => Promise<T | null>
    post: (options: IApiOptions, body: string) => Promise<void>
    rebind: () => Promise<T|null>
}