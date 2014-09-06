
function roundNumber (value) {
	var num1 = Math.floor(value);
	var num2 = Math.round(value);
	console.log(num1);
	console.log(num2);
}
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter float number: ", function(number){
	roundNumber(number);
	prompts.close();
});



