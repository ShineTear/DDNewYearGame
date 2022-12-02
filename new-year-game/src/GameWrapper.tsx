import {Game} from "./Game";
import {Gapped, Input, Modal} from "@skbkontur/react-ui";
import {useState} from "react";
import {NameModal} from "./NameModal";

export function GameWrapper() {
    const [name, setName] = useState<null | string>(null);
    const emptyName = name == null || name === "";
    return <Gapped vertical>
        {emptyName && <NameModal name={name} onChange={setName} />}
        {!emptyName &&
            <Gapped vertical>
                <h2>Хохотон</h2>
                <div>Имя: {name}</div>
                <div>Space - прыгать</div>
                <div>F - кидать подарки</div>
                <Game width={1024} height={655} name={name} />
            </Gapped>
        }
    </Gapped>
}