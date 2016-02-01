function add(num) {
    var sum = num;
    function innerAdd(anotherNum) {
        sum += anotherNum;
        return innerAdd;
    }

    innerAdd.toString = function () {
        return sum;
    }
    return innerAdd;
}

var addTwo = add(2);
console.log(addTwo(3)(5));