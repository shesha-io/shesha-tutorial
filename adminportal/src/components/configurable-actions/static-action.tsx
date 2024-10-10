import { useConfigurableAction } from "@shesha-io/reactjs";
import { CUSTOM_CONFIGURABLE_ACTIONS, CUSTOM_CONFIGURABLE_ACTIONS_OWNER } from "./model";
import { message } from "antd";

export const useShowStaticMessageAction = () => {

    useConfigurableAction({
        owner: CUSTOM_CONFIGURABLE_ACTIONS_OWNER,
        ownerUid: CUSTOM_CONFIGURABLE_ACTIONS_OWNER,
        name: CUSTOM_CONFIGURABLE_ACTIONS.STATIC,
        hasArguments: false,
       executer: () => {
            message.info('This is a static message');
            return Promise.resolve();
        }
    }, []);
};  

