const express = require('express');
const userRoutes = require('./routes/user.routes');
const errorHandler =require('./middlewares/error.middleware');
const logger = require('./middlewares/logger.middleware');

const app = express();

app.use(express.json()); // Middleware to parse JSON bodies

// Use custom logger middleware
app.use(logger);

// Use user routes
app.use('/users', userRoutes);

//404 handler
app.use((req, res) => {
    res.status(404).json({error: 'Route not found'});
});

//Global error handler
app.use(errorHandler);

const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
    console.log(`Access the API at http://localhost:${PORT}/users`);
});