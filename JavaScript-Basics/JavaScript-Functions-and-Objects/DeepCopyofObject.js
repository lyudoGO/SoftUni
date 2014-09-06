
var a = {name: 'Pesho', age: 21};
var b = clone(a);
var b1 = a;

function clone(obj){
	var strObj = JSON.stringify(obj);
	var objCopy = JSON.parse(strObj);
	return objCopy;
}

function compareObjects(obj, objCopy) {
	var isEqual = (obj == objCopy);
	return console.log("a == b --> " + isEqual);

}

compareObjects(a, b);
console.log();
compareObjects(a, b1);
console.log("\n");