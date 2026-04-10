// const EventEmitter = require('events');

// const emitter = new EventEmitter();

// emitter.on('greet', (user) => {
//     console.log('Hello');
//     console.log(`User Id: ${user.id}, Name: ${user.name}`);
// });

// emitter.on('greet', (user) => {
//     console.log('Welcome');
//     console.log(`${JSON.stringify(user)}`);
// });

// //emitter.emit('greet', { id: 1, name: 'Alice' });

// const user = { id: 1, name: 'Alice' };

// setTimeout(() => {
//     emitter.emit('greet', user);
// }, 2000);

// emitter.emit('greet', { id: 2, name: 'Bob' });

// emitter.on('error', (err) => {
//     console.error('An error occurred:', err.message);
// });

// emitter.emit('error', new Error('Something went wrong!'));

const OrderService = require('./orderService');

const orderService = new OrderService();

orderService.on('orderPlaced', (order) => {
    console.log(`Order for ${order.product} has been placed successfully!`);
});

const order = { product: 'Laptop', quantity: 10 };

orderService.placeOrder(order);