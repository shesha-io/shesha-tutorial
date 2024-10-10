"use client";

import React, { FC, PropsWithChildren } from "react";
import {
  GlobalStateProvider,
  ShaApplicationProvider,
  StoredFilesProvider,
  useNextRouter,
} from "@shesha-io/reactjs";
import { AppProgressBar } from "next-nprogress-bar";
import { useTheme } from "antd-style";
import { EnquiryActionsProvider } from "@/components/templates/dynamic-templates";
import { CustomConfigurableActionsAccessor } from "@/components/configurable-actions/custom-configurable-actions-processor";

export interface IAppProviderProps {
  backendUrl: string;
}

export const AppProvider: FC<PropsWithChildren<IAppProviderProps>> = ({
  children,
  backendUrl,
}) => {
  const nextRouter = useNextRouter();
  const theme = useTheme();

  return (
    <GlobalStateProvider>
      <AppProgressBar height="4px" color={theme.colorPrimary} shallowRouting />
      <ShaApplicationProvider
        backendUrl={backendUrl}
        router={nextRouter}
        noAuth={nextRouter.path?.includes('/no-auth')}
      >
        <CustomConfigurableActionsAccessor>
          <EnquiryActionsProvider>
            <StoredFilesProvider baseUrl={backendUrl} ownerId={""} ownerType={""}>
                {children}
            </StoredFilesProvider>
          </EnquiryActionsProvider>
        </CustomConfigurableActionsAccessor>
      </ShaApplicationProvider>
    </GlobalStateProvider>
  );
};
