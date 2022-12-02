import {useEffect, useState} from "react";
import {api, LeaderboardScore} from "./GameApi";

export function Leaderboard() {
    const [scores, setScores] = useState<LeaderboardScore[]>([])

    const getScores = async () => {
        const scores = await api.showScoreOnGame();
        setScores(scores);
    }

    useEffect(() => {
        getScores();
    })

    return <div>
        {scores.map(x => <div>{x.playerName} - {x.score}</div>)}
    </div>
}