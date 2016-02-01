function sortLetters(string, boolean) {
    if (boolean === true) {
        var charArray = string.split('');
        var ascendingStr = charArray.sort(function (x, y) {
            x = x.toUpperCase();
            y = y.toUpperCase();
            return x < y;
        }).join('');

        return ascendingStr;
    }
    else {
        var charArray = string.split('');
        var descendingStr = charArray.sort(function (x, y) {
            x = x.toUpperCase();
            y = y.toUpperCase();
            return x > y;
        }).join('');

        return descendingStr;
    }
}

var sortedStringAscending = sortLetters('HelloWorld', true);
console.log(sortedStringAscending);
var sortedStringDescending = sortLetters('HelloWorld', false);
console.log(sortedStringDescending);