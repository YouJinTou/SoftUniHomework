function solve(input) {
    var result = {};
    var team = {};
    var goalsScored;
    var goalsConceded;
    var matchesPlayedWith = [];
    var pattern = /(\w+)\s*\/\s*(\w+):\s*(\d+)\s*-\s*(\d+)/;

    for (var i in input) {
        var match = pattern.exec(input[i]);
        team = match[1];
        opponent = match[2];
        goalsScored = parseInt(match[3]);
        goalsConceded = parseInt(match[4]);

        if (!result[team]) {
            result[team] = {}
        }
        if (!result[opponent]) {
            result[opponent] = {};
        }
        if (result[team].matchesPlayedWith.indexOf(opponent) == -1) {
            result[team].matchesPlayedWith.push(opponent);
        }
        if (result[opponent].matchesPlayedWith.indexOf(team) == -1) {
            result[opponent].matchesPlayedWith.push(team);
        }

        result[team] += goalsScored;
        result[opponent] += goalsScored;
        result[team] += goalsConceded;
        result[opponent] += goalsConceded;
    }

    console.log(JSON.stringify(result));
}

var input = [
'Germany / Argentina: 1-0',
'Brazil / Netherlands: 0-3',
'Netherlands / Argentina: 0-0',
'Brazil / Germany: 1-7',
'Argentina / Belgium: 1-0',
'France / Germany: 0-1',
'Brazil / Colombia: 2-1']

solve(input);