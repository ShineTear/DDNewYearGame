import React from 'react'
import ReactDOM from 'react-dom/client'
import {BrowserRouter, Route} from "react-router-dom";
import {DiadocTopBar} from "./DiadocTopBar";
import {GameWrapper} from "./GameWrapper";
import {Leaderboard} from "./Leaderboard";
import {Splash} from "./Splash";
import {CommonWrapper} from "@skbkontur/react-ui/internal/CommonWrapper";
import {Wrapper} from "./Wrapper";

ReactDOM.createRoot(document.getElementById('root') as HTMLElement).render(
    <React.StrictMode>
        <BrowserRouter>
            <DiadocTopBar />
            <Wrapper>
                <Route exact path="/" component={Splash}/>
                <Route exact path="/Game" component={GameWrapper}/>
                <Route exact path="/Leaderboard" component={Leaderboard}/>
            </Wrapper>
        </BrowserRouter>
    </React.StrictMode>
)
