Object.prototype.flatten = function flatten() {
    return this.reduce(function (flat, toFlatten) {
        return flat.concat(Array.isArray(toFlatten) ? flatten(toFlatten) : toFlatten);
    }, []);
}

var array = [1, 2, [3, 4], [5, 6]];
console.log(array.flatten());
console.log(array);