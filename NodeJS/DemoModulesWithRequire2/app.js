//const userService = require('./services/userService');
const { userService, orderService } = require('./services');
const logger = require('./utils/logger');

function main() {
    logger.log('Application started');
    const user = userService.getUserById(1);
    logger.log(`User retrieved: ${JSON.stringify(user)}`);

    const orders = orderService.getOrdersByUserId(user.id);
    logger.log(`Orders retrieved for user ${user.id}: ${JSON.stringify(orders)}`);

    logger.log('Application finished');
}

main();