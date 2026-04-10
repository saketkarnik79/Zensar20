const EventEmitter = require('events');
const fs = require('fs');

class FileProcessor extends EventEmitter {
    constructor() {
        super();
    }

    process(filePath) {
        fs.readFile(filePath, 'utf8', (err, data) => {
            if (err) {
                this.emit('error', err);
                return;
            }
            this.emit('file:processed', data);
        });

    }
}

module.exports = FileProcessor;