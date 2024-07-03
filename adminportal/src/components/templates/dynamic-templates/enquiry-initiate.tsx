import React, { PropsWithChildren, useMemo } from "react";
import { FC } from "react";
import {
    DynamicActionsProvider,
    ButtonGroupItemProps,
    DynamicItemsEvaluationHook,
    useAppConfigurator,
    IButtonItem,
} from "@shesha-io/reactjs";
import { useTemplates } from "../hooks";
import {
    makeActionConfig,
    makeNavigateActionConfig,
} from "utils/configurableActions";
import { GetMember } from "../fetchers";

export interface IWorkflowInstanceStartActionsProps { }

const useEnquiryInitiateActions: DynamicItemsEvaluationHook = (args) => {
    // Calling hook to get all templates 
    const { data, isLoading, error } = useTemplates();
    const { configurationItemMode } = useAppConfigurator();

    const operations = useMemo<ButtonGroupItemProps[]>(() => {
        if (!data || isLoading || error) return [];

        // Mapping out templates to form list of options
        // Dependencies: current user
        const result = data.map<IButtonItem>((p) => ({
            id: p.id,
            name: p.name,
            label: p.name,
            itemType: "item",
            itemSubType: "button",
            sortOrder: 0,
            actionConfiguration: makeActionConfig({ // Creating Enquiry from selecting a template
                actionName: "API Call",
                actionOwner: "shesha.common",
                actionArguments: {
                    verb: "post",
                    url: `/api/dynamic/Shesha.Tutorial/Enquiry/Crud/Create`,
                    parameters: [
                        {
                            id: "CBc2Xng3M682kZwGhAwHt",
                            key: "member",
                            value: GetMember(),
                        },
                        {
                            id: "AKc2Xng3M682kZwGhAwHt",
                            key: "template",
                            value: p.id,
                        }
                    ],
                    sendStandardHeaders: true,
                },
                onSuccess: makeNavigateActionConfig({ // Navigating to Enquiry Form 
                    actionArguments: {
                        navigationType: "url",
                        url: "/dynamic/ShaCompanyName.ShaProjectName/member-enquiry",
                        queryParameters: [{ key: "id", value: "{{actionResponse.id}}" }, { key: "mode", value: "edit" }],
                    },
                }),
                onFail: makeActionConfig({ // Error message to show on fail
                    actionName: "Show Confirmation Dialog",
                    actionOwner: "shesha.common",
                    actionArguments: {
                        title: "Error",
                        content: "Failed to initiate enquiry!",
                        okText: "",
                        cancelText: "",
                    },
                }),
            }),
        }));

        return result;
    }, [args.item, data, configurationItemMode]);

    return operations;
};

export const EnquiryInitiateActions: FC<
    PropsWithChildren<IWorkflowInstanceStartActionsProps>
> = ({ children }) => {
    return (
        <DynamicActionsProvider
            id="enquiry-initiate"
            name="Enquiry Initiate"
            useEvaluator={useEnquiryInitiateActions}
        >
            {children}
        </DynamicActionsProvider>
    );
};
