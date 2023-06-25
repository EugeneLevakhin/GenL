import { Person } from '../../../models/person.js';

export class Professor extends Person {
    firstName = `Professor ${this.firstName} ${this.lastName}, ${this.age} years`;
}