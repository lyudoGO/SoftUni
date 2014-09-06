
function findMaxSequence (value) {
	var counter = 0;
    var maxSequence = 0;
    var index = 0;
    
    for (var i = 0; i < value.length ; i++){
        counter = 1;
        var j = i+1;
        var k = i;

        while (value[k] < value[j]){
            counter++;
            j++;
            k++;
            if (j >= value.length){
                break;
            }
        }
        if (counter > maxSequence){
            maxSequence = counter;
            index = i;
        }
    };
    if(maxSequence < 2){
    	console.log("no");
    }else{
    	var sequence = value.slice(index, (index + maxSequence));
    	console.log(sequence);
    }
}

findMaxSequence([3, 2, 3, 4, 2, 2, 4]);
findMaxSequence([3, 5, 4, 6, 1, 2, 3, 6, 10, 32]);
findMaxSequence([3, 2, 1]);
findMaxSequence([20, 20, 20, 15, 10, 3, 3, 3, -5, -20, -50]);
console.log("\n");