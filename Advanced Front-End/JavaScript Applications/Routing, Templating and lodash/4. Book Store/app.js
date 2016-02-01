function doOperations(input) {
    var groupLanguageSortAuthorPrice = _.chain(input)
    .groupBy('language')
    .sortBy('author')
    .value();
    console.log(groupLanguageSortAuthorPrice);
}

var input = [{ "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "34,24", "language": "French" },
{ "book": "The Great Gatsby", "author": "F. Scott Fitzgerald", "price": "39,26", "language": "English" },
{ "book": "Nineteen Eighty-Four", "author": "George Orwell", "price": "15,39", "language": "English" },
{ "book": "Ulysses", "author": "James Joyce", "price": "23,26", "language": "German" },
{ "book": "Lolita", "author": "Vladimir Nabokov", "price": "14,19", "language": "German" },
{ "book": "Catch-22", "author": "Joseph Heller", "price": "47,89", "language": "German" },
{ "book": "The Catcher in the Rye", "author": "J. D. Salinger", "price": "25,16", "language": "English" },
{ "book": "Beloved", "author": "Toni Morrison", "price": "48,61", "language": "French" },
{ "book": "Of Mice and Men", "author": "John Steinbeck", "price": "29,81", "language": "Bulgarian" },
{ "book": "Animal Farm", "author": "George Orwell", "price": "38,42", "language": "English" },
{ "book": "Finnegans Wake", "author": "James Joyce", "price": "29,59", "language": "English" },
{ "book": "The Grapes of Wrath", "author": "John Steinbeck", "price": "42,94", "language": "English" }]

doOperations(input);