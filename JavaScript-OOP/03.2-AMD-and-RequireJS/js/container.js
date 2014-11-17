define(["js/section.js"], function (Section) {
	"use strict"

	var Container = (function (){
		function Container(){
			
		};

		Container.prototype.addToDOM = function (){
			var containerDiv = document.createElement("div");
			containerDiv.id = "container";

			var inputText = document.createElement("input");
			var inputBtn = document.createElement("input");

			inputText.setAttribute("type", "text");
			inputText.setAttribute("placeholder", "Title");

			inputBtn.setAttribute("type", "button");
			inputBtn.setAttribute("value", "New Section");

			inputBtn.addEventListener("click", function () {
                var section = new Section(inputText.value);
                section.addToDOM(containerDiv.id);
            });

			document.body.appendChild(containerDiv);
			document.body.appendChild(inputText);
			document.body.appendChild(inputBtn);
		};

		return Container;
	}());
	return Container;
});
	