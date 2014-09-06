
function treeHouseCompare (a, b) {
    var areaHouse = (a * a) + (a * (2/3 * a));
    var areaCircle = Math.PI * Math.pow(((b + 1/3 * b)/2), 2);
    var areaTree = (b * 1/3 * b) + areaCircle;
    if(areaHouse > areaTree){
        return "house/" + areaHouse.toFixed(2);
    }else{
        return "tree/" + areaTree.toFixed(2);
    }
    
}
console.log(treeHouseCompare(3, 2));
console.log(treeHouseCompare(3, 3));
console.log(treeHouseCompare(4, 5));

