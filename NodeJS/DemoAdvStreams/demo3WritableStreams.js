const fs=require('fs');
const writeStream=fs.createWriteStream('demo3.txt');
writeStream.write('Hello World\n');
writeStream.write('Welcome to Node.js\n');
writeStream.end('This is the end of the stream.');

writeStream.on('finish',()=>{
    console.log('All data has been written to the file.');
});

writeStream.on('error',(err)=>{
    console.error('Error writing to file:', err);
});

writeStream.on('close',()=>{
    console.log('The stream has been closed.');
});
