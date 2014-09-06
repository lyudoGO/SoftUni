var textArea = document.getElementById("coord");

function printMouseCoordinates(event){
    textArea.innerHTML += "X:" + event.pageX + "; Y:" + event.pageY + "; Time: " + new Date() + "\n";
}

document.addEventListener("mouseover", printMouseCoordinates, false);