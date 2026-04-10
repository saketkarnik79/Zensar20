const net = require('net');

const client = net.createConnection({ port: 8080, host: 'localhost' }, () => {
    console.log('Connected to server');
    client.write('Hello Server\n');
});

//Receive data from the server
client.on('data', (data) => {
    console.log('Server says: ' + data.toString());
});

//Handle connection end
client.on('end', () => {
    console.log('Disconnected from server');
});

//Handle errors
client.on('error', (err) => {
    console.error('Error: ' + err.message);
});