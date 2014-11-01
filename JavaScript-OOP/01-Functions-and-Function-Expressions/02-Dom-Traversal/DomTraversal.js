function traverse(selector) {

	var elementNode = document.querySelector(selector);
	traverseNode(elementNode, " ");

	function traverseNode(elementNode, spacing) {
		var result = spacing + elementNode.nodeName.toLowerCase() + ": ";

		if (elementNode.hasAttribute("id")) {
			result += "id=\"" + elementNode.id + "\" ";
		};

		if (elementNode.hasAttribute("class")) {
			result += "class=\"" + elementNode.className + "\"";
		};

		console.log(result);
		for (var i = 0; i < elementNode.childNodes.length; i++) {
			var child = elementNode.childNodes[i];
			if (child.nodeType === document.ELEMENT_NODE) {
				traverseNode(child, spacing + "    ");
			}
		}
	}
}

traverse(".birds");