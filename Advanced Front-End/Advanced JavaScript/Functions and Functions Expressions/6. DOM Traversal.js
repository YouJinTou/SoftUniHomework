function traverseDFS(node, spacing) {
    var children = node.childNodes;

    spacing = spacing || ' ';
    if (node.id) {
        console.log(node.nodeName + ": " + "id=" + node.id + ", class=" + node.className);
    } else {
        console.log(node.nodeName + ": " + " class=" + node.className);
    }    
    
    for (var i = 0; i < children.length; i++) {
        var child = children[i];
        if (child.nodeType === document.ELEMENT_NODE) {
            traverseDFS(children[i], spacing + " ");
        }
    }
}

var root = document.querySelector(".birds");
traverseDFS(root, "");


