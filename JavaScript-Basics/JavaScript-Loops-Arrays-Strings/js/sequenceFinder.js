
function findMaxSequence (value) {
	var maxLength = 1;
	var element = value[0];
	var tempLength = 1;
	for (var i = 1; i < value.length; i++) {
		if(value[i-1] === value[i]){
			tempLength++;
			if(tempLength >= maxLength){
				maxLength = tempLength;
				element = value[i];
			}
		}else{
			tempLength = 1;
		}
	}
	var sequence = [];
	for(var i = 0; i < maxLength; i++){
		sequence.push(element);
	}
	console.log(sequence);
}

findMaxSequence([2, 1, 1, 2, 3, 3, 2, 2, 2, 1]);
findMaxSequence(['happy']);
findMaxSequence([2, 'qwe', 'qwe', 3, 3, '3']);
findMaxSequence([20, 20, 20, 'aaa', 'aaa', 33, 33, 33, '33', 20, '33']);
console.log("\n");