const logger = require('./logger');

function add(a, b) {
    return a + b;
};

function subtract(a, b) {
    return a - b;
};

function multiply(a, b) {
    return a * b;
};

function divide(a, b) {
    if (b === 0) {
        logger("Cannot divide by zero");
        throw new Error("Cannot divide by zero");
    }
    return a / b;
};

function modulus(a, b) {
    if (b === 0) {
        logger("Cannot perform modulus by zero");
        throw new Error("Cannot perform modulus by zero");
    }
    return a % b;
};

module.exports = {
    add,
    subtract,
    multiply,
    divide,
    modulus
};