import { IAjaxResponse, useSheshaApplication } from "@shesha-io/reactjs";
import { Template } from "./model";
import axios from "axios";
import { URLS } from "./fetchers";
import useSWR from "swr";

export const useTemplates = () => {
  const { backendUrl, httpHeaders } = useSheshaApplication();

  const fetcher = () => {
    return axios
      .get<IAjaxResponse<Template>>(URLS.GET_ALL_TEMPLATES, {
        baseURL: backendUrl,
        headers: httpHeaders,
      })
      .then((res) => {
        const result = res.data.result;

        return result.items;
      });
  };

  return useSWR([URLS.GET_ALL_TEMPLATES, httpHeaders], fetcher, {
    refreshInterval: 0,
    revalidateOnFocus: false,
  });
};
