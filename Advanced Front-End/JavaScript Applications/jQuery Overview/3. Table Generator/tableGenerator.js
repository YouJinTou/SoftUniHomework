function generateTable(str) {
    var parsedJSON = $.parseJSON(str);
    var count = 0;

    $('body').append('<div id="wrapper"></div>');
    $('#wrapper').append('<table></table>');
    $('table').append('<thead>');
    $('thead').append('<tr id="head-row">');
    $('table').append('<tbody>');

    $.each(parsedJSON, function (key, value) {
        $('tbody').append('<tr id="' + count + '"</tr>');
        $.each(value, function (key, value) {
            if (count === 0) {
                $('#head-row').append('<td>' + key + '</td>');
            }                        
            $('#' + count).append('<td>' + value + '</td>');
        })
        count++;
    })
}

var string = '[{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},{"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}]'

generateTable(string);