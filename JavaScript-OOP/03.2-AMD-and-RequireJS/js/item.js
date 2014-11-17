define(function () {
	"use strict"

	var Item = (function (){
		var itemId = 0;

		function Item(content){
			if (content === "" || content === null) {
				throw new Error("Content item cannot be empty");
			};
			this._content = content;
			itemId++;
		};

		Item.prototype.addToDOM = function (sectionId){

			var checkBox = document.createElement("input");
			checkBox.setAttribute("type", "checkbox");
			checkBox.setAttribute("id", "checkbox" + itemId);
			checkBox.addEventListener("click", function () {
                    if (checkBox.checked) {
                    	content.style.backgroundColor = "lightgreen";
                    } else {
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
	return Item;
});

