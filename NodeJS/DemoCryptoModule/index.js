const crypto = require('crypto');

const hash = crypto.createHash('sha256')
    .update('Hello, world!')
    .digest('hex');

console.log(`SHA-256 hash of 'Hello, world!': ${hash}`);