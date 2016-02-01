function solve(input) {
    var ownerName, luggageName, isFood, isDrink, isFragile, weight, transferredWith, type;
    var result = {};
    var output = {};
    var currentLine;
    var splitPattern = /\.*\*\.*/g;
    var sortingCriterion = input[input.length - 1];

    for (var line in input) {
        if (line === (input.length - 1).toString()) {
            break;
        }

        currentLine = input[line].split(splitPattern);
        ownerName = currentLine[0];
        luggageName = currentLine[1];
        isFood = (currentLine[2] === 'true');
        isDrink = (currentLine[3] === 'true');
        isFragile = (currentLine[4] === 'true');
        weight = parseFloat(currentLine[5]);
        transferredWith = currentLine[6];

        if (isFood) {
            type = 'food';
        } else if (isDrink) {
            type = 'drink';
        } else {
            type = 'other';
        }

        if (!result[ownerName]) {
            result[ownerName] = {};
        }

        result[ownerName][luggageName] = {
            kg: weight,
            fragile: isFragile,
            type: type,
            transferredWith: transferredWith
        }
    }

    switch (sortingCriterion) {
        case 'luggage name':
            var outerKeys = {};
            Object.keys(result).forEach(function (key) {
                outerKeys[key] = {};

                var innerKeys = Object.keys(result[key]).sort();
                innerKeys.forEach(function (innerKey) {
                    outerKeys[key][innerKey] = result[key][innerKey];
                })
            })
            console.log(JSON.stringify(outerKeys));
            break;
        case 'weight':
            var outerKeys = {};
            Object.keys(result).forEach(function (key) {
                outerKeys[key] = {};

                var innerKeys = Object.keys(result[key]).sort(function (x, y) {
                    return result[key][x].kg > result[key][y].kg;
                });
                innerKeys.forEach(function (innerKey) {
                    outerKeys[key][innerKey] = result[key][innerKey];
                })
            })
            console.log(JSON.stringify(outerKeys));
            break;
        case 'strict':
            console.log(JSON.stringify(result));
        default:
            break;
    }
}

//var input = [
//    'Yana Slavcheva.*.clothes.*.false.*.false.*.false.*.2.2.*.backpack',
//    'Kiko.*.socks.*.false.*.false.*.false.*.0.2.*.backpack',
//    'Kiko.*.banana.*.true.*.false.*.false.*.3.2.*.backpack',
//    'Kiko.*.sticks.*.false.*.false.*.false.*.1.6.*.ATV',
//    'Kiko.*.glasses.*.false.*.false.*.true.*.3.*.ATV',
//    'Manov.*.socks.*.false.*.false.*.false.*.0.3.*.ATV',
//    'weight']

//solve(input);