import { getElement, $ } from '../../helpers/domHelper.js';
import { Request } from '../../helpers/request.js';
import { Person } from '../../models/person.js';
import { Professor } from './models/professor.js';
import { Colors } from '../constants/colors.js';

var counter = 0;
var intervalMs = 100;
var intervalTimer;

window.onload = function () {
    $("startButton").onclick = startButtonOnClick;
    $("stopButton").onclick = stopButtonOnClick;
    $("getResponseButton").onclick = getResponseButtonOnClick;
    $("postButton").onclick = postButtonOnClick;
}

function startButtonOnClick(event) {
    intervalTimer = setInterval(tickHandler, intervalMs);
}

function stopButtonOnClick(event) {
    clearInterval(intervalTimer);
    counter = 0;
}

function tickHandler() {
    $("output").innerHTML = counter;
    counter++;
}

function getResponseButtonOnClick(event) {
    // 1st variant:
    //var request = new Request(responseHandler);

    // 2nd variant:
    //var request = new Request(function responseHandler(response) {
    //});

    // 3rd variant:
    var request = new Request((response) => {
        var users = JSON.parse(response);

        var usersString = "";
        for (var i = 0; i < users.length; i++) {
            var person = new Person(users[i].firstName, users[i].lastName);
            var splitter = ", ";
            if (i >= users.length - 1) {
                splitter = "";
            }

            usersString += person.firstName + splitter;
        }

        $("usersOutput").innerHTML = usersString;
    });

    request.get("/api/jstest/users");
}

function postButtonOnClick(event) {
    //example: create object inline, without specify type
    //var person = {
    //    firstName: $("nameTxt").value,
    //    lastName: "",
    //    age: $("ageInput").value,
    //    sayHello: function () {
    //        console.log(this.firstName + " says: Hello");
    //    }
    //};

    //person.sayHello();

    //var myobj = JSON.parse(JSON.stringify(obj));

    var person = new Person($("nameTxt").value, "", $("ageInput").value);
    person.sayHello();

    var request = new Request(responseHandler);
    request.post("/api/jstest/users/add", person);
}

function responseHandler(response) {
    // if 200 - response - empty string ''
    // if bad request - response - string -
    //'{
    //    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    //    "title": "Bad Request",
    //    "status": 400,
    //    "traceId": "00-caa0f98a59f6960995147f93dd4b5dc9-215514908a2f8ff5-00"
    //}'

    var person = Object.assign(new Person, JSON.parse(response));

    alert("Average persons age: " + Person.averageAge);
    alert(`Name: ${person.firstName}, Age: ${person.age}`);
    alert(`Color: ${Colors.back}`);

    alert("Average professors age: " + Professor.averageAge);
    var professor = new Professor(person.firstName, "", person.age);
    alert(professor.firstName);
    professor.sayHello();
}