k
var arr1 = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
var arr2 = ['hi', 'bye', 'hello' ];

Array.prototype.removeItem = function(element) {
    for (var i = 0; i < this.length; i++) {
        if (this[i] === element) {
            this.splice(i, 1);
         }
    }
    return this;
}

console.log(arr1.removeItem(1));
console.log(arr2.removeItem('bye'));

console.log("\n");