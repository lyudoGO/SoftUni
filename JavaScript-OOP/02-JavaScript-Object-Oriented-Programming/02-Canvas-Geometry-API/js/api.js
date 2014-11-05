var shapes = [];

function showShapesData() {
    var selectShapes = document.getElementById("shape");
    var optionValue = selectShapes.options[selectShapes.selectedIndex].value;
    document.getElementById("circle").style.display = "none";
    document.getElementById("rectangle").style.display = "none";
    document.getElementById("triangle").style.display = "none";
    document.getElementById("segment").style.display = "none";
    switch(optionValue){
        case "circle":document.getElementById(optionValue).style.display = "block";
        break;
        case "rectangle":document.getElementById(optionValue).style.display = "block";
        break;
        case "triangle":document.getElementById("segment").style.display = "block";
                        document.getElementById(optionValue).style.display = "block";
        break;
        case "segment":document.getElementById(optionValue).style.display = "block";
        break;
        default:
        break;
    }
}

function addShapesData(){
    var selectShapesData = document.getElementById("shapes-data");
    var option = document.createElement("option");
    var selectShapes = document.getElementById("shape");
    var optionValue = selectShapes.options[selectShapes.selectedIndex].value;

    var x = document.getElementById("x").value;
    var y = document.getElementById("y").value;
    var color = document.getElementById("color").value;
    var radius = document.getElementById("radius").value;
    var x2 = document.getElementById("x2").value;
    var y2 = document.getElementById("y2").value;
    var x3 = document.getElementById("x3").value;
    var y3 = document.getElementById("y3").value;
    var width = document.getElementById("width").value;
    var height = document.getElementById("height").value;
    
    switch(optionValue){
        case "circle":var circle = new Circle(x, y, color, radius);
                        shapes.push(circle);
                        option.text = circle.toString();
                        option.value = shapes.length - 1;
                        selectShapesData.add(option);
        break;
        case "rectangle":var rectangle = new Rectangle(x, y, color, width, height);
                        shapes.push(rectangle);
                        option.text = rectangle.toString();
                        option.value = shapes.length - 1;
                        selectShapesData.add(option);
        break;
        case "triangle":var triangle = new Triangle(x, y, color, x2, y2, x3, y3);
                        shapes.push(triangle);
                        option.text = triangle.toString();
                        option.value = shapes.length - 1;
                        selectShapesData.add(option);
        break;
        case "segment":var segment = new Segment(x, y, color, x2, y2);
                        shapes.push(segment);
                        option.text = segment.toString();
                        option.value = shapes.length - 1;
                        selectShapesData.add(option);
        break;
        case "point":var point = new Point(x, y, color);
                        shapes.push(point);
                        option.text = point.toString();
                        option.value = shapes.length - 1;
                        selectShapesData.add(option);
        break;
    }

  for (var i = 0; i < shapes.length; i++) {
      shapes[i].draw("canvas-shape");
  };
}

function removeShapesData(){
    var selectShapesData = document.getElementById("shapes-data");
    var index = selectShapesData.selectedIndex;
    shapes.splice(index, 1);
    selectShapesData.remove(index);
    if (index > 0) {
        selectShapesData.selectedIndex = index - 1;
    }
    
    canvasUpdate();
}

function moveShapeUp(){
    var selectShapesData = document.getElementById("shapes-data");
    var index = selectShapesData.selectedIndex;
 
    if (index < shapes.length - 1 && index >= 0) {
        shapes.splice(index, 2, shapes[index + 1], shapes[index]);
    
        var selectedOption = selectShapesData.options[index].text;
        var nextOption = selectShapesData.options[index + 1].text;
        selectShapesData.options[index].text = nextOption;
        selectShapesData.options[index + 1].text = selectedOption;

        canvasUpdate();
    };
    
}

function moveShapeDown(){
    var selectShapesData = document.getElementById("shapes-data");
    var index = selectShapesData.selectedIndex;

    if (index < shapes.length && index > 0) {
        shapes.splice((index - 1), 2, shapes[index], shapes[index - 1]);

        var selectedOption = selectShapesData.options[index].text;
        var nextOption = selectShapesData.options[index - 1].text;
        selectShapesData.options[index].text = nextOption;
        selectShapesData.options[index - 1].text = selectedOption;

        canvasUpdate();
    };
}

function canvasUpdate(){
    var canvasShapes = document.getElementById("canvas-shape");
    var ctx = canvasShapes.getContext("2d");
    ctx.clearRect(0, 0, canvasShapes.width, canvasShapes.height);

    for (var i = 0; i < shapes.length; i++) {
          shapes[i].draw("canvas-shape");
    };
}