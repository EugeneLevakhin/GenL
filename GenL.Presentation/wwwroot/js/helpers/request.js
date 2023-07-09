export class Request {
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

        let url = new URL(path, location).toString();
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

        let json = JSON.stringify(object);
        let url = new URL(path, location).toString();
        this.httpRequest.open("POST", url);
        this.httpRequest.setRequestHeader("Content-Type", "application/json");

        this.httpRequest.send(json);
    }
}