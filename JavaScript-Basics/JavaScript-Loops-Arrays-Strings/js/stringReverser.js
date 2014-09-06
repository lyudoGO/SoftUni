
function reverseString(value)  {
	var str = "";
	for (var i = value.length - 1; i >= 0; i--) {
		str = str + value[i];
	};
	console.log(str);
}

reverseString('sample');
reverseString('softUni');
reverseString('java script');
reverseString('Problem 10.Reverse String');
console.log("\n");