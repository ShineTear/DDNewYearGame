import { Gapped } from "@skbkontur/react-ui";
import {RouterLink} from "./RouterLink";
import background from "./img/background.png";
import {backgroundImg} from "./img";

export function Splash() {
    return <Gapped vertical>
            <h2>Дед Хо-Хо-тун</h2>
            <div>Хо-Хо! Дед Мороз!</div>
            <div>Беги быстрее от 2022, успей выкинуть все лишнее из своих карманчиков, пока не наступил 2023.</div>
            <div>Самый быстрый Дед мороз получает приз (Хо-Хо-Хо!)</div>
            <br/>
            <RouterLink to="/Game">Играть</RouterLink>
            <RouterLink to="/Leaderboard">Доска почета</RouterLink>
            <div className="cropped"><img src={background}/></div>

    </Gapped>
}