
function calcCylinderVol () {
    var volume = arguments[0] * arguments[0] * Math.PI * arguments[1];
    return volume.toFixed(3);
}
console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));

