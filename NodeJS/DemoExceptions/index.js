// const {readFile}=require('./fileService');
// const {getUserById}=require('./userService');

// readFile('missing.txt', (err, data)=>{
//     if(err){
//         console.error('Error reading file:', err.message);
//         return;
//     }
//     console.log('File content:', data);
// });

// getUserById(null)
//     .then(user => {
//         console.log('User found:', user);
//     })
//     .catch(err => {
//         console.error('Error fetching user:', err.message);
//     });

// getUserById(1)
//     .then(user => {
//         console.log('User found:', user);
//     })
//     .catch(err => {
//         console.error('Error fetching user:', err.message);
//     });

// getUserById(6)
//     .then(user => {
//         console.log('User found:', user);
//     })
//     .catch(err => {
//         console.error('Error fetching user:', err.message);
//     });

const { createOrder } = require('./orderService');

async function main(){
    try {
        const order = await createOrder(500);
        console.log('Order created:', order);
    } catch (err) {
        console.error('Error creating order:', err.message);
    }
}

main();