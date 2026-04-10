function getUserById(userId) {
    return new Promise((resolve, reject) => {
        if(!userId) {
            reject(new Error('User ID is required'));
        }
        // Simulate a database call with a timeout
        setTimeout(() => {
            const users = [
                { id: 1, name: 'Alice' },
                { id: 2, name: 'Bob' },
                { id: 3, name: 'Charlie' }
            ];
            const user = users.find(u => u.id === userId);
            if (!user) {
                reject(new Error('User not found'));
            } else {
                resolve(user);
            }
        }, 1000);
    });
}

module.exports = {
    getUserById
};