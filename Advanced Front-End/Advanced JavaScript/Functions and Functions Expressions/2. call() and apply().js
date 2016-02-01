function printArgsInfo() {
    for (var argument in arguments) {
        console.log(arguments[argument] + " (" + typeof arguments[argument] + ")");
    }
}

printArgsInfo.call(null);
printArgsInfo.call(null, 2, 3, 2.5, -110.5564, false);
printArgsInfo.apply(null);
printArgsInfo.apply(null, [2, 3, 2.5, -110.5564, false]);
