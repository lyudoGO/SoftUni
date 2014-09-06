
function replaceSpaces(text)  {
	var newText = "";
	for (var i = 0; i < text.length; i++) {
		newText = newText + text[i].replace(" ", "");
	};
	//var reg = new RegExp(" ", "g");
	//var newText = text.replace(reg, "");
	console.log(newText);
}

replaceSpaces("But you were living in another world tryin' to get your message through");
replaceSpaces("No one heard a single word you said. They should have seen it in your eyes.");
replaceSpaces("But you were living in another world tryin' to get your message through.");
console.log("\n");