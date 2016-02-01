var Person = function (firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    function get() {
        return this.firstName + " " + this.lastname;
    }
    function set(name) {
        var names = name.toString().split(' ');
        this.firstName = names[0];
        this.lastName = names[1];
    }
}

var person = new Person("Peter", "Jackson");
// Getting values
console.log(person.firstName);
console.log(person.lastName);
console.log(person.fullName);
// Changing values
person.firstName = "Michael";
console.log(person.firstName);
console.log(person.fullName);
person.lastName = "Williams";
console.log(person.lastName);
console.log(person.fullName);
// Changing the full name should work too
person.fullName = "Alan Marcus";
console.log(person.fullName);
console.log(person.firstName);
console.log(person.lastName);

