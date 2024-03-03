import { ILoginData } from "./ILoginData";
import { IUserData } from "./IUserData";

export interface IAuthContext{
    userData: IUserData | null,
    onLogin: (model: ILoginData) => Promise<void>
    onLogout: () => Promise<void>
}