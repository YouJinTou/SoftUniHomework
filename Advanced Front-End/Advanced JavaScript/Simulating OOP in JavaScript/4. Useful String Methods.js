String.prototype._startsWith = function _startsWith(substring) {
    for (var i = 0; i < substring.length; i++) {
        if (!(substring.charAt(i) === this.charAt(i))){
            return false;
        }
    }

    return true;
}

String.prototype._endsWith = function _endsWith(substring) {
    for (var i = this.length, j = substring.length; j >= 0; i--, j--) {
        if (!(substring.charAt(i) === this.charAt(i))) {
            return false;
        }
    }

    return true;
}

String.prototype.left = function left(count) {
    if (count > this.length) {
        return this;
    }

    var result = '';
    for (var i = 0; i < count; i++) {
        result += this.charAt(i);
    }

    return result;
}

String.prototype.right = function right(count) {
    if (count > this.length) {
        return this;
    }

    var result = '';
    var start = this.length - count;
    for (var i = start; i < this.length; i++) {
        result += this.charAt(i);
    }

    return result;
}

String.prototype.padLeft = function padLeft(count, character) {
    var result = '';
    var callee = this;

    (function () {
        for (var i = 0; i < count; i++) {
            if (character != null && character != undefined) {
                result += character;
            } else {
                result += ' ';
            }         
        }
        result += callee;
    })();

    return result;
}

String.prototype.padRight = function padRight(count, character) {
    var result = this;

    (function () {
        for (var i = 0; i < count; i++) {
            if (character != null && character != undefined) {
                result += character;
            } else {
                result += ' ';
            }
        }
    })();

    return result;
}

String.prototype._repeat = function _repeat(count) {
    var result = '';

    for (var i = 0; i < count; i++) {
        result += this;
    }

    return result;
}

var example = "This is an example string used only for demonstration purposes.";
console.log(example.startsWith("This"));
console.log(example.startsWith("this"));
console.log(example.startsWith("other"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.endsWith("poses."));
console.log(example.endsWith("example"));
console.log(example.startsWith("something else"));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.left(9));
console.log(example.left(90));

var example = "This is an example string used only for demonstration purposes.";
console.log(example.right(9));
console.log(example.right(90));

// Combinations must also work
var example = "abcdefgh";
console.log(example.left(5).right(2));

var hello = "hello";
console.log(hello.padLeft(5));
console.log(hello.padLeft(10));
console.log(hello.padLeft(5, "."));
console.log(hello.padLeft(10, "."));
console.log(hello.padLeft(2, "."));

var hello = "hello";
console.log(hello.padRight(5));
console.log(hello.padRight(10));
console.log(hello.padRight(5, "."));
console.log(hello.padRight(10, "."));
console.log(hello.padRight(2, "."));

var character = "*";
console.log(character.repeat(5));
// Alternative syntax
console.log("~".repeat(3));
// Another combination
console.log("*".repeat(5).padLeft(10, "-").padRight(15, "+"));
