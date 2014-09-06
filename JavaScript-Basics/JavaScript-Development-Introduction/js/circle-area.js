
function calcCircleArea (radius) {
	var area = Math.PI * radius * radius;
	return area;
}
function areaPrint (radius){
	document.write("r = " + radius + ";" + "area = " + calcCircleArea(radius) + "<br>");
}

	


