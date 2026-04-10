const fs= require('fs');

const readStream= fs.createReadStream('./bigfile.txt', { encoding: 'utf-8', highWaterMark: 16 }); //chunk size
readStream.on('data', (chunk) => {
    console.log(`Chunk received: ${chunk}`);
});

readStream.on('end', () => {
    console.log('Finished reading the file.');
});
readStream.on('error', (err) => {
    console.error('Error reading the file:', err);
});
readStream.on('close', () => {
    console.log('Stream closed.');
});