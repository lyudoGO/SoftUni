
function evenNumber (value) {
	if(value % 2 == 0){
		console.log(true);
	}
	else{
		console.log(false);
	}
}
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter a number: ", function(number){
	evenNumber(number);
	prompts.close();
});



