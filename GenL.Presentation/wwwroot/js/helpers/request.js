export { Request };

class Request {
    constructor(responseCallback) {
        this.httpRequest = new XMLHttpRequest();
        this.responseCallback = responseCallback;
    }

    get(path) {
        this.httpRequest.onreadystatechange = () => {
            if (this.httpRequest.readyState == XMLHttpRequest.DONE) {
                if (this.responseCallback) {
                    this.responseCallback(this.httpRequest.responseText);
                }
            }
        }

        var url = new URL(path, location).toString();
        this.httpRequest.open("GET", url);

        this.httpRequest.send();
    }

    post(path, object) {
        this.httpRequest.onreadystatechange = () => {
            if (this.httpRequest.readyState == XMLHttpRequest.DONE) {
                if (this.responseCallback) {
                    this.responseCallback(this.httpRequest.responseText);
                }
            }
        }

        var json = JSON.stringify(object);
        var url = new URL(path, location).toString();
        this.httpRequest.open("POST", url);
        this.httpRequest.setRequestHeader("Content-Type", "application/json");

        this.httpRequest.send(json);
    }
}