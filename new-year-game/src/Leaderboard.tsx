import React, {useEffect, useState} from "react";
import {api, LeaderboardScore} from "./GameApi";
import {Gapped} from "@skbkontur/react-ui";

export function Leaderboard() {
    const [scores, setScores] = useState<LeaderboardScore[]>([])

    const getScores = async () => {
        const scores = await api.showScoreOnGame();
        setScores(scores);
    }

    useEffect(() => {
        getScores();
    })

    return <Gapped vertical>
        <h2>Доска лидеров</h2>
        {scores.map(x => <div>{x.playerName} - {x.score}</div>)}
    </Gapped>
}