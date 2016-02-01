var Shapes = (function () {
    Function.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }

    var Shape = (function () {
        function Shape(x, y, color) {
            this._x = x;
            this._y = y;
            this._color = color;
        };

        Shape.prototype = {
            toString: function () {
                var output = "Shape: \n"
                + "\tX: " + this._x + "\n\tY: " + this._y
                + "\n\tColor: " + this._color;
                return output;
            },
            getCanvas: function () {
                var context = {
                    element: document.getElementById("canvas").getContext("2d")
                }
                return context;
            }
        }
        
        return Shape;
    })();

    var Circle = (function () {
        function Circle(x, y, r, color) {
            Shape.call(this, x, y, color);
            this._r = r;
        };
        Circle.extends(Shape);

        Circle.prototype.toString = function () {
            var output = "Circle: \n"
            + "\tX: " + this._x + "\n\tY: " + this._y
            + "\n\tRadius: " + this._r
            + "\n\tColor: " + this._color;
            return output;
        };

        Circle.prototype.draw = function () {
            this.getCanvas().element.beginPath();
            this.getCanvas().element.arc(this._x, this._y, this._r, 0, 2 * Math.PI);
            this.getCanvas().element.fillStyle = this._color;
            this.getCanvas().element.fill();
            this.getCanvas().element.stroke();
        };

        return Circle;
    })();


    var Rectangle = (function () {
        function Rectangle(x, y, width, height, color) {
            Shape.call(this, x, y, color);
            this._width = width;
            this._height = height;
        };
        Rectangle.extends(Shape);

        Rectangle.prototype.toString = function () {
            var output = "Rectangle: \n"
            + "\tX: " + this._x + "\n\tY: " + this._y
            + "\n\tWidth: " + this._width
            + "\n\tHeight: " + this._height
            + "\n\tColor: " + this._color;
            return output;
        };

        Rectangle.prototype.draw = function () {
            this.getCanvas().element.fillStyle = this._color; 
            this.getCanvas().element.fillRect(this._x, this._y, this._width, this._height);
        };

        return Rectangle;
    })();

    var Triangle = (function () {
        function Triangle(x, x2, x3, y, y2, y3, color) {
            Shape.call(this, x, y, color);
            this._x2 = x2;
            this._x3 = x3;
            this._y2 = y2;
            this._y3 = y3;
        };
        Triangle.extends(Shape);

        Triangle.prototype.toString = function () {
            var output = "Triangle: \n"
            + "\n\tA: (" + this._x + ", " + this._y + ")"
            + "\n\tB: (" + this._x2 + ", " + this._y2 + ")"
            + "\n\tC: (" + this._x3 + ", " + this._y3 + ")"
            + "\n\tColor: " + this._color;
            return output;
        };

        Triangle.prototype.draw = function () {
            this.getCanvas().element.beginPath();
            this.getCanvas().element.moveTo(this._x, this._y);
            this.getCanvas().element.lineTo(this._x2, this._y2);
            this.getCanvas().element.lineTo(this._x3, this._y3);
            this.getCanvas().element.fillStyle = this._color;
            this.getCanvas().element.fill();
        };

        return Triangle;
    })();

    var Line = (function () {
        function Line(x, x2, y, y2, color) {
            Shape.call(this, x, y, color);
            this._x2 = x2;
            this._y2 = y2;
        };
        Line.extends(Shape);

        Line.prototype.toString = function () {
            var output = "Line: \n"
            + "\n\tA: (" + this._x + ", " + this._y + ")"
            + "\n\tB: (" + this._x2 + ", " + this._y2 + ")"
            + "\n\tColor: " + this._color;
            return output;
        };

        Line.prototype.draw = function () {
            this.getCanvas().element.moveTo(this._x, this._y);
            this.getCanvas().element.lineTo(this._x2, this._y2);
            this.getCanvas().element.strokeStyle = this._color;
            this.getCanvas().element.stroke();
        };

        return Line;
    })()

    var Segment = (function () {
        function Segment(x, x2, y, y2, color) {
            Shape.call(this, x, y, color);
            this._x2 = x2;
            this._y2 = y2;
        };
        Segment.extends(Shape);

        Segment.prototype.toString = function () {
            var output = "Segment: \n"
            + "\n\tA: (" + this._x + ", " + this._y + ")"
            + "\n\tB: (" + this._x2 + ", " + this._y2 + ")"
            + "\n\tColor: " + this._color;
            return output;
        };

        Segment.prototype.draw = function () {
            this.getCanvas().element.moveTo(this._x, this._y);
            this.getCanvas().element.lineTo(this._x2, this._y2);
            this.getCanvas().element.strokeStyle = this._color;
            this.getCanvas().element.stroke();
        };

        return Segment;
    })()

    return {
        Shape: Shape,
        Circle: Circle,
        Rectangle: Rectangle,
        Triangle: Triangle,
        Line: Line,
        Segment: Segment
    };
})();