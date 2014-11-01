var specialConsole = function () {

	var writeLineToConsole = function writeLineToConsole(){

		writeArgumentsToConsole("", arguments);
	}

	var writeErrorToConsole = function writeErrorToConsole(){

		writeArgumentsToConsole("Error: ", arguments);
	}

	var writeWarningToConsole = function writeWarningToConsole(){

		writeArgumentsToConsole("Warning: ", arguments);
	}

	function writeArgumentsToConsole(str, parameters){
		var result = parameters[0];

		if (parameters.length === 0) {
			if (str === "") {
				console.log();
			} else {
				console.log(str + result);
			};
		} else if(parameters.length === 1) {
			console.log(str + result.toString());
		} else {
			for (var i = 1; i < parameters.length; i++) {
				result = result.replace('{' + (i - 1) + '}', parameters[i].toString());
			};

			console.log(result.toString());
		};
	}

	return {
		writeLine: writeLineToConsole,
		writeError: writeErrorToConsole,
		writeWarning: writeWarningToConsole
	}

}();

specialConsole.writeLine();
specialConsole.writeLine("Message: hello");
specialConsole.writeLine("Message: {0}", "hello");
specialConsole.writeLine("Message: {0} {1} {2} {3}", 12, "malini,", 21, "kapini");

specialConsole.writeError();
specialConsole.writeError("Fatal error");
specialConsole.writeError("Error: {0}", "A fatal error has occurred.");

specialConsole.writeWarning();
specialConsole.writeWarning("Dangerous warning");
specialConsole.writeWarning("Warning: {0}", "You are not allowed to do that!");