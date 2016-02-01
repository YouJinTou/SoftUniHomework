function scaleGrades(input) {
    var result = [];

    for (var key in input) {
        input[key].score *= 1.1;
        if (input[key].score >= 100) {
            input[key]["hasPassed"] = true;
        } else {
            input[key]["hasPassed"] = false;
        }        
    }

    result = input.filter(function (student) {
        return student.hasPassed;
    })

    result.sort(sortAlphabetically("name"));

    console.log(result);

    function sortAlphabetically(prop) {
        return function (a, b) {
            if (a[prop] > b[prop]) {
                return 1;
            } else if (a[prop] < b[prop]) {
                return -1;
            }
            else {
                return 0;
            }
        }
    }
}

var input = [
    {
        'name': 'Пешо',
        'score': 91
    },
    {
        'name': 'Лилия',
        'score': 290
    },
    {
        'name': 'Алекс',
        'score': 343
    },
    {
        'name': 'Габриела',
        'score': 400
    },
    {
        'name': 'Жичка',
        'score': 70
    }
]

scaleGrades(input);