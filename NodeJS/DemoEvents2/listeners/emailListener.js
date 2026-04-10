module.exports=(emitter)=>{
    emitter.on('order:created',(order)=>{
        console.log(`Email sent for order: ${order.id}`);
    });
};