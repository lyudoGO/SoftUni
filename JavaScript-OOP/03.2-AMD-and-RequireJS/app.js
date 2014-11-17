(function () {
	"use strict";
	require.config({
		paths: {
			"factory": "js/factory",
			"getToday": "js/get-today"
		}
	});

	require(["factory", "getToday"], function (Factory, GetToday) {
		document.body.addEventListener("onload", function (GetToday) {});
		var container = Factory.getContainer();
		container.addToDOM();
	});
}());
