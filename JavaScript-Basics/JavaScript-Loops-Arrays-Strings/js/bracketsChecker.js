
function breckBrackets(value)  {
	var brackets = 0;
    for (var br in value) {
        if (value[br] == '(') {
            brackets++;
        }
        else if (value[br] == ')') {
            brackets--;
        }

        if (brackets < 0) {
            break;
        }
    }
    if (brackets == 0) {
       return console.log("correct");
    }
    else {
        return console.log("incorrect");
    }
 	// var leftBrackets = 0;
 	// var rightBrackets = 0;
 	// for (var i = 0; i < value.length; i++) {
 	// 	if(value[i] == "("){
 	// 		leftBrackets++;
 	// 	}else if(value[i] == ")"){
 	// 		rightBrackets++;
 	// 	}
 	// };
 	// if(leftBrackets === rightBrackets){
 	// 	return console.log("correct");
 	// }else{
 	// 	return console.log("incorrect");
 	// }
}

breckBrackets('( ( a + b ) / 5 – d )');
breckBrackets(') ( a + b ) )');
breckBrackets('( b * ( c + d *2 / ( 2 + ( 12 – c / ( a + 3 ) ) ) )');
breckBrackets(')( a + b )(');
console.log("\n");