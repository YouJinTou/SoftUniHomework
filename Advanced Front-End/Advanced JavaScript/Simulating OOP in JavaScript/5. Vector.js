function Vector(components) {
    if (!components) {
        throw "Components not defined.";
    }
    this.components = components;
}

Vector.prototype = {
    toString: function toString() {
        var result = '(';

        for (var i = 0; i < this.length; i++) {
            if (i === this.length - 1) {
                result += this[i] + ')';
                break;
            }
            result += this[i] + ', ';
        }

        return result;
    },
    add: function add(other) {
        if (this.length !== other.length) {
            throw "Cannot sum vectors of different dimensions.";
        }

        var result = new Vector([]);
        for (var i = 0; i < this.length; i++) {
            result[i] = this[i] + other[i];
        }

        return result;
    }
}

var a = new Vector([1, 2, 3]);
var b = new Vector([4, 5, 6]);
var result = a.add(b);

console.log(a.toString());
console.log(result.toString());

