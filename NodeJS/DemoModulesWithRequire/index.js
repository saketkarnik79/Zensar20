const mathUtils = require('./mathUtils');
const logger = require('./logger');

logger("Starting math operations...");

try {
    console.log(mathUtils.add(5, 3)); // Output: 8
    console.log(mathUtils.subtract(5, 3)); // Output: 2
    console.log(mathUtils.multiply(5, 3)); // Output: 15
    console.log(mathUtils.divide(5, 0)); // Output: [LOG]: Cannot divide by zero
    console.log(mathUtils.modulus(5, 0)); // Output: [LOG]: Cannot perform modulus by zero
} catch (error) {
    console.error(error.message);
}
finally{
    logger("Math operations completed.");
}

logger("Finished math operations.");