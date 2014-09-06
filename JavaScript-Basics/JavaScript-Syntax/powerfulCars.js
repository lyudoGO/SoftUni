
function convertKWtoHP (value) {
	var powerHP = value * 1.3596;
	console.log(powerHP);
}
//read input from console - node.js
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter power in KW: ", function(powerKW){
	convertKWtoHP(powerKW);
	prompts.close();
});



