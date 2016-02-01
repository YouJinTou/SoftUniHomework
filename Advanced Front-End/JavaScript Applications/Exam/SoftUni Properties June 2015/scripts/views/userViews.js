var app = app || {};

app.userViews = (function () {
    function UserViews() { }

    //$.get() does not work
    UserViews.prototype.loadWelcomeGuestScreen = function (selector) {
        $.get("templates/welcome-guest-screen.html", function (template) {
            var output = Mustache.render(template);
            $(selector).html(output);
        });
    };

    return {
        load: function () {
            return new UserViews();
        }
    }
})();