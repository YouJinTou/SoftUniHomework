function isNumber(num) {
    if (!isNaN(num)) {
        return true;
    }
    return false;
}

function filterArray(input) {
    var filteredArray = input.filter(isNumber);
    return filteredArray;
}

function getMostFrequent(filteredArray) {
    var maxCount = 0;
    var currentCount = 0;
    var bestElement = 0;
    filteredArray.forEach(function (elem) {
        filteredArray.forEach(function (val) {
            if (elem === val) {
                currentCount++;

                if (currentCount > maxCount) {
                    maxCount = currentCount;
                    bestElement = elem;
                }
            }
        })
        currentCount = 0;
    })

    return bestElement;
}

function getValues(filteredArray) {
    var min = filteredArray.sort(function (x, y) {
        return x > y;
    })[0];
    var max = filteredArray.sort(function (x, y) {
        return x < y;
    })[0];
    var bestElement = getMostFrequent(filteredArray);

    console.log("Min: " + min);
    console.log("Max: " + max);
    console.log("Best element: " + bestElement);
}

getValues(filterArray(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount: 10 }, [10, 20, 30, 40]]));

getValues(filterArray([2, 3, 2, 1, 1, 0, -2, -3, -1, -1, -1, -1, "dagger", "eleemosynary"]));
