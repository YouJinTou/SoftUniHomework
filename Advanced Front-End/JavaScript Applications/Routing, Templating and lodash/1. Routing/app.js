(function (undefined) {
    var app = Sammy(function () {
        var selector = $('#content h2');       

        this.get('#/Alice', function () {
            selector.html('Hello, Alice!');
        });

        this.get('#/Bob', function () {
            selector.html('Hello, Bob!');
        });

        this.get('#/Eve', function () {
            selector.html('Hello, Eve!');
        });
    })

    app.run('#/');
})();

