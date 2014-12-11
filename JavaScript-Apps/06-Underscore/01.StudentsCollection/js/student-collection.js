(function () {
	var students = JSON.parse(document.getElementById("input").value);

	var studentsBetween18and24 = _.filter(students, function(student) {
		return student.age >= 18 && student.age <= 24;
	});

	var studentsFirstNameAlphabeticallyBeforeLastName = _.filter(students, function(student) {
		return student.firstName.localeCompare(student.lastName) === -1;
	});

	var studentsNamesFromBulgaria = _.chain(students)
				.filter(function(student) {
					return student.country === "Bulgaria";
				})
				.map(function(student) {
					return student.firstName + " " + student.lastName;
				})
				.value();

	var studentsLastFive = _.chain(students)
				.toArray()
				.last(5)
				.value();

	var studentsFirstThreeNotBulgariaMale = _.chain(students)
				.reject(function(student) {
					return student.country === "Bulgaria";
				})
				.filter(function(student) {
					return student.gender === "Male";
				})
				.toArray()
				.first(3)
				.value();

	console.log("All students with age between 18 and 24");
	console.dir(studentsBetween18and24);
	console.log("All students whose first name is alphabetically before their last name");
	console.dir(studentsFirstNameAlphabeticallyBeforeLastName);
	console.log("Get only the names of all students from Bulgaria"); 
	console.dir(studentsNamesFromBulgaria);
	console.log("Get the last five students");
	console.dir(studentsLastFive);
	console.log("Get the first three students who are not from Bulgaria and are male");
	console.dir(studentsFirstThreeNotBulgariaMale);
}())