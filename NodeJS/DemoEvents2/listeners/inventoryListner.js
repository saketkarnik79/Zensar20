module.exports = (emitter) => {
    emitter.on('order:created', (order) => {
        console.log(`Inventory updated for order: ${order.id}`);
    });
};