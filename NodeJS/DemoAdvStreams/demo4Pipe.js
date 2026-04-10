const fs=require('fs');
fs.createReadStream('bigfile.txt')
    .pipe(fs.createWriteStream('bigfile-copy.txt'))
    .on('finish',()=>{
        console.log('File copy completed!');
    })
    .on('error',(err)=>{
        console.error('Error during file copy:', err);
    })
    .on('close',()=>{
        console.log('File streams closed.');
    })
    .on('end',()=>{
        console.log('File copy ended.');
    });