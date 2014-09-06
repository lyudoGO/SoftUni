
function isPrime (value) {
	for (var i = 2; i <= Math.sqrt(value); i++) {
        if (value % i == 0) {
            return false;
        }
    }
    return true;
}
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter a number: ", function(number){
	console.log(isPrime(number));
	prompts.close();
});



