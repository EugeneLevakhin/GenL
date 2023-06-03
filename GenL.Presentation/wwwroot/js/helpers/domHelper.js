export { getElement };
export { $ };

var getElement = function (id) {
    return document.getElementById(id);
}

var $ = function (id) {
    return getElement(id);
};