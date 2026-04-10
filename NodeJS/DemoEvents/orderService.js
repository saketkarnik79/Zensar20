const EventEmitter = require('events');

class OrderService extends EventEmitter {
    constructor() {
        super();
    }

    placeOrder(order) {
        console.log(`Placing order for ${order.product} (Quantity: ${order.quantity})`);
        // Simulate order processing
        setTimeout(() => {
            this.emit('orderPlaced', order);
        }, 1000);
    }
}

module.exports = OrderService;