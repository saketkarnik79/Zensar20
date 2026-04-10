module.exports = (emitter) => {
    emitter.on('order:created', (order) => {
        console.log(`Analytics recorded for order: ${order.id}`);
    });
}