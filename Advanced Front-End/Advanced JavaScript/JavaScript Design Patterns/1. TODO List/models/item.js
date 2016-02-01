var models = models || {};

(function (local) {
    var itemID = 0;
    function Item(content) {
        this.content = content;
        itemID++;
    }

    Item.prototype.addToDOM = function addToDOM(sectionID) {
        var parent = document.getElementById('list-' + sectionID);
        var liCheckbox = document.createElement('input');
        var liItem = document.createElement('li');        
        var itemValue = document.getElementById('item-value-' + sectionID).value;

        liCheckbox.setAttribute('type', 'checkbox');
        liCheckbox.setAttribute('class', 'checkbox');
        liItem.setAttribute('id', 'item');

        liItem.appendChild(liCheckbox);
        liItem.innerHTML += '<p>' + itemValue + '</p>';
        parent.appendChild(liItem);
    }

    local.Item = Item;
})(models)