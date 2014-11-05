Object.prototype.extends = function (parent) {
  if (!Object.create) {
    Object.prototype.create = function (proto) {
      function F() {};
      F.prototype = proto;
      return new F;
    };
  };
  
  this.prototype = Object.create(parent.prototype);
  this.prototype.constructor = this;
};

var Shape = (function (){
	function Shape(x, y, color){
		if (this.constructor === Shape) {
            throw new Error("Cannot instantiate abstract class Shape.");
        }
		this.setX(x);
		this.setY(y);
		this.setColor(color);
	}

	Shape.prototype.getX = function() {
        return this._x;
    }

    Shape.prototype.setX = function(x) {
        if (x < 0) {
            throw new Error("Coordinate X cannot be negative");
        }
        this._x = x;
    }
	
	Shape.prototype.getY = function() {
        return this._y;
    }

    Shape.prototype.setY = function(y) {
        if (y < 0) {
            throw new Error("Coordinate Y cannot be negative");
        }
        this._y = y;
    }

    Shape.prototype.getColor = function() {
        return this._color;
    }

    Shape.prototype.setColor = function(color) {
        if (!validationColor(color)) {
            throw new Error("Wrong color, must be 3 or 6 symbols in format #[a-f0-9]");
        }
        this._color = color;
    }

	Shape.prototype.toString = function (){
			var resultStr = "\nColor: " + this._color + ";\nx = " + 
							this._x + "; y = " + this._y;
			return resultStr;
	}

	Shape.prototype.canvas = function (canvasId){
			var doc = document.getElementById(canvasId);
			var canvas = doc.getContext("2d");
			return canvas;
	}

	return Shape;
}());

var Circle = (function (){
	function Circle(x, y, color, radius){
		Shape.apply(this, arguments);
		this.setRadius(radius);
	}

	Circle.extends(Shape);

	Circle.prototype.getRadius = function() {
        return this._radius;
    }

    Circle.prototype.setRadius = function(radius) {
        if (radius < 0) {
            throw new Error("Radius cannot be negative");
        }
        this._radius = radius;
    }

	Circle.prototype.toString = function (){
		var resultStr = "Circle: " + Shape.prototype.toString.call(this) + ";\nradius = " + this._radius;
		return resultStr;
	};

	Circle.prototype.draw = function (canvasId){
		this.canvas(canvasId).fillStyle = this._color;
		this.canvas(canvasId).beginPath();
		this.canvas(canvasId).arc(this._x, this._y, this._radius, 0, 2 * Math.PI);
		this.canvas(canvasId).fill();
	};

	return Circle;
}());

var Rectangle = (function (){
	function Rectangle(x, y, color, width, height){
		Shape.apply(this, arguments);
		this.setWidth(width);
		this.setHeight(height);
	}

	Rectangle.extends(Shape);

	Rectangle.prototype.getWidth = function() {
        return this._width;
    }

    Rectangle.prototype.setWidth = function(width) {
        if (width < 0) {
            throw new Error("Width cannot be negative");
        }
        this._width = width;
    }

	Rectangle.prototype.getHeight = function() {
        return this._height;
    }

    Rectangle.prototype.setHeight = function(height) {
        if (height < 0) {
            throw new Error("Height cannot be negative");
        }
        this._height = height;
    }

	Rectangle.prototype.toString = function (){
			var resultStr = "Rectangle: " + Shape.prototype.toString.call(this) + ";\nwidth = " + this._width + 
				";\nheight = " + this._height;
				return resultStr;
	};

	Rectangle.prototype.draw = function (canvasId){
		this.canvas(canvasId).fillStyle = this._color;
		this.canvas(canvasId).fillRect(this._x, this._y, this._width, this._height);
	};

	return Rectangle;
}());

var Triangle  = (function (){
	function Triangle (x, y, color, x2, y2, x3, y3){
		Shape.apply(this, arguments);
		this.setX2(x2);
		this.setY2(y2);
		this.setX3(x3);
		this.setY3(y3);
	}

	Triangle.extends(Shape);

	Triangle.prototype.getX2 = function() {
        return this._x2;
    }

    Triangle.prototype.setX2 = function(x2) {
        if (x2 < 0) {
            throw new Error("X2 coordinate of tringle cannot be negative");
        }
        this._x2 = x2;
    }

	Triangle.prototype.getY2 = function() {
        return this._y2;
    }

    Triangle.prototype.setY2 = function(y2) {
        if (y2 < 0) {
            throw new Error("Y2 coordinate of tringle cannot be negative");
        }
        this._y2 = y2;
    }

    Triangle.prototype.getX3 = function() {
        return this._x3;
    }

    Triangle.prototype.setX3 = function(x3) {
        if (x3 < 0) {
            throw new Error("X3 coordinate of tringle cannot be negative");
        }
        this._x3 = x3;
    }

	Triangle.prototype.getY3 = function() {
        return this._y3;
    }

    Triangle.prototype.setY3 = function(y3) {
        if (y3 < 0) {
            throw new Error("Y3 coordinate of tringle cannot be negative");
        }
        this._y3 = y3;
    }

	Triangle.prototype.toString = function (){
		var resultStr = "Triangle: " + Shape.prototype.toString.call(this) + ";\nx2 = " + this._x2 + 
			"; y2 = " + this._y2 + ";\nx3 = " + this._x3 + 
			"; y3 = " + this._y3;

			return resultStr;
	};

	Triangle.prototype.draw = function (canvasId){
		this.canvas(canvasId).fillStyle = this._color;
		this.canvas(canvasId).beginPath();
		this.canvas(canvasId).moveTo(this._x, this._y);
		this.canvas(canvasId).lineTo(this._x2, this._y2);
		this.canvas(canvasId).lineTo(this._x3, this._y3);
		this.canvas(canvasId).closePath();
		this.canvas(canvasId).fill();
	};

	return Triangle;
}());

var Segment = (function (){
	function Segment (x, y, color, x2, y2){
		Shape.apply(this, arguments);
		this.setX2(x2);
		this.setY2(y2);
	}

	Segment.extends(Shape);

	Segment.prototype.getX2 = function() {
        return this._x2;
    }

    Segment.prototype.setX2 = function(x2) {
        if (x2 < 0) {
            throw new Error("X2 coordinate of segment cannot be negative");
        }
        this._x2 = x2;
    }

	Segment.prototype.getY2 = function() {
        return this._y2;
    }

    Segment.prototype.setY2 = function(y2) {
        if (y2 < 0) {
            throw new Error("Y2 coordinate of segment cannot be negative");
        }
        this._y2 = y2;
    }

	Segment.prototype.toString = function (){
		var resultStr = "Segment: " + Shape.prototype.toString.call(this) + ";\nx2 = " + this._x2 + 
			"; y2 = " + this._y2;

		return resultStr;
	};

	Segment.prototype.draw = function (canvasId){
		this.canvas(canvasId).fillStyle = this._color;
		this.canvas(canvasId).moveTo(this._x, this._y);
		this.canvas(canvasId).lineTo(this._x2, this._y2);
		this.canvas(canvasId).stroke();
	};

	return Segment;
}());

var Point = (function (){
	function Point(x, y, color){
		Shape.apply(this, arguments);
	}

	Point.extends(Shape);

	Point.prototype.toString = function (){
		var resultStr = "Point: " + Shape.prototype.toString.call(this);

		return resultStr;
	};

	Point.prototype.draw = function (canvasId){
		this.canvas(canvasId).beginPath();
		this.canvas(canvasId).fillStyle = this._color;
		this.canvas(canvasId).arc(this._x, this._y, 3, 0, 2 * Math.PI);
		this.canvas(canvasId).fill();
	};

	return Point;
}());

function validationColor(str){
	var pattern = new RegExp(/^#([a-f0-9]{6}|[a-f0-9]{3})$/i);

	if (!pattern.test(str.toLowerCase())) {
		return false;
	};

	return true;
}