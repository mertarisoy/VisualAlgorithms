
function drawCicle(x,y,n,context) {
    
    context.beginPath();
    context.arc(x, y, 20, 0, 2 * Math.PI);
    context.font = "20px Arial";
    context.fillText(n,x-5,y+5);
    context.stroke();
}

function drawLine(x1, y1, x2, y2, context) {

    context.beginPath();
    context.moveTo(x1, y1);
    context.lineTo(x2, y2);
    context.stroke();
}

function drawArrow(x1, y1, x2, y2, context) {
    
}

