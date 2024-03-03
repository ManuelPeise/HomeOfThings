import { IApiOptions } from "./IApiOptions";

export interface IStatelessApi<T>{
    get: (options?: Partial<IApiOptions>) => Promise<T | null>
    post: (options: Partial<IApiOptions>) => Promise<void>
    postWithContent: (options: Partial<IApiOptions>) => Promise<T | null>
    rebind: () => Promise<T|null>
}