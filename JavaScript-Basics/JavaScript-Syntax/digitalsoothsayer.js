
function soothsayer (value) {
    var result = [];
    result[0] = value[0][Math.floor(Math.random()*5)];
    result[1] = value[1][Math.floor(Math.random()*5)];
    result[2] = value[2][Math.floor(Math.random()*5)];
    result[3] = value[3][Math.floor(Math.random()*5)];
    
    console.log("You will work %s years on %s.", result[0], result[1]);
    console.log("You will live in %s and drive %s.", result[2], result[3]);
}
soothsayer([[3, 5, 2, 7, 9], ["Java", "Python", "C#", "JavaScript", "Ruby"], 
    ['Silicon Valley', 'London', 'Las Vegas', 'Paris', 'Sofia'], ['BMW', 'Audi', 'Lada', 'Skoda', 'Opel']]);


