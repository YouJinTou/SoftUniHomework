function calcExpression(exp) {
    var result = eval(exp);
    document.getElementById("result-field").innerHTML = result;
}