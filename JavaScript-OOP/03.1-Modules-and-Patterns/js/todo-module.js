var app = (function () {
	"use strict"

	var Container = (function (){
		function Container(){
			
		};

		Container.prototype.addToDOM = function (){
			var containerDiv = document.createElement("div");
			containerDiv.id = "container";

			var inputText = document.createElement("input");;
			var inputBtn = document.createElement("input");;

			inputText.setAttribute("type", "text");
			inputText.setAttribute("placeholder", "Title");

			inputBtn.setAttribute("type", "button");
			inputBtn.setAttribute("value", "New Section");

			inputBtn.addEventListener("click", function () {
                var section = new app.Section(inputText.value);
                section.addToDOM(containerDiv.id);
            });

			document.body.appendChild(containerDiv);
			document.body.appendChild(inputText);
			document.body.appendChild(inputBtn);
		};

		return Container;
	}());

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
                var item = new app.Item(inputText.value);
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

	var Item = (function (){
		var itemId = 0;

		function Item(content){
			if (content === "" || content === null) {
				throw new Error("Content item cannot be empty");
			};
			this._content = content;
			this._status = "";
			itemId++;
		};

		Item.prototype.addToDOM = function (sectionId){
			var checkBox = document.createElement("input");
			checkBox.setAttribute("type", "checkbox");
			checkBox.setAttribute("id", "checkbox" + itemId);
			checkBox.addEventListener("click", function () {
                    if (checkBox.checked) {
                    	this._status = "completed";
                    	content.style.backgroundColor = "lightgreen";
                    } else {
                    	this._status = "not";
                    	content.style.backgroundColor = "white";
                    };
                });

			var content = document.createElement("p");
			content.setAttribute("id", "content" + itemId);
			content.innerHTML = this._content;

			document.getElementById(sectionId).appendChild(checkBox);
			document.getElementById(sectionId).appendChild(content);
		};

		return Item;
	}());

	return {
		Container: Container
	}
}());