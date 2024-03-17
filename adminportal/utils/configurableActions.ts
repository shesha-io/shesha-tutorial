import {
  IConfigurableActionConfiguration,
  INavigateActoinArguments,
} from "@shesha-io/reactjs";

const ACTION_CONFIG_TYPE = "action-config";

export const makeActionConfig = <TArgs = any>(
  props: Pick<
    IConfigurableActionConfiguration<TArgs>,
    "actionName" | "actionOwner" | "actionArguments" | "onSuccess" | "onFail"
  >
): IConfigurableActionConfiguration<TArgs> => {
  return {
    _type: ACTION_CONFIG_TYPE,
    actionName: props.actionName,
    actionOwner: props.actionOwner,
    actionArguments: props.actionArguments,
    handleSuccess: Boolean(props.onSuccess),
    onSuccess: props.onSuccess,
    handleFail: Boolean(props.onFail),
    onFail: props.onFail,
  };
};

export const makeNavigateActionConfig = (
  props: Pick<
    IConfigurableActionConfiguration<INavigateActoinArguments>,
    "actionArguments" | "onSuccess" | "onFail"
  >
): IConfigurableActionConfiguration<INavigateActoinArguments> => {
  return {
    _type: ACTION_CONFIG_TYPE,
    actionName: "Navigate",
    actionOwner: "shesha.common",
    actionArguments: props.actionArguments,
    handleSuccess: Boolean(props.onSuccess),
    onSuccess: props.onSuccess,
    handleFail: Boolean(props.onFail),
    onFail: props.onFail,
    version: 2,
  };
};
