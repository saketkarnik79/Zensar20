//app.js
const calcRoutes = require('./routes/calc.routes');
const express = require('express');
const app = express();

app.use(express.json());
app.use('/calc', calcRoutes);

app.get('/health', (req, res) => {
    res.status(200).json({ status: 'ok' });
});

module.exports = app;