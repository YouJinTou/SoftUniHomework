// The event listener for adding a section is located here.
// The event listeners for adding a new item and for changing
// the color are in item.js and container.js, respectively.

(function () {
    var container = new models.Container('Generic To-do List');
    container.addToDOM();

    var newSectionButton = document.getElementById('add-section-button');    

    newSectionButton.addEventListener('click', function (event) {
        var sectionTitle = document.getElementById('section-title');
        var newSection = new models.Section(sectionTitle.value);

        newSection.addToDOM();        
        sectionTitle.value = '';        
    })    
})()