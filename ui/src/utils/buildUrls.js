const buildUrls = (url, version, route) => {
  return `${url}/api/${version}/${route}`;
};

export default buildUrls;
