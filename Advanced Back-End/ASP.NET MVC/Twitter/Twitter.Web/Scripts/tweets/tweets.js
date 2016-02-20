function checkVisibility(id) {
    var repliesControls = $('#tweet-replies-controls-' + id);

    if ($(repliesControls).is(":visible")) {
        $(repliesControls).hide("slow");
    } else {
        $(repliesControls).show("slow");
        loadReplyBox(id);
    }
}

function loadReplyBox(id) {
    $.ajax({        
        url: '/tweets/postreply',
        data: { id: id }
    }).done(function (result) {
        $('#add-reply-' + id).replaceWith(result);
    })
}

function postTweet(data) {
    $('.tweets-container').prepend(data.responseText);
}