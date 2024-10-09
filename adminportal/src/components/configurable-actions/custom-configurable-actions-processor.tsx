import { FC, PropsWithChildren } from "react";
import { useShowStaticMessageAction } from "./static-action";
import { useShowDynamicMessageAction } from "./dynamic-action";

export const CustomConfigurableActionsAccessor: FC<PropsWithChildren<{}>> = ({ children }) => {
    useShowStaticMessageAction();
    useShowDynamicMessageAction()

    return (
        <>{children}</>
    );
};