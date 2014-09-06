var btn = document.getElementById("btnHideOddRows");

function myFunction(){
	for(var i=0; i < 5; i++){
	document.getElementsByTagName("table")[0].deleteRow(i);
	}
}

btn.addEventListener("click", myFunction);