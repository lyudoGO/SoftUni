function getArguments() {
	console.log("Number of arguments:", arguments.length);
	for (var i = 0; i < arguments.length; i++) {
		console.log("On position %s argument [%s] is of type: %s", i, arguments[i], typeof(arguments[i]));
	};

	console.log();
}

function printThisObject() {
	console.log("%s scope: this is %s", arguments[0], this.object);
}

getArguments();
getArguments(1, true, 3.56);
getArguments("mice", "tree", [1, 2, 3], ["one", "two", false]);

printThisObject("Function");
printThisObject.call({object: "OBJECT"}, "Object");
object = "GLOBAL";
printThisObject("Global");