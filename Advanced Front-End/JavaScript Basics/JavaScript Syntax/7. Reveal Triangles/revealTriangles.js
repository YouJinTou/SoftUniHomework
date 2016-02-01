function solve(input) {
    var result = [];
    for (var i in input) {
        result[i] = input[i].split('');
    }

    for (var i = 0; i < input.length; i++) {
        if (i === input.length - 1) {
            break;
        }

        for (var letter = 0; letter < input[i].length; letter++) {
            if (letter === 0) {
                continue;
            }
            if (letter === input[i].length - 1
                && input[i + 1].length - 1 <= letter) {
                continue;
            }

            var current = input[i][letter];
            var samePos = input[i + 1][letter];
            var nextPos = input[i + 1][letter + 1];
            var prevPos = input[i + 1][letter - 1];

            if (current === samePos && current === nextPos
                && current === prevPos) {
                result[i][letter] = '*';
                result[i + 1][letter] = '*';
                result[i + 1][letter + 1] = '*';
                result[i + 1][letter - 1] = '*';
            }
        }
    }

    for (var i in result) {
        console.log(result[i].join(''));
    }
}

//var input = [
//    'abcdexgh',
//    'bbbdxxxh',
//    'abcxxxxx']

//solve(input);