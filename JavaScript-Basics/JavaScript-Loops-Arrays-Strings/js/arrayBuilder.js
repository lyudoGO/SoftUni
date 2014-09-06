
function createArray (value) {
	for (var i = 0; i < 20; i++) {
		value.push(i / 5);
	};
	var result = value.join(", ");
	console.log(result);
}

createArray([]);
console.log("\n");
