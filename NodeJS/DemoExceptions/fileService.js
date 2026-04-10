const fs=require('fs');

function readFile(filePath, callBack){
    fs.readFile(filePath, 'utf-8', (err, data)=>{
        if(err){
            callBack(err, null);
        }else{
            callBack(null, data);
        }
    });
}

module.exports={
    readFile
};