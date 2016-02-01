function doOperations(input) {
    var age18to24 = _.filter(input, function (obj) {
        return obj.age >= 18 && obj.age <= 24;
    })

    var firstNameBeforeLastName = _.filter(input, function (obj) {
        return obj.firstName < obj.lastName;
    })

    var studentsFromBulgaria = _.filter(input, function (obj) {
        return obj.country === 'Bulgaria';
    })

    var lastFiveStudents = _.takeRight(input, 5);

    // Chaining does not work for me in this instance
    //var firstThreeMalesNonBulgarian = _.chain(input)
    //.reject(obj => obj.country === 'Bulgaria')
    //.filter(obj => obj.gender === 'Male')
    //.take(3);

    var allNonBulgarian = _.reject(input, function (obj) {
        return obj.country === 'Bulgaria';
    });
    var allMales = _.filter(allNonBulgarian, function (obj) {
        return obj.gender === 'Male';
    })
    var firstThreeMalesNonBulgarian = _.take(allMales, 3);

    console.log(age18to24);
    console.log(firstNameBeforeLastName);
    console.log(studentsFromBulgaria);
    console.log(lastFiveStudents);
    console.log(firstThreeMalesNonBulgarian);
}

var input = [{ "gender": "Male", "firstName": "Joe", "lastName": "Riley", "age": 22, "country": "Russia" },
{ "gender": "Female", "firstName": "Lois", "lastName": "Morgan", "age": 41, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Roy", "lastName": "Wood", "age": 33, "country": "Russia" },
{ "gender": "Female", "firstName": "Diana", "lastName": "Freeman", "age": 40, "country": "Argentina" },
{ "gender": "Female", "firstName": "Bonnie", "lastName": "Hunter", "age": 23, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Joe", "lastName": "Young", "age": 16, "country": "Bulgaria" },
{ "gender": "Female", "firstName": "Kathryn", "lastName": "Murray", "age": 22, "country": "Indonesia" },
{ "gender": "Male", "firstName": "Dennis", "lastName": "Woods", "age": 37, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Billy", "lastName": "Patterson", "age": 24, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Willie", "lastName": "Gray", "age": 42, "country": "China" },
{ "gender": "Male", "firstName": "Justin", "lastName": "Lawson", "age": 38, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Ryan", "lastName": "Foster", "age": 24, "country": "Indonesia" },
{ "gender": "Male", "firstName": "Eugene", "lastName": "Morris", "age": 37, "country": "Bulgaria" },
{ "gender": "Male", "firstName": "Eugene", "lastName": "Rivera", "age": 45, "country": "Philippines" },
{ "gender": "Female", "firstName": "Kathleen", "lastName": "Hunter", "age": 28, "country": "Bulgaria" }]

doOperations(input);