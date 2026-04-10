const express = require('express');
const session = require('express-session');

const app = express();
app.use(session({
    secret: 'xhQjwPFYh0yWo9EOYcyYKA==',
    resave: false,
    saveUninitialized: false,
    cookie: { 
        secure: false,
        maxAge: 20 * 60 * 1000 // 20 minutes
     }
}));

app.get('/login', (req, res) => {
    // Simulate user login
    req.session.user = { id: 1, name: 'John Doe' };
    res.send('Logged in');
});

app.get('/dashboard', (req, res) => {
    if(!req.session.user) {
        return res.status(401).send('Unauthorized Access.');
    }
    res.send('Welcome to your dashboard, ' + req.session.user.name);
});

app.get('/logout', (req, res) => {
    req.session.destroy(err => {
        if(err) {
            return res.status(500).send('Error occurred while logging out.');
        }
        res.send('Logged out successfully.');
    });
});

app.listen(3000, () => {
    console.log('Server is running on port 3000.');
    console.log('Visit http://localhost:3000/login to log in, then http://localhost:3000/dashboard to access the dashboard, and http://localhost:3000/logout to log out.');
});