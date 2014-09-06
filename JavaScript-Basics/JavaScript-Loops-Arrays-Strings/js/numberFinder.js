
function findMostFreqNum(value)  {
	var maxCount = 0;
	var mostFrNum = 0;
	var currentCount = 1;
	for (var i = 0; i < value.length - 1; i++) {
	    for (var j = 1; j < value.length; j++) {
	    	if(value[i] == value[j]){
	    	currentCount++;
	        }
	     };   
    	if(maxCount < currentCount){
    		maxCount = currentCount;
    		mostFrNum = value[i];
    	}
	    currentCount = 0;
	};  
	console.log("%s (%s times)", mostFrNum, maxCount);   
}

findMostFreqNum([4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3]);
findMostFreqNum([2, 1, 1, 5, 7, 1, 2, 5, 7, 3, 87, 2, 12, 634, 123, 51, 1]);
findMostFreqNum([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]);
findMostFreqNum([20, 20, 20, 15, 10, 3, 3, 3, -5, -20, -50]);
console.log("\n");