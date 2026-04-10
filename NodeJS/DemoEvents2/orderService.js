const EventEmitter = require('events');

class OrderService extends EventEmitter {
    constructor() {
        super();
        this.orders = [];
    }

    placeOrder(order) {
        this.orders.push(order);
        console.log(`Order placed: ${order.id}`);
        this.emit('order:created', order);
    }
}

module.exports = OrderService;