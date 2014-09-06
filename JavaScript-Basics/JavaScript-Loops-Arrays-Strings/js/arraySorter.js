
function sortArray(value)  {
	var sortArr = [];
     for (var i = 0; i < value.length; i++) {
			var min = i;
			for (var j = i + 1; j < value.length; j++) {
			     if(value[j] < value[min]){
			     	min = j;
			     }
			};
			//using temp variable
			// var tempElement = value[i];
			// value[i] = value[min];
			// value[min] = tempElement;  

			//using second array
			sortArr[i] = value[min];
			value[min] = value[i]; 	
      }; 
     //console.log(value.join(", "));                 
     console.log(sortArr.join(", "));       
}

sortArray([5, 4, 3, 2, 1]);
sortArray([12, 12, 50, 2, 6, 22, 51, 712, 6, 3, 3]);
sortArray([3, 2, 1]);
sortArray([20, 20, 20, 15, 10, 3, 3, 3, -5, -20, -50]);
console.log("\n");