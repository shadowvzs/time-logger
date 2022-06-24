import React from "react";
import { RootStore } from "./rootStore";

export const AppContext = React.createContext<RootStore>(null!);

interface AppProviderProps {
    children: JSX.Element;
}

export function AppProvider(props: AppProviderProps) {
    const store = React.useMemo(() => new RootStore(), []);

    return (
        <AppContext.Provider value={store}>
            { props.children }
        </AppContext.Provider>
    );
}