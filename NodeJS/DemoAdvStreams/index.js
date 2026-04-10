//Read bigfile.txt without streams
// const fs = require('fs');
// const startTime = new Date();
// const data = fs.readFileSync('bigfile.txt', 'utf8');
// console.log(data);
// const endTime = new Date();
// console.log(`Time taken: ${endTime - startTime} ms`);

//Read bigfile.txt with streams
const fs = require('fs');
const startTime = new Date();
const stream= fs.createReadStream('bigfile.txt', 'utf8');
let chunkCount = 0;
stream.on('data', (chunk) => {
    chunkCount++;
    // console.log(`Chunk ${chunkCount}:`, chunk);
    console.log(`Chunk ${chunkCount}: ${chunk.length} characters`);
});
stream.on('end', () => {
    const endTime = new Date();
    console.log(`Time taken: ${endTime - startTime} ms`);
});
stream.on('error', (err) => {
    console.error('Error reading file:', err);
});
stream.on('close', () => {
    console.log('Stream closed');
});