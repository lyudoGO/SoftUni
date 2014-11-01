var domModule = (function () {

	var addElementToParent = function addElementToParent(){
		var parentElement = document.querySelector(arguments[1]);
		var newChildElement = arguments[0];
		var atr = document.createAttribute("class");
		atr.value = "bird";
		newChildElement.setAttributeNode(atr);
		newChildElement.appendChild(document.createTextNode("BATMAN"));
		parentElement.appendChild(newChildElement);
	}

	var removeChildElement = function removeChildElement(){
		var parentElement = document.querySelector(arguments[0]);
		var removedElement = parentElement.querySelector(arguments[1]);
		parentElement.removeChild(removedElement);
	}

	var attachEventToSelector = function attachEventToSelector(){
		var selectedElements = document.querySelectorAll(arguments[0]);
		var eventType = arguments[1];
		var eventHander = arguments[2];

		for (var i = 0; i < selectedElements.length; i++) {
			selectedElements[i].addEventListener(eventType, eventHander);
		};
	}

	var retrieveElementBySelector = function retrievElementBySelector(){
		var retrievedElements = document.querySelectorAll(arguments[0]);
		return retrievedElements;
	}

	return {
		appendChild: addElementToParent,
		removeChild: removeChildElement,
		addHandler: attachEventToSelector,
		retrieveElements: retrieveElementBySelector
	}
}());