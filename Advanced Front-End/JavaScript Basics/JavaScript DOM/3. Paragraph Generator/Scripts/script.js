function createParagraph(id, text) {
    var wrapper = document.getElementById(id);
    var childNode = document.createElement("p");
    childNode.innerHTML = text;

    wrapper.appendChild(childNode);
}

createParagraph('wrapper', 'Some text');