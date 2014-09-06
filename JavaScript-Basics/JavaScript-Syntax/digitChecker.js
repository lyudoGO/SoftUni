
function checkDigit (value) {
    var thirdDig = Math.floor(value / 100) % 10;
        return thirdDig == 3;
}
//read input from console - node.js
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
    prompts.question("Enter a number > 1000: ", function(number){
    console.log(checkDigit(number));
    prompts.close();
});


