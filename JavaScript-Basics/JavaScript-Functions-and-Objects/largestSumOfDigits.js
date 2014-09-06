function findLargestBySumOfDigits()  {
	var largSum = 0;
	var result = 0;
	for (var i = 0; i < arguments.length; i++) {
		if(arguments[i] !== parseInt(arguments[i])){
			return console.log(undefined);
		}else{
			var num = arguments[i].toString().replace("-","");
			var sum = 0;
			for (var j = 0; j < num.length; j++) {
				var dig = num[j];
				sum = sum + parseInt(dig);
			};
			if(sum >= largSum){
				largSum = sum;
				result = arguments[i];
			}
	    }
    };
	return console.log(result);
}

findLargestBySumOfDigits(5, 10, 15, 111);
findLargestBySumOfDigits(33, 44, -99, 0, 20);
findLargestBySumOfDigits('hello');
findLargestBySumOfDigits(5, 3.3);
console.log("\n");