var models = models || {};

(function (local) {
    function Container(title) {
        this.title = title;
    }

    Container.prototype.addToDOM = function addToDOM() {
        var parent = document.querySelector('#wrapper');
        var container = document.createElement('div');
        var titleH1 = document.createElement('h1');
        var sections = document.createElement('div');
        var footer = document.createElement('footer');
        var sectiontTitle = document.createElement('input');
        var newSectionButton = document.createElement('button');

        container.setAttribute('id', 'container');
        titleH1.innerHTML = this.title;
        sections.setAttribute('id', 'sections');
        footer.setAttribute('id', 'container-footer');
        sectiontTitle.setAttribute('type', 'text');
        sectiontTitle.setAttribute('id', 'section-title');
        sectiontTitle.setAttribute('placeholder', 'Title...');
        newSectionButton.setAttribute('id', 'add-section-button');
        newSectionButton.innerHTML = 'New Section';

        container.appendChild(titleH1);
        container.appendChild(sections);
        container.appendChild(footer);

        footer.appendChild(sectiontTitle);
        footer.appendChild(newSectionButton);

        parent.appendChild(container);

        container.addEventListener('change', function (event) {
            if (event.target.classList.contains('checkbox')) {
                var li = event.target.nextElementSibling;
                if (event.target.checked) {                                       
                    li.style.backgroundColor = '#66ff66';
                } else {
                    li.style.backgroundColor = 'white';
                }               
            }
        })
    }

    local.Container = Container;
})(models)