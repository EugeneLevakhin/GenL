export { Person };

class Person {
    static averageAge = 37;

    // can be uncommented
    //firstName;
    //lastName;
    //age;

    constructor(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    sayHello = function () {
        console.log(this.firstName + " says: Hello");
    }
}