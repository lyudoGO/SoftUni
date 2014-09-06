
function findMinAndMax (value) {
	var maxNumber = Math.max.apply(null, value);
	var minNumber = Math.min.apply(null, value);
	console.log("Min -> " + minNumber);
	console.log("Max -> " + maxNumber + "\n");
}

findMinAndMax([1, 2, 1, 15, 20, 5, 7, 31]);
findMinAndMax([2, 2, 2, 2, 2]);
findMinAndMax([500, 1, -23, 0, -300, 28, 35, 12]);
console.log("\n");	


