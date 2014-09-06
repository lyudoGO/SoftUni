
function compareChars (value) {
	var sloveProblem = true;
	for(var i = 0; i < value[0].length; i++){
		if(value[0][i] != value[1][i]){
			sloveProblem = false;
		};
	};
	if(sloveProblem){
		console.log("Equal");
	}else{
		console.log("Not Equal");
	};
}

compareChars([['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q'],
 ['1', 'f', '1', 's', 'g', 'j', 'f', 'u', 's', 'q']]);
compareChars([['3', '5', 'g', 'd'], ['5', '3', 'g', 'd']]);
compareChars([['q', 'g', 'q', 'h', 'a', 'k', 'u', '8', '}', 'q', '.', 'h', '|', ';'],
['6', 'f', 'w', 'q', ':', '”', 'd', '}', ']', 's', 'r']]);
console.log("\n");