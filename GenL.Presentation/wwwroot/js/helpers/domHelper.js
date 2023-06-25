export { getElement, $ };

var getElement = function (id) {
    return document.getElementById(id);
}

var $ = function (id) {
    return getElement(id);
};

export function log(message) {
    console.log(message);
} 