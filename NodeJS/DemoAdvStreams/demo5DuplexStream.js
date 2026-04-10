const net = require('net');
const server = net.createServer((socket) => {
    socket.write('Hello Client\n');
    socket.on('data', (data) => {
    console.log('Received: ' + data.toString());
    socket.write('Echo: ' + data);
});
});

server.listen(8080, () => {
    console.log('Server listening on port 8080');
});