const http = require('http');
const server = http.createServer((req, res) => {
    if(req.method === 'POST') {
        let body = '';
        req.on('data', (chunk) => {
            body += chunk; //chunk is a Buffer, so we concatenate it to the body string
        });
        req.on('end', () => {
            console.log('Received POST(body) data:', body);
            res.end('Data received successfully!\n');
        });    
    }
});

server.listen(3000, () => {
    console.log('Server is listening on port 3000');
    console.log('You can send a POST request to http://localhost:3000 with some data in the body');
});