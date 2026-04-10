const express = require('express');
const http = require('http');
const { Server } = require('socket.io');

const app = express();
const server = http.createServer(app);
const io = new Server(server, {cors: {origin: "*"}});

//server static files (index.html)
app.use(express.static(__dirname));

io.on('connection', (socket) => {
  console.log(`a user connected: ${socket.id}`);

  //receive message from client
    socket.on('client-message', (msg) => {
      console.log(`Received message from client: ${msg}`);
      //emit message to all connected clients
      socket.emit('server-message', "Hello! From Server!");
    //   setTimeout(() => {
    //     socket.emit('server-message', "This is a delayed message from the server.");
    //   }, 15000);
    let count = 1;
    setInterval(() => {
        count++;
        socket.emit('server-message', `This is a delayed message from the server. Count: ${count}`);
      }, 5000);
    });
    //handle disconnection
    socket.on('disconnect', () => {
      console.log(`user disconnected: ${socket.id}`);
    });
});

const PORT = process.env.PORT || 3000;
server.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
  console.log(`Server running on http://localhost:${PORT}`);
});