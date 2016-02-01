function findYoungestPerson(array) {
    var bestAge = Number.MAX_VALUE;
    var bestIndex = 0;

    for (var person in array) {
        if (array[person].hasSmartphone) {
            if (array[person].age < bestAge) {
                bestAge = array[person].age;
                bestIndex = person;
            }
        }
    }

    console.log("The youngest person is", array[bestIndex].firstname, array[bestIndex].lastname);
}

var people = [
  { firstname: 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
  { firstname: 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
  { firstname: 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
  { firstname: 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }]


findYoungestPerson(people);