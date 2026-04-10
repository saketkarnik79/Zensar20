const fs =require('fs');

const readStream = fs.createReadStream('bigfile.txt');

readStream.on('data', (chunk) => {
    console.log('Received chunk:', chunk.toString());
});