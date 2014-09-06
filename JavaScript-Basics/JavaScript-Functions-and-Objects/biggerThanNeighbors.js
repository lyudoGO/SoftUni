function biggerThanNeighbors(index,  arr)   {
	var number = arr[index];
	if(index < 0 || index > arr.length - 1){
		console.log("invalid index");
	}else if(index == 0 || index == arr.length - 1){
		console.log("only one neighbor");
	}else if(number <= arr[index - 1] || number <= arr[index + 1]){
		console.log("not bigger");
	}else if(number > arr[index - 1] && number > arr[index + 1]){
		console.log("bigger");
	}

}
biggerThanNeighbors(2, [1, 2, 3, 3, 5]);
biggerThanNeighbors(2, [1, 2, 5, 3, 4]);
biggerThanNeighbors(5, [1, 2, 5, 3, 4]);
biggerThanNeighbors(0, [1, 2, 5, 3, 4]);
console.log("\n");