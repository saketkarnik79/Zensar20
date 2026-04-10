const User = require('../models/user');

let users = [
    new User('john', 'john123'),
    new User('jane', 'jane123'),
    new User('doe', 'doe123')
];

function getAllUsers(){
    return users;
}

function getUserById(id){
    return users.find(user => user.id === id);
}

function addUser(user){
    users.push(user);
}

function updateUser(id, newUser){
    let index = users.findIndex(user => user.id === id);
    if(index !== -1){
        users[index] = newUser;
    }
}

function deleteUser(id){
    users = users.filter(user => user.id !== id);
}

module.exports = {
    getAllUsers,
    getUserById,
    addUser,
    updateUser,
    deleteUser
};