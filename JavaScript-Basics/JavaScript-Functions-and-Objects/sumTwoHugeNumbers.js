
function sumTwoHugeNumbers(value)  {
	var BigInteger = require('./library/BigIntegers.js');
	var num1 = new BigInteger(value[0]);
	var num2 = new BigInteger(value[1]);
	var sum = new BigInteger(0);
	sum = num1.plus(num2);

	console.log(sum.toString());
}

sumTwoHugeNumbers(['155', '65']);
sumTwoHugeNumbers(['123456789', '123456789']);
sumTwoHugeNumbers(['887987345974539','4582796427862587']);
sumTwoHugeNumbers(['347135713985789531798031509832579382573195807','817651358763158761358796358971685973163314321']
);
console.log("\n");