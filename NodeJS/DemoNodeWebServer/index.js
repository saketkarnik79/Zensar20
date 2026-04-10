const http = require('http');

// const server = http.createServer((req, res) => {
//   res.end('Hello from NodeJS native web server!\n');
// });

const server = http.createServer((req, res) => {
  if (req.url === '/' && req.method === 'GET') {
    res.end('Home Page');
  } else if (req.url === '/about' && req.method === 'GET') {
    res.end('About Page');
  } else if (req.url === '/contact' && req.method === 'GET') {
    res.end('Contact Page');
  } else if(req.url === '/' && req.method === 'POST') {
    let body = '';
    req.on('data', chunk => {
      body += chunk.toString();
    });
    req.on('end', () => {
        const data = JSON.parse(body);
        //res.setHeader('Content-Type', 'application/json');
        res.end('Data received: ' + JSON.stringify({received: data}));
    });
  } else {
    res.statusCode = 404;
    res.end('Page/resource Not Found');
  }
  
});

server.listen(3000, () => {
  console.log('Server is listening on port 3000');
  console.log('You can access it at http://localhost:3000');
});