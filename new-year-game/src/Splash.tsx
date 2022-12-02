import { Gapped } from "@skbkontur/react-ui";
import {RouterLink} from "./RouterLink";
import background from "./img/background.png";
import {backgroundImg} from "./img";

export function Splash() {
    return <div style={{flex: "1 auto", display: "flex", flexDirection: "column"}}>
        <Gapped vertical style={{maxWidth: 1200, margin: "0 auto", width: "100%"}}>
            <h2>главный экран</h2>
            <div>ну типа описание игры</div>
            <div className="cropped"><img src={background}/></div>
            <RouterLink to="/Game">Играть</RouterLink>
            <RouterLink to="/Leaderboard">Доска почета</RouterLink>
        </Gapped>
    </div>
}