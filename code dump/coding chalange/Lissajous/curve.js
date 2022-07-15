class Curve {
  constructor() {
    this.path = [];
    this.current = createVector();
  }

  setX(x) {
    this.current.x = x;
  }
  getX(){return this.current.x;}

  setY(y) {
    this.current.y = y;
  }
  getY(){return this.current.y;}
  addPoint() {
    this.path.push(this.current);
  }

  reset() {
    this.path = [];
  }

  show(r=255,g=255,b=255,a=255) {
    //stroke(255);
	stroke(r,g,b,a);
    strokeWeight(1);
    noFill();
    beginShape();
    for (let i = 0; i < this.path.length; i++) {
      const v = this.path[i];
      vertex(v.x, v.y);
    }
    endShape();

    strokeWeight(8);
    point(this.current.x, this.current.y);
    this.current = createVector();
  }
}