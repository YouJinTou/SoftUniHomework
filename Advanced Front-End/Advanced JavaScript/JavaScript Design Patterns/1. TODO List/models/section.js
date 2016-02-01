var models = models || {};

(function (local) {
    var sectionID = 0;
    function Section(title) {
        this.title = title;
        sectionID++;
    }

    Section.prototype.addToDOM = function addToDOM() {
        var parent = document.querySelector('#sections');
        var section = document.createElement('section');
        var sectionList = document.createElement('ul');
        var sectionTitle = document.createElement('h2');
        var sectionFooter = document.createElement('footer');
        var itemInput = document.createElement('input');
        var newItemButton = document.createElement('button');

        section.setAttribute('class', 'section');
        sectionList.setAttribute('id', 'list-' + sectionID);
        sectionTitle.innerHTML = this.title;
        sectionFooter.setAttribute('id', 'section-footer');
        itemInput.setAttribute('type', 'text');
        itemInput.setAttribute('id', 'item-value-' + sectionID);
        itemInput.setAttribute('placeholder', 'Add item...');
        newItemButton.setAttribute('id', 'add-item-button-' + sectionID)
        newItemButton.innerHTML = '+';

        section.appendChild(sectionTitle);
        section.appendChild(sectionList);
        section.appendChild(sectionFooter);
        sectionFooter.appendChild(itemInput);
        sectionFooter.appendChild(newItemButton);

        parent.appendChild(section);

        newItemButton.addEventListener('click', function (event) {
            var newItem = new models.Item(itemInput.value);
            var length = event.target.id.length - 1;
            var currentSection = event.target.id[length];

            newItem.addToDOM(currentSection);
            itemInput.value = '';
        })
    }

    local.Section = Section;
})(models)