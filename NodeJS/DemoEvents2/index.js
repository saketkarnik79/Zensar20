// const OrderService = require('./orderService');

// const emailListener = require('./listeners/emailListener');
// const inventoryListener = require('./listeners/inventorylistner');
// const analyticsListener = require('./listeners/analyticsListener');

// const orderService = new OrderService();

// //Register listeners
// emailListener(orderService);
// inventoryListener(orderService);
// analyticsListener(orderService);

// // Emit event by placing an order
// orderService.placeOrder({ id: 1, item: 'Laptop', quantity: 1 });
// orderService.placeOrder({ id: 2, item: 'Phone', quantity: 2 });

const FileProcessor = require('./fileProcessor');

const fileProcessor = new FileProcessor();

// Register listeners
fileProcessor.on('file:processed', (data) => {
    console.log('File processed successfully. Data:', data);
});

// fileProcessor.on('error', (err) => {
//     console.error('Error processing file:', err.message);
// });

// Process a file
fileProcessor.process('missing.txt');