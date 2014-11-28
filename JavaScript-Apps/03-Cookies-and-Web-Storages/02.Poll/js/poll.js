(function () {
	var user = {"question1" : "", "question2" : "", "question3" : ""};
	var corectAnswers = {"question1" : "b", "question2" : "d", "question3" : "a"};
	var button = document.getElementById("inp-btn");
	var radios = document.querySelectorAll('input[type=radio]');
	for (var i = 0; i < radios.length; i++) {
		radios[i].onclick = function() {getAnswersByClick()};
	};
	
	if (!localStorage.user) {
		localStorage.setItem("user", JSON.stringify(user));
		localStorage.setItem("answers", JSON.stringify(corectAnswers));
	} else {
		getAnswersByStorage();
	}

	timer();

	button.addEventListener("click", function() {
		getAnswersByClick();
		localStorage.setItem("user", JSON.stringify(user));
		document.getElementById('result').style.display = "block";
		showUserAnswers();
		showCorectAnswers();
		clearInterval(countdownTimer);
		localStorage.clear();
	});

	function getAnswersByClick() {
		for (var i = 0; i < radios.length; i++) {
			var name = radios[i].name;
			if (name == "answerOne" && radios[i].checked) {
				user.question1 = radios[i].value;
			};
			if (name == "answerTwo" && radios[i].checked) {
				user.question2 = radios[i].value;
			};
			if (name == "answerThree" && radios[i].checked) {
				user.question3 = radios[i].value;
			};
		};
		localStorage.setItem("user", JSON.stringify(user));
	}

	function getAnswersByStorage() {
		var userAnswers = JSON.parse(localStorage.getItem("user"));
		var userAnswerOne = userAnswers.question1;
		var userAnswerTwo = userAnswers.question2;
		var userAnswerThree = userAnswers.question3;
		if (userAnswerOne) {
			document.querySelector('input[name="answerOne"][value="' + userAnswerOne + '"]').checked = true;
		};
		if (userAnswerTwo) {
			document.querySelector('input[name="answerTwo"][value="' + userAnswerTwo + '"]').checked = true;
		};
		if (userAnswerThree) {
			document.querySelector('input[name="answerThree"][value="' + userAnswerThree + '"]').checked = true;
		};
	}

	function showUserAnswers() {
		var result = document.getElementById("your-result");
		var userAnswers = JSON.parse(localStorage.getItem("user"));
		var userAnswerOne = document.createElement("p");
		userAnswerOne.innerText = "1. " + userAnswers.question1;
		var userAnswerTwo = document.createElement("p");
		userAnswerTwo.innerText = "2. " + userAnswers.question2;
		var userAnswerThree = document.createElement("p");
		userAnswerThree.innerText = "3. " + userAnswers.question3;
		result.appendChild(userAnswerOne);
		result.appendChild(userAnswerTwo); 
		result.appendChild(userAnswerThree);  
	}

	function showCorectAnswers() {
		var corectResult = document.getElementById("corect-result");
		var corectAnswerOne = document.createElement("p");
		corectAnswerOne.innerText = "1. " + corectAnswers.question1;
		var corectAnswerTwo = document.createElement("p");
		corectAnswerTwo.innerText = "2. " + corectAnswers.question2;
		var corectAnswerThree = document.createElement("p");
		corectAnswerThree.innerText = "3. " + corectAnswers.question3;
		corectResult.appendChild(corectAnswerOne);
		corectResult.appendChild(corectAnswerTwo); 
		corectResult.appendChild(corectAnswerThree);  
	}

	function timer() {
		var seconds = 300;
		countdownTimer = setInterval(function() {secondPassed()}, 1000);

		function secondPassed() {
		    var minutes = Math.round((seconds - 30)/60);
		    var remainingSeconds = seconds % 60;
		    if (remainingSeconds < 10) {
		        remainingSeconds = "0" + remainingSeconds;  
		    }
		    document.getElementById('timer').innerHTML = minutes + ":" + remainingSeconds;
		    if (seconds == 0) {
		        clearInterval(countdownTimer);
		        document.getElementById('timer').innerHTML = "Your time is over";
		        document.getElementById('inp-btn').style.display = "none";
		    } else {
		        seconds--;
		    }
		}
	}
}())