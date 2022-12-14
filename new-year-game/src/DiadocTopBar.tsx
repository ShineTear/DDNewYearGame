import {Logotype, TopBar} from "@skbkontur/react-ui-addons";
import {Diadoc, Kontur} from "@skbkontur/logos";
import {MenuItem} from "@skbkontur/react-ui";
import React from "react";

export function DiadocTopBar() {
    return (
        <TopBar>
            <TopBar.Start>
                <TopBar.ItemStatic use="default">
                    <Logotype konturLogo={<Kontur/>} productLogo={<Diadoc/>} withWidget size={28}/>
                </TopBar.ItemStatic>
                <TopBar.OrganizationsDropdown caption={'ООО Кукурузник'}>
                    <MenuItem>ИП Ромашка</MenuItem>
                    <MenuItem>ПАО Рога и Копыта</MenuItem>
                    <TopBar.DropdownMenuSeparator/>
                    <MenuItem>ООО ВКАЭРО</MenuItem>
                </TopBar.OrganizationsDropdown>
            </TopBar.Start>
            <TopBar.End>
                <TopBar.Item icon={'gear'}>Реквизиты и настройки</TopBar.Item>
                <TopBar.Item icon={'help-circle'}>Помощь</TopBar.Item>
                <TopBar.Link href="https://google.com" icon={'help-circle'}>Ссылка</TopBar.Link>
                <TopBar.Avatar userName={'Типа Пользователь'} />
            </TopBar.End>
        </TopBar>
    );
}