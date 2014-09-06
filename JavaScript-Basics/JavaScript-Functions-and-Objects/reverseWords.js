function reverseWordsInString(str)  {
	var strArr = str.split(" ");
	var revArr = []; 
	for (var i = 0; i < strArr.length; i++) {
		revArr.push(reverseString(strArr[i]));
	};


	function reverseString(str) {
	  var strRev = '';
	  for (var i = str.length - 1; i >= 0; i--)
	        strRev += str[i];
	       return strRev;
	}
	console.log(revArr.join(" ")); 
}

reverseWordsInString("Hello, how are you.");
reverseWordsInString("Life is pretty good, isn’t it?");
//reverseWordsInString(5, [1, 2, 5, 3, 4]);
//reverseWordsInString(0, [1, 2, 5, 3, 4]);
console.log("\n");