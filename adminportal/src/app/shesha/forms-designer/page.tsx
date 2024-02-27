"use client";

import React, { FC } from "react";
import { FormIdentifier, FormsDesignerPage } from "@shesha-io/reactjs";
import { useSearchParams, notFound } from "next/navigation";
import styled from "styled-components";

const Page: FC = () => {
  const query = useSearchParams();
  const id = query.get("id");
  const name = query.get("name");
  const moduleName = query.get("module");

  const formId: FormIdentifier = id
    ? id
    : name
    ? {
        name: name,
        module: moduleName,
      }
    : undefined;

  if (!formId) return notFound();

  return (
    <CustomFormsDesignerPage>
      <FormsDesignerPage formId={formId} />
    </CustomFormsDesignerPage>
  );
};

const CustomFormsDesignerPage = styled.div`
  .ant-space-compact-block {
    display: none !important;
  }
`;

export default Page;
