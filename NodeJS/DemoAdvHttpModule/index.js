const http = require('http');
const server = http.createServer((req, res) => {
    //Add response headers
    res.setHeader('X-Custom-Header', 'This is a custom header');
    res.setHeader('X-Powered-By', 'NodeJS');
    
  res.writeHead(200, { 'Content-Type': 'text/html' });
  
  res.write('<p>This is the first part of the response.</p>\n');
  res.write(`Request URL: ${req.url}\n`);
  res.write(`Request Method: ${req.method}\n`);
  res.write(`Request Headers: ${JSON.stringify(req.headers)}\n`);
  
  res.end('Hello, World!\n');
  //res.write('This will not be written to the response because res.end() has already been called.\n');
});

server.listen(3000, () => {
  console.log('Server is listening on port 3000.');
  console.log('You can make a request to http://localhost:3000 to see the response.');
});