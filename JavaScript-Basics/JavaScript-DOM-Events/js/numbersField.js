var someText = document.getElementById('inp');


function changeField(){

  if(isNaN(someText.value)){
  	someText.style.background = "red";
  	someText.disabled = true;
	someText.value = "";
  	setTimeout(function(){ 
  		someText.disabled = false;
  		someText.style.background = "";
  		someText.focus();}, 500);
   }
}

someText.addEventListener('input', changeField, true);