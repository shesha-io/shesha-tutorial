import { FormsDesignerPage } from "@shesha-io/reactjs";
import styled from "styled-components";

export const NoSaveFormsDesignerPage = styled(FormsDesignerPage)`
  body {
    background-color: #f0f2f5;
    color: red;
  }

  .ant-layout {
    background-color: red !important;
  }

  .sha-page {
    background-color: red !important;
  }
  .sha-designer-toolbar-left {
    display: none !important;
  }
`;
