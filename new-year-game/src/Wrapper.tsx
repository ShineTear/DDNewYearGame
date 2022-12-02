import {PropsWithChildren} from "react";

export function Wrapper({ children }: PropsWithChildren) {
    return <div style={{flex: "1 auto", display: "flex", flexDirection: "column"}}>
        <div style={{maxWidth: 1200, margin: "0 auto", width: "100%"}}>
            {children}
        </div>
    </div>;
}