const express = require('express');
const connectDB = require('./config/db');
const userRoutes = require('./routes/user.routes');

connectDB();

const app = express();
app.use(express.json());
app.use('/api/users', userRoutes);

//hosting
const PORT = process.env.PORT || 5000;
app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
    console.log(`Users API is running and accessible at http://localhost:${PORT}/api/users`);
});