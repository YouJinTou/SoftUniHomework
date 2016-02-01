function solve(input) {
    var result = {};

    for (var i in input) {
        var elements = input[i].split('|');
        var band = elements[0].trim();
        var city = elements[1].trim();
        var date = elements[2].trim();
        var stadium = elements[3].trim();

        if (!result[city]) {
            result[city] = {};
        }
        if (!result[city][stadium]) {
            result[city][stadium] = [];
        }
        if (result[city][stadium].indexOf(band) === -1) {
            result[city][stadium].push(band);
        }

        result = sortInformation(result);
        for (var town in result) {
            result[town] = sortInformation(result[town]);
            for (var stadium in result[town]) {
                result[town][stadium].sort();
            }
        }

        function sortInformation(object) {
            var sortedKeys = Object.keys(object).sort();
            var sortedResult = {};
            for (var i = 0; i < sortedKeys.length; i++) {
                var key = sortedKeys[i];
                sortedResult[key] = object[key];
            }

            return sortedResult;
        }        
    }

    console.log(JSON.stringify(result));
}

//var input = ['ZZ Top | London | 2-Aug-2014 | Wembley Stadium',
//'Iron Maiden | London | 28-Jul-2014 | Wembley Stadium',
//'Metallica | Sofia | 11-Aug-2014 | Lokomotiv Stadium',
//'Helloween | Sofia | 1-Nov-2014 | Vassil Levski Stadium',
//'Iron Maiden | Sofia | 20-June-2015 | Vassil Levski Stadium',
//'Helloween | Sofia | 30-July-2015 | Vassil Levski Stadium',
//'Iron Maiden | Sofia | 26-Sep-2014 | Lokomotiv Stadium',
//'Helloween | London | 28-Jul-2014 | Wembley Stadium',
//'Twisted Sister | London | 30-Sep-2014 | Wembley Stadium',
//'Metallica | London | 03-Oct-2014 | Olympic Stadium',
//'Iron Maiden | Sofia | 11-Apr-2016 | Lokomotiv Stadium',
//'Iron Maiden | Buenos Aires | 03-Mar-2014 | River Plate Stadium']

//solve(input);