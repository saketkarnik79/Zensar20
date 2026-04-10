// //Creating a buffer from a string

// const buffer = Buffer.from('Hello, World!', 'hex');
// console.log(buffer); // Output: <Buffer 48 65 6c 6c 6f 2c 20 57 6f 72 6c 64 21>
// console.log(buffer.toString()); // Output: Hello, World!

// //Creating an empty buffer of a specific size
// const emptyBuffer = Buffer.alloc(10);
// console.log(emptyBuffer); // Output: <Buffer 00 00 00 00 00 00 00 00 00 00>
// console.log(emptyBuffer.toString()); // Output: (empty string)
// emptyBuffer.write('Hello');
// console.log(emptyBuffer); // Output: <Buffer 48 65 6c 6c 6f 00 00 00 00 00>
// console.log(emptyBuffer.toString()); // Output: Hello
// emptyBuffer[5] = 87; // ASCII code for 'W'
// console.log(emptyBuffer); // Output: <Buffer 48 65 6c 6c 6f 00 57 00 00 00>
// console.log(emptyBuffer.toString()); // Output: HelloW

// const buffer2 = Buffer.from('ABCDEFGHIJKLMNOPQRSTUVWXYZ');
// console.log(buffer2); // Output: <Buffer 41 42 43 44 45 46 47 48 49 4a 4b 4c 4d 4e 4f 50 51 52 53 54 55 56 57 58 59 5a>
// console.log(buffer2.toString()); // Output: ABCDEFGHIJKLMNOPQRSTUVWXYZ


//Buffer & Stream Relation
const fs = require('fs');
const stream = fs.createReadStream('data.txt', { highWaterMark: 2 }); // Read in chunks of 2 bytes

stream.on('data', (chunk) => {
  console.log('Received chunk:', chunk); //Buffer object
  console.log('Chunk as string:', chunk.toString()); //String representation of the chunk
});