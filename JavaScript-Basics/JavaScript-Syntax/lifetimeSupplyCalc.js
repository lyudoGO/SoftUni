
function calcSupply () {
	var restLife = arguments[1] - arguments[0];
    var  foodEats = restLife * 365 * arguments[2];
    return foodEats + "kg of fruits would be enough until I am " + arguments[1] + 
    " years old.";
}
console.log(calcSupply(38, 118, 0.5));
console.log(calcSupply(20, 87, 2));
console.log(calcSupply(16, 102, 1.1));

