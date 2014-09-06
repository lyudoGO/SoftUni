
function countSubstringOccur(arr)  {
	
	var text = arr[1];
	var keyword = arr[0];
	var reg = new RegExp(keyword, "gi");
	var count = text.match(reg);
	console.log(count.length);
	//console.log(count);
}

countSubstringOccur(["in", "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days."]);
countSubstringOccur(["your", "No one heard a single word you said. They should have seen it in your eyes. What was going around your head."]);
countSubstringOccur(['but', 'But you were living in another world tryin\' to get your message through.']);
console.log("\n");