function solve(input) {
    var start = parseInt(input[0]);
    var end = parseInt(input[1]);

    console.log('<ul>');
    for (var i = start; i <= end; i++) {
        if (!isRakiaNumber(i)) {
            console.log('<li><span class=\'num\'>' + i + '</span></li>');
        } else {
            console.log('<li><span class=\'rakiya\'>' + i + '</span><a href="view.php?id=' + i + '>View</a></li>');
        }        
    }
    console.log('</ul>');

    function isRakiaNumber(num) {
        var str = num.toString();
        for (var i = 0; i < str.length - 1; i++) {
            for (var j = i + 2; j < str.length - 1; j++) {
                if (str[i] === str[j] && str[i + 1] === str[j + 1]) {
                    return true;
                }
            }
        }
        return false;
    }
}

//var input = [
//    '11210',
//    '11215'
//]

//solve(input);