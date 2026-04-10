const EventEmitter = require('events');

const emitter = new EventEmitter();

emitter.on('orderPlaced', (orderId) => { //Event listener for 'orderPlaced' event
    console.log(`Order ${orderId} has been placed.`);
});

emitter.emit('orderPlaced', '12345'); // Emitting 'orderPlaced' event with orderId '12345', which triggers the listener and logs the message.