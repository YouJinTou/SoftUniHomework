$(document).ready(function () {

    $('.slideshow').not(':first').hide();

    setInterval(function () {
        $('.slideshow:first')
            .fadeOut(1250)
            .next()
            .fadeIn(1250)
            .end()
            .appendTo('#wrapper');        
    }, 5000);

    $('#next').on('click', function () {
        $('.slideshow').filter(function () {
            return $(this).css('display') != 'none';
        }).first().fadeOut(1250).next().fadeIn(1250);
    });

    $('#previous').on('click', function () {
        $('.slideshow').filter(function () {
            return $(this).css('display') != 'none';
        }).first().fadeOut(1250).prev().fadeIn(1250);
    });
})


