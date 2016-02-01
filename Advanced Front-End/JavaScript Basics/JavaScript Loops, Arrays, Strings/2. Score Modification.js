function modifyScores(scores) {        
    var scoreList = scores.filter(function (score) {
        if (score >= 0 && score <= 400) {
            return true;
        }
    });

    var downscaledScores = scoreList.map(function (score) {
        score *= 0.8;
        return score;
    })

    var sortedScores = downscaledScores.sort(function (x, y) {
        return x < y;
    })
    
    console.log(sortedScores);
}

modifyScores([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]);