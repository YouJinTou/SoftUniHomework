function printArgsInfo() {
    for (var argument in arguments) {
        console.log(arguments[argument] + " (" + typeof arguments[argument] + ")");
    }
}

printArgsInfo(2, 3, 2.5, -110.5564, false);