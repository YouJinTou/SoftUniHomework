function createTable(arr) {
    var start = arr[0];
    var end = arr[1];

    function isFib(num) {
        var prev = 0;
        var current = 1;

        while (prev <= num) {
            if (num === prev) {
                return "yes";
            }

            current += prev;
            prev = current - prev;
        }
        return "no";
    }

    var table = "<table>\n<tr><th>Num</th><th>Square</th><th>Fib</th></tr>\n";
    for (var i = start; i <= end; i++) {
        var row = "<tr><td>" + i + "</td><td>" + i * i + "</td><td>" + isFib(i) + "</td></tr>\n";
        table += row;
    }
    table += "</table>";
    console.log(table);
}