function testContext() {
    console.log(this);
}

// Calling from the global scope. 'this' refers to the 'window' object
testContext();

// ------------------------- //

function testFunction() {
    testContext();
}

// Calling the function which contains 'testContext', and as far as I can see,
// 'this' again refers to the 'window' object
testFunction();

// ------------------------- //

var test = {
    someKey: testContext()
}

// 'this' refers to the object 'test' in this case
test;

