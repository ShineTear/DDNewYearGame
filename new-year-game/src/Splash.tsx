import { Gapped } from "@skbkontur/react-ui";
import {RouterLink} from "./RouterLink";
import background from "./img/background.png";
import {backgroundImg} from "./img";

export function Splash() {
    return <Gapped vertical>
            <h2>главный экран</h2>
            <div>ну типа описание игры</div>
            <div className="cropped"><img src={background}/></div>
            <RouterLink to="/Game">Играть</RouterLink>
            <RouterLink to="/Leaderboard">Доска почета</RouterLink>
    </Gapped>
}