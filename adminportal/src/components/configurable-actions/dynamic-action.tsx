import { FormMarkup, useConfigurableAction } from "@shesha-io/reactjs";
import { CUSTOM_CONFIGURABLE_ACTIONS, CUSTOM_CONFIGURABLE_ACTIONS_OWNER } from "./model";
import { message } from "antd";
import settingsJson from './dynamic-action-settings.json';

export interface IDynamicMessage {
    dynamicMessage: string;
}

const settingsMarkup = settingsJson as FormMarkup;

export const useShowDynamicMessageAction = () => {

    useConfigurableAction<IDynamicMessage>({
        owner: CUSTOM_CONFIGURABLE_ACTIONS_OWNER,
        ownerUid: CUSTOM_CONFIGURABLE_ACTIONS_OWNER,
        name: CUSTOM_CONFIGURABLE_ACTIONS.DYNAMIC,
        argumentsFormMarkup: settingsMarkup,
        hasArguments: true,
       executer: (actionArgs, context) => {
            const { dynamicMessage } = actionArgs;
            const { application: { user }} = context;
            message.info(`Hello ${user.userName}, ${dynamicMessage}`);
            return Promise.resolve()
        }
    }, []);
};  

