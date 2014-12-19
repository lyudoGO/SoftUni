'use strict';

var tigerApp = angular.module('tigerApp', []);

tigerApp.controller('TigerController', function TigerController($scope) {
	$scope.tiger = {
			name: "Pesho",
			born: "Asia",
			birthDate: 2006,
			live: "Sofia Zoo",
			image: "http://tigerday.org/wp-content/uploads/2013/04/tiger.jpg",
			ulStyles: {
				"float" : "left",
				"margin" : "30px",
				"list-style-type" : "none",
				"font-family" : "Tahoma"
			},
			liStyles: {
				"margin-bottom" : "15px",
				"color" : "dimgray"
			},
			divStyles: {
				"background-color" : "lightgray",
				"font-size" : "20px",
				"width" : "50%",
				"margin" : "20px auto",
				"overflow" : "hidden",

			},
			imgStyles: {
				"width" : "50%",
				"margin" : "20px",
				"float" : "right"
			},
			spanStyles: {
				"font-weight" : "bold",
				"color" : "black"
			},
			strongStyles: {
				"color" : "black",
				"margin-left": "50px",
				"text-transform": "uppercase"
			}
	};
});