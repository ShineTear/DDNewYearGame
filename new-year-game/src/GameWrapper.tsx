import {Game} from "./Game";
import {Gapped, Input, Modal} from "@skbkontur/react-ui";
import {useState} from "react";
import {NameModal} from "./NameModal";

export const userNameCookie = "useruserUserName=";

export function getPlayerName(): string | null {
    if (document.cookie.includes(userNameCookie)) {
        const nameStart = document.cookie.indexOf(userNameCookie) + userNameCookie.length;
        let nameEnd = document.cookie.indexOf(";", nameStart);
        if (!nameEnd || nameEnd == -1) {
            nameEnd = document.cookie.length;
        }
        return document.cookie.substring(nameStart, nameEnd);
    }

    return null;
}

export function GameWrapper() {
    let userName: null | string = getPlayerName();
    const [name, setName] = useState<null | string>(userName);
    const emptyName = name == null || name === "";
    return <Gapped vertical>
        {emptyName && <NameModal name={name} onChange={(x) => {
            setName(x);
            document.cookie =`${userNameCookie}${x}`;
        }} />}
        {!emptyName &&
            <Gapped vertical>
                <h2>Хо-Хо-тун</h2>
                <div>Имя: {name}</div>
                <div>Space - прыгать</div>
                <div>F - кидать подарки</div>
                <Game width={1024} height={655} name={name} />
            </Gapped>
        }
    </Gapped>
}