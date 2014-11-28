(function () {
	var totalVisits;

	if (!localStorage.totalVisits) {
		localStorage.setItem("totalVisits", 0);
	};
	totalVisits = parseInt(localStorage.getItem("totalVisits"));

	var user = {firstName : "", lastName : ""};
	var button = document.getElementById("inp-btn");

	if (!localStorage.user) {
		localStorage.setItem("user", JSON.stringify(user));
		document.getElementById("input-form").style.display  = "block";
	} else {
		var currentUser = JSON.parse(localStorage.getItem("user"));
		var currentFirstName = currentUser.firstName;
		document.getElementById("greeting").innerText = "Hello " + 
		currentUser.firstName + " " + currentUser.lastName +
		"! Your name is in local storage";
		document.getElementById("input-form").style.display  = "none";
	};

	button.addEventListener("click", function() {
		user.firstName = document.getElementById("first-name").value;
		user.lastName = document.getElementById("last-name").value;
		if (user.firstName == "") {
			user.firstName = "Noname";
		};
		if (user.lastName == "") {
			user.lastName = "Noname";
		};
		localStorage.setItem("user", JSON.stringify(user));
	});

	incrementLoads();
	localStorage.setItem("totalVisits", totalVisits);
	document.getElementsByClassName("session")[1].innerText = totalVisits;

	function incrementLoads() {
		if (!sessionStorage.sessionVisits) {
			sessionStorage.setItem("sessionVisits", 0);
		};
		var currentCount = parseInt(sessionStorage.getItem("sessionVisits"));
		currentCount += 1;
		totalVisits += 1;
		sessionStorage.setItem("sessionVisits", currentCount);
		document.getElementsByClassName("session")[0].innerText = currentCount;
	}
}())