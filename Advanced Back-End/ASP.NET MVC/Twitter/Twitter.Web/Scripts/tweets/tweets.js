function loadReplyBox(id) {
    $.ajax({        
        url: '/tweets/postreply',
        data: { id: id }
    }).done(function (result) {
        $('#add-reply-' + id).replaceWith(result);
    })
}