export const findById = (wrapper, id) => {
  return wrapper.find(`#${id}`);
};

export const findBySelector = (wrapper, selector) => {
  return wrapper.find(selector);
};