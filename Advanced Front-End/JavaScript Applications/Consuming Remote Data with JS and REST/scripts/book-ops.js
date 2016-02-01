(function () {
    var ID = 'EA3O1yyHjkVM3GW7vFYu0uLFTq1HE1HzBdx8XYqw';
    var REST_API_KEY = 'y1FXMSupNbiNbQzhH9M52yzHQ2rQIivWeL2TDaO6';
    var BOOK_URL = 'https://api.parse.com/1/classes/Book/';

    var bookTokens,
        currentTitle,
        title,
        titleEdit,
        author,
        authorEdit,
        isbn,
        isbnEdit,
        tags,
        tagsEdit,
        entry,
        option,
        books;

    $(document).ready(updateBooks)

    function updateBooks() {
        bookTokens = [];
        title = $('#title');
        author = $('#author');
        isbn = $('#isbn');
        tags = $('#tags');
        books = $('#books');

        $.ajax({
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            method: 'GET',
            url: BOOK_URL
        }).success(function (data) {
            for (var obj in data.results) {
                entry = data.results[obj];
                option = $('<option class="book">');
                option.text(entry['title']);
                option.appendTo(books);

                bookTokens.push({
                    title: entry['title'],
                    objectId: entry['objectId']
                })
            }
        })

        books.empty();
    }

    $('#add-button').on('click', function (event) {
        event.preventDefault();
        addBook();
        updateBooks();

        title.val('');
        author.val('');
        isbn.val('');
        tags.val('');
    })

    function addBook() {
        var tagsArray = tags.val().split(/\W+/g);

        $.ajax({
            method: 'POST',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY,
                'Content-Type': 'application/json'
            },
            url: BOOK_URL,
            data: JSON.stringify({
                'title': title.val(),
                'author': author.val(),
                'isbn': isbn.val(),
                'tags': tagsArray
            })
        })
    }

    $('#books').on('change', function () {
        currentTitle = $(this).val();
        var book = bookTokens.filter(function (book) {
            return book.title === currentTitle[0];
        });
        var objectId = book[0].objectId;

        titleEdit = $('#title-edit');
        authorEdit = $('#author-edit');
        isbnEdit = $('#isbn-edit');
        tagsEdit = $('#tags-edit');

        $.ajax({
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            method: 'GET',
            url: BOOK_URL + objectId
        }).success(function (data) {
            titleEdit.val(data.title);
            authorEdit.val(data.author);
            isbnEdit.val(data.isbn);
            tagsEdit.val(data.tags);
        })
    })

    $('#edit-button').on('click', function (event) {
        var book = bookTokens.filter(function (book) {
            return book.title === currentTitle[0];
        });
        var objectId = book[0].objectId;

        event.preventDefault();
        editBook(objectId);
        updateBooks();

        titleEdit.val('');
        authorEdit.val('');
        isbnEdit.val('');
        tagsEdit.val('');
    })

    function editBook(objectId) {
        if (!titleEdit.val())     {
            alert('Title cannot be empty');
            return;
        }

        var tagsArray = tagsEdit.val().split(/\W+/g);

        $.ajax({
            method: 'PUT',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY,
                'Content-Type': 'application/json'
            },
            url: BOOK_URL + objectId,
            data: JSON.stringify({
                'title': titleEdit.val(),
                'author': authorEdit.val(),
                'isbn': isbnEdit.val(),
                'tags': tagsArray
            })
        })
    }

    $('#delete').on('click', function (event) {
        var book = bookTokens.filter(function (book) {
            return book.title === currentTitle[0];
        });
        var objectId = book[0].objectId;

        event.preventDefault();
        deleteBook(objectId);
        updateBooks();

        titleEdit.val('');
        authorEdit.val('');
        isbnEdit.val('');
        tagsEdit.val('');
    })

    function deleteBook(objectId) {
        $.ajax({
            method: 'DELETE',
            headers: {
                'X-Parse-Application-Id': ID,
                'X-Parse-REST-API-Key': REST_API_KEY
            },
            url: BOOK_URL + objectId
        })
    }
})();