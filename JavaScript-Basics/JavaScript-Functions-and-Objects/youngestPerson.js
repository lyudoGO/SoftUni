function findYoungestPerson(persons) {
	var minAge = Number.MAX_VALUE;
	var youngest = {};
	for (var i = 0; i < persons.length; i++) {
		var currentMinAge = persons[i].age;
		if(currentMinAge < minAge){
			minAge = currentMinAge;
			youngest = persons[i];
		}
	};
	var nameYoungest = youngest.firstname + " " + youngest.lastname;
	console.log("The youngest person is " + nameYoungest);
}

findYoungestPerson([
  { firstname : 'George', lastname: 'Kolev', age: 32}, 
  { firstname : 'Bay', lastname: 'Ivan', age: 81},
  { firstname : 'Baba', lastname: 'Ginka', age: 40}]
);
console.log("\n");