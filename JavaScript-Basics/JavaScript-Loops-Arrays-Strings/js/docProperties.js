
function displayProperties () {
	 var properties = [];

    for (var p in window) {
        properties.push(p);
    }

    properties.sort();

    document.getElementById("target").innerHTML = properties.join('; ');
}

displayProperties();
console.log("Look in browser");
console.log("\n");

