import React from 'react'
import ReactDOM from 'react-dom/client'
import {BrowserRouter, Route} from "react-router-dom";
import {DiadocTopBar} from "./DiadocTopBar";
import {GameWrapper} from "./GameWrapper";
import {Leaderboard} from "./Leaderboard";
import {Splash} from "./Splash";

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <React.StrictMode>
        <BrowserRouter>
            <DiadocTopBar />
            <Route exact path="/" component={Splash}/>
            <Route exact path="/Game" component={GameWrapper}/>
            <Route exact path="/Leaderboard" component={Leaderboard}/>
        </BrowserRouter>
    </React.StrictMode>
)
