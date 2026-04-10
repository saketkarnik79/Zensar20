const User = require('../models/user');
const users = require('../data/users');

function getUsers(req, res){
    res.json(users.getAllUsers());
}

function getUser(req, res){
    const user = users.getUserById(req.params.id);
    debugger;
    if(user){
        res.status(200).json(user);
    } else {
        res.status(404).json({message: 'User not found'});
    }
}

function createUser(req, res){
    const {id, password} = req.body;
    if(id && password){
        const newUser = new User(id, password);
        users.addUser(newUser);
        res.status(201).json(newUser);
    } else {
        res.status(400).json({message: 'Invalid user data'});
    }
}

function updateUser(req, res){
    const {id} = req.params;
    const {password} = req.body;
    const existingUser = users.getUserById(id);
    if(existingUser){
        const updatedUser = new User(id, password);
        users.updateUser(id, updatedUser);
        res.status(204).json(updatedUser);
    } else {
        res.status(404).json({message: 'User not found'});
    }
}

function deleteUser(req, res){
    const {id} = req.params;
    const user = users.getUserById(id);
    if(user){
        users.deleteUser(id);
        res.status(204).json({message: 'User deleted successfully'});
    } else {
        res.status(404).json({message: 'User not found'});
    }
}

module.exports = {
    getUsers,
    getUser,
    createUser,
    updateUser,
    deleteUser
};