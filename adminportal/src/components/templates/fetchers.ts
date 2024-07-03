export const URLS = {
  GET_ALL_TEMPLATES: `/api/dynamic/Shesha.Tutorial/Template/Crud/GetAll`,
};

export function GetMember() {
  const queryString = window.location.search;
  const urlParams = new URLSearchParams(queryString);
  return urlParams.get("id");
}
