const express = require('express');
const exphbs = require('express-handlebars');
const path = require('path');
const { title } = require('process');
const app = express();

// Set up Handlebars as the view engine
// app.engine('handlebars', exphbs());
// app.set('view engine', 'handlebars');

app.engine('hbs', exphbs.engine({
    extname: 'hbs',
    defaultLayout: 'main'
}));

app.set('view engine', 'hbs');
app.set('views', path.join(__dirname, 'views'));

app.get('/', (req, res) => {
    res.render('home', {
        title: 'Home Page',
        name: 'John Doe',
        items: ['Item 1', 'Item 2', 'Item 3']
    });
});

app.get('/users/:id', (req, res) => {
    const userId = req.params.id;
    // Logic for fetching user data based on ID
    res.render('user', {
        title: 'User Page',
        userId: userId,
        name: 'John Doe'
    });
});

app.listen(3000, () => {
    console.log('Server is running on port 3000.');
    console.log('Visit http://localhost:3000 to access the application.');
});