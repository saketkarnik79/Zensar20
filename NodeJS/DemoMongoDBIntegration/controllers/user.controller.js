const User = require('../models/User');

// Create a new user
exports.createUser = async (req, res, next) => {
    try {
        const user = await User.create(req.body);
        res.status(201).json({ success: true,
            data: user
        });
    } catch (error) {
        next(error);
    }
};

// Get all users
exports.getUsers = async (req, res, next) => {
    try {
        const users = await User.find();
        res.status(200).json(users);
    } catch (error) {
        next(error);
    }
};

// Get a single user by ID
exports.getUserById = async (req, res, next) => {
    try {
        const user = await User.findById(req.params.id);
        if (!user) {
            return res.status(404).json({ success: false,
                message: 'User not found'
            });
        }
        res.status(200).json({ success: true,
            data: user
        });
    } catch (error) {
        next(error);
    }
};

// Update a user by ID
exports.updateUser = async (req, res, next) => {
    try {
        const user = await User.findByIdAndUpdate(req.params.id, req.body, {
            new: true,
            runValidators: true
        });
        if (!user) {
            return res.status(404).json({ success: false,
                message: 'User not found'
            });
        }
        res.status(204).json({ success: true,
            data: user
        });
    } catch (error) {
        next(error);
    }
};

// Delete a user by ID
exports.deleteUser = async (req, res, next) => {
    try {
        const user = await User.findByIdAndDelete(req.params.id);
        if (!user) {
            return res.status(404).json({ success: false,
                message: 'User not found'
            });
        }
        res.status(204).json({ success: true });
    } catch (error) {
        next(error);
    }
};
