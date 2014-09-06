function countDivs(html){
	var reg = new RegExp("<div", "gi");
	var count = html.match(reg);
	console.log(count.length);
}

countDivs('<!DOCTYPE html><html><head lang="en"><meta charset="UTF-8"><title>index</title><script src="/yourScript.js" defer></script></head><body><div id="outerDiv"><div class="first"><div><div>hello</div></div><div>hi<div></div></div><div>I am a div</div></div></body></html>');
console.log("\n");