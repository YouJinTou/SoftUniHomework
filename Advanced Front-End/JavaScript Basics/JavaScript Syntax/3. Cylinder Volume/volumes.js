function calcCylinderVol(radius, height) {
    var volume = height * (Math.PI * Math.pow(radius, 2));
    console.log("Height: "
        + height + "\nRadius: " + radius + "\nVolume: " + volume);
}

for (var i = 0; i < 5; i++) {
    calcCylinderVol(1 + i, 2 + i);
}