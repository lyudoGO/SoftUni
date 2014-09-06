
function findPalindromes(text)  {
	var palindromes = [];
	var inputText = text.split(/[^a-zA-z]+/);
	for (var i = 0; i < inputText.length; i++) {
		var revStr = "";
		var str = inputText[i];

		for (var j = str.length - 1; j >= 0; j--) {
			revStr = revStr + str[j];
		};
		
		if(revStr.toLowerCase() === str.toLowerCase()){
			palindromes.push(str.toLowerCase());
		}
    };
    palindromes.pop();
    console.log(palindromes.join(", "));
}

findPalindromes("There is a man, his name was Bob.");
console.log("\n");
