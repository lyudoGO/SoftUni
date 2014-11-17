define(["js/item.js"], function (Item) {
	"use strict"

	var Section = (function (){
		var sectionId = 0;

		function Section(title){
			if (title === "" || title === null) {
				throw new Error("Title section cannot be empty");
			};
			this._title = title;
			sectionId++;
		};

		Section.prototype.addToDOM = function (containerId){
			var sectionDiv = document.createElement("div");
			sectionDiv.id = "section-div" + sectionId;

			var section = document.createElement("section");
			section.id = "section" + sectionId;

			var title = document.createElement("h2");
			title.innerHTML = this._title;

			var inputText = document.createElement("input");;
			var inputBtn = document.createElement("input");;

			inputText.setAttribute("type", "text");
			inputText.setAttribute("placeholder", "Add item");

			inputBtn.setAttribute("type", "button");
			inputBtn.setAttribute("value", "+");
			inputBtn.addEventListener("click", function () {
                var item = new Item(inputText.value);
                item.addToDOM(section.id);
            });

			document.getElementById(containerId).appendChild(sectionDiv);
			document.getElementById(sectionDiv.id).appendChild(section);
			document.getElementById(section.id).appendChild(title);
			document.getElementById(sectionDiv.id).appendChild(inputText);
			document.getElementById(sectionDiv.id).appendChild(inputBtn);
		};

		return Section;
	}());
	return Section;
})