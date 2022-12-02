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
    }, [])

    return <Gapped vertical>
        <h2>Доска лидеров</h2>
        {scores
            .sort((a, b) => b.score - a.score)
            .map((x, i) => <div>{i + 1}. {x.playerName} - {x.score}</div>)
        }
    </Gapped>
}