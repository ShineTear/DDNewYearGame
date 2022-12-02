import ApiBase from './ApiBase/ApiBase';

export interface LeaderboardScore
{
    playerName: string,
    score: number;
}

export class GameApi extends ApiBase {
    public async saveScoreByGame(entity: LeaderboardScore): Promise<void> {
        return this.post(`score`, {
            ...entity
        });
    }

    public async showScoreOnGame(): Promise<LeaderboardScore[]> {
        return this.get("");
    }
}

export const api = new GameApi("api/leaderboard");