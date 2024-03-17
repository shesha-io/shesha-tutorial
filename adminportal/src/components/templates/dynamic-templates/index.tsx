import React, { FC, PropsWithChildren } from "react";
import { EnquiryInitiateActions } from "./enquiry-initiate";

export interface IEnquiryActionsProviderProps { }

export const EnquiryActionsProvider: FC<
    PropsWithChildren<IEnquiryActionsProviderProps>
> = ({ children }) => {
    return (
        <EnquiryInitiateActions>{children}</EnquiryInitiateActions>
    );
};
