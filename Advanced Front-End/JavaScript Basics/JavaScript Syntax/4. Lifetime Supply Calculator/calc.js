function calcSupply(age, maxAge, food, foodPerDay) {
    var lifeLeft = maxAge - age;
    var totalFood = foodPerDay * 365 * lifeLeft;

    console.log(totalFood + " kg. of " + food + " will be enough until I become " + maxAge + " years old.");
}

calcSupply(15, 85, "carrots", 2);
calcSupply(21, 33, "beans", 1);
calcSupply(47, 98, "cabbage", 2);
