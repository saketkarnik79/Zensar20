async function createOrder(amount){
    if(amount <= 0){
        throw new Error("Amount must be greater than zero");
    }
    // Simulate order creation
    return { orderId: Math.floor(Math.random() * 1000), amount };
}

module.exports = { createOrder };