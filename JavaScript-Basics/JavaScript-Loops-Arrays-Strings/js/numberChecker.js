
function printNumbers (n) {
	var numbers = [];
	var sloveProblem = false;
    for (var i = 1; i <= n; i++) {
    	if((i % 4) != 0 && (i % 5) != 0){
    		numbers.push(i);
       		sloveProblem = true;
    	};
    };
    if(sloveProblem){
    	console.log(numbers.toString());
    }else
    {
    	console.log("no");
    };
}

printNumbers(20);
printNumbers(-5);
printNumbers(13);
console.log("\n");
