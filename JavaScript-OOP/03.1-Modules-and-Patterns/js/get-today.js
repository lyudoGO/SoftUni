function returnTodayDay () {
	var date = new Date();
    var weekday = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];
    var day = weekday[date.getDay()];
    document.getElementById("today").innerHTML = day + " <em>TODO</em> List";
}