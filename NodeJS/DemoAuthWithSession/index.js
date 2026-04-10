const express = require('express');
const session = require('express-session');
const bcrypt = require('bcrypt');

const app = express();

app.use(express.json());

app.use(session({
  secret: 'cX9Eb3J2eU2EcmfhIrTkUw==',
  resave: false,
  saveUninitialized: false,
  cookie: {
    httpOnly: true,
    maxAge: 60 * 60 * 1000 // 1 hour
  }
}));

// Mock user data
const users = [
  {
    id: 1,
    username: 'user1',
    passwordHash: bcrypt.hashSync('password123', 10) // Hash the password
  },
  {
    id: 2,
    username: 'user2',
    passwordHash: bcrypt.hashSync('mysecret', 10) // Hash the password
  }
];

// Login route
app.post('/login', async (req, res) => {
  const { username, password } = req.body;

  // Find the user by username
  const user = users.find(u => u.username === username);
  if (!user) {
    return res.status(401).json({ error: 'Invalid credentials' });
  }

  // Compare the provided password with the stored hash
  const isMatch = await bcrypt.compare(password, user.passwordHash);
  if (!isMatch) {
    return res.status(401).json({ error: 'Invalid credentials' });
  }

  // Set the user ID in the session
  req.session.userId = user.id;

  res.json({ message: 'Login successful' });
});

//Logout route
app.post('/logout', (req, res) => {
  req.session.destroy(err => {
        if (err) {
            return res.status(500).json({ error: 'Logout failed' });
        }
        res.json({ message: 'Logout successful' });
    });
});

const isAuthenticated = (req, res, next) => {
  if (!req.session.userId) {
    return res.status(401).json({ error: 'Unauthorized' });
  }
  next();
};

app.get('/protected', isAuthenticated, (req, res) => {
  res.json({ message: 'This is a protected resource accessible only to authenticated users.' });
});

app.listen(3000, () => {
  console.log('Server is running on port 3000');
  console.log('Use POST http://localhost:3000/login to authenticate and GET http://localhost:3000/protected to access protected resource');
});