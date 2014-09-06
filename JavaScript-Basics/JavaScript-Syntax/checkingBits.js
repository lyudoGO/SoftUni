
function calcSupply (value) {
	var bitAt3Position = value >> 3;
    if(bitAt3Position & 1 == 1){
        return true;
    }else{
        return false;
    }
}
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter a number: ", function(number){
	console.log(calcSupply(number));
	prompts.close();
});



