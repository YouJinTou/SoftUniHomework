var HTMLGenerator = {
    'paragraph': function createParagraph(id, text) {
        var element = document.getElementById(id);
        var childNode = document.createElement('p');

        childNode.innerHTML = text;
        element.appendChild(childNode)
    },
    'div' : function createDiv(id, _class){
        var element = document.getElementById(id);
        var childNode = document.createElement('div');
        childNode.className = _class;

        element.appendChild(childNode);
    },
    'link': function createLink(id, text, url) {
        var element = document.getElementById(id);
        var childNode = document.createElement('a');
        childNode.href = url;
        childNode.textContent = text;

        element.appendChild(childNode);
    }
}

HTMLGenerator.paragraph('wrapper', 'Soft Uni');
HTMLGenerator.div('wrapper', 'section');
HTMLGenerator.link('book', 'C# basics book', 'http://www.introprogramming.info/');
