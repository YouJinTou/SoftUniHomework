function extractObjects(array) {
    var filteredArray = [];
    for (var i = 0; i < array.length; i++) {
        if (!Array.isArray(array[i]) && (array[i] instanceof Object)) {
            filteredArray.push(array[i]);
        }
    }

    return filteredArray;
}

var extracted = extractObjects([
    "Pesho",
    4,
    4.21,
    { name: 'Valyo', age: 16 },
    { type: 'fish', model: 'zlatna ribka' },
    [1, 2, 3],
    "Gosho",
    { name: 'Penka', height: 1.65 }
]
)

console.log(JSON.stringify(extracted));