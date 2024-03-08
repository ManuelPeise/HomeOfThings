import React from "react";
import { IListItem } from "../../../lib/interfaces/list/IListItem";
import { StyledListItem, StyledListItemSubTitle, StyledListItemTitle } from "../../styledComponents/StyledLists";

interface IProps{
    item: IListItem
    selectedItemId: number
    onClick: (id: number) => void
}

const MenuListItem: React.FC<IProps> = (props) =>{
    const {item, selectedItemId, onClick} = props

    return (
        <StyledListItem selected={item.id === selectedItemId} disabled={item.id === selectedItemId} onClick={onClick.bind(null, item.id)}>
            <StyledListItemTitle disableTypography>{item.title}</StyledListItemTitle>
            <StyledListItemSubTitle disableTypography>{item.subTitle??""}</StyledListItemSubTitle>
        </StyledListItem>)
}

export default MenuListItem