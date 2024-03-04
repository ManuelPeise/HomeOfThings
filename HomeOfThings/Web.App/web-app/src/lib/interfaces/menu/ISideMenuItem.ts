import { ColorTypeEnum } from "../../enums/ColorTypeEnum"
import { FontSizeEnum } from "../../enums/FontSizeEnum"

export interface ISideMenuItem{
    key: number
    sortOrder: number
    title: string
    textSize: FontSizeEnum
    textColor: ColorTypeEnum
    icon: JSX.Element
    iconColor: ColorTypeEnum
    disabled: boolean
    sumItems: ISideMenuSubItem[]

}

export interface ISideMenuSubItem{
    title: string
    textSize: FontSizeEnum
    to: string
}