function replaceATag(str) {
    var pattern = />(?=\w{0,}<\/a)/;
    str = String(str).replace(pattern, ']');
    str = String(str).replace('<a', '[URL');    
    str = String(str).replace('</a>', '[/URL]');

    console.log(str);
}

replaceATag('<ul><li><a href=http://softuni.bg>SoftUni</a></li></ul>');