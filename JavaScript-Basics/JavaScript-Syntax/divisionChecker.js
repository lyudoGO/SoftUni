
function divisionBy3 (value) {
	var sumDigits = 0;
	var tempNumber = String(value);
	
	for (var i = 0; i < tempNumber.length; i++) {
          sumDigits += Number(tempNumber);
    }
    if(sumDigits % 3 == 0){
    	return "the number is divided by 3 without remainder";
    }else{
    	return "the number is not divided by 3 without remainder";
    }
}
var readline = require("readline");
var prompts = readline.createInterface(process.stdin, process.stdout);
prompts.question("Enter a number > 9: ", function(number){
	console.log(divisionBy3(number));
	prompts.close();
});



