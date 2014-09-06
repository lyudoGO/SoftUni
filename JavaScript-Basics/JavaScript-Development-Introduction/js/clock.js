function clock () {
	//calculate angle
	//60 sec = 360 deg; 1 sec = 6 deg; 1 hour is 30 deg apart
	//1 min is 6 deg apart
	var time, hours, minutes, seconds;
	var start;
	time = new Date();
	hours = 30 * ((time.getHours() % 12) + time.getMinutes() / 60);
	minutes = 6 * time.getMinutes();
	seconds = 6 * time.getSeconds();

	//move hands
	setAngle('h-hand', hours);
	setAngle('m-hand', minutes);
	setAngle('s-hand', seconds);

	//call every second
	start = setTimeout(function(){clock()}, 1000);

}
function setAngle(id, degrees){
	var variable = 'rotate(' + degrees + 'deg)';
	document.getElementById(id).style.WebkitTransform = variable;
}

window.onload = function(){clock()};

	


