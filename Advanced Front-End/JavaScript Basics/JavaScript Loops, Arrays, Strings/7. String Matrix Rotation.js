function solve(input) {
    var degrees = parseInt(input[0].substr(7)) % 360;
    var longest = 0;

    for (var i = 1; i < input.length; i++) {
        if (longest < input[i].length) {
            longest = input[i].length;
        }
    }

    var array = [];
    for (var i = 1; i < input.length; i++) {
        array[i - 1] = input[i].split('');
    }

    switch (degrees) {
        case 90:
            for (var i = 0; i < longest; i++) {
                var line = '';
                for (var j = array.length - 1; j >= 0; j--) {
                    if (array[j][i]) {
                        line += array[j][i];
                    } else {
                        line += ' ';
                    }
                }
                console.log(line);
            }
            break;
        case 180:
            for (var i = array.length - 1; i >= 0; i--) {
                var line = '';
                if (array[i].length < longest) {
                    var diff = longest - array[i].length;
                    for (var p = 0; p < diff; p++) {
                        line += ' ';
                    }
                }
                for (var j = array[i].length - 1; j >= 0; j--) {
                    line += array[i][j];
                }
                console.log(line);
            }
            break;
        case 270:
            for (var i = longest - 1; i >= 0; i--) {
                var line = '';
                for (var j = 0; j < array.length; j++) {
                    if (array[j][i]) {
                        line += array[j][i];
                    } else {
                        line += ' ';
                    }
                }
                console.log(line);
            }
            break;
        default:
            for (var i in array) {
                console.log(array[i].join(''));
            }
            break;
    }

}

//var input = [
//    'Rotate(270)',
//    'hello',
//    'softuni',
//    'exam']

//solve(input);