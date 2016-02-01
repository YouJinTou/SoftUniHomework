function insertBefore(element, insertee) {
    if (element) {
        var insertedElement = $('<' + insertee + '>');
        $(element).before(insertedElement);
    } else {
        throw Error("Argument not an HTML element.");
    }    
}

function insertAfter(element, insertee) {
    if (element) {
        var insertedElement = $('<' + insertee + '>');
        $(element).after(insertedElement);
    } else {
        throw Error("Argument not an HTML element.");
    }
}