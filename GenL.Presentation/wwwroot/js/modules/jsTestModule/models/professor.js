export { Professor };
import { Person } from '../../../models/person.js';

class Professor extends Person {
    firstName = `Professor ${this.firstName} ${this.lastName}, ${this.age} years`;
}