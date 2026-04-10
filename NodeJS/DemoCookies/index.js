const express = require('express');
const cookieParser = require('cookie-parser');

const app = express();
app.use(cookieParser());

app.get('/set-cookie', (req, res) => {
  res.cookie('username', 'john_doe', { maxAge: 1000 * 60 * 60 * 24, httpOnly: true, sameSite: 'strict' }); // Cookie expires in 1 day

  res.send('Cookie set!');
});

app.get('/get-cookie', (req, res) => {
  const username = req.cookies.username;
  console.log('Cookies:', req.cookies);
  console.log('Username from cookie:', username);
  res.send(`Username: ${username}`);
});


app.listen(3000, () => {
  console.log('Server is running on port 3000');
  console.log('Visit http://localhost:3000/set-cookie to set the cookie and http://localhost:3000/get-cookie to retrieve it.');
});