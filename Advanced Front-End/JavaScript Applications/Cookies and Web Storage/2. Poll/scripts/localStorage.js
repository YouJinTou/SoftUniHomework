(function toLocalStorage() {
    var radios,
        planet,
        human,
        ants;

    $('input[name="planet"]').on('change', function () {
        localStorage.setItem('planet', $('input[name="planet"]:checked').val());
    })
    $('input[name="human"]').on('change', function () {
        localStorage.setItem('human', $('input[name="human"]:checked').val());
    })
    $('input[name="ants"]').on('change', function () {
        localStorage.setItem('ants', $('input[name="ants"]:checked').val());
    })

    radios = $('input:radio');
    planet = localStorage.getItem('planet');
    human = localStorage.getItem('human');
    ants = localStorage.getItem('ants');
    for (var i = 0; i < radios.length; i++) {
        var iStr = i.toString();
        if (planet === iStr || human === iStr
            || ants === iStr) {
            radios[i].checked = true;
        }
    }
})();

