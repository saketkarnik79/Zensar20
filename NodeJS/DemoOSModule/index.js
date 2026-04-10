const os = require('os');

console.log(os.platform());
console.log(os.arch());
console.log(os.totalmem());
console.log(os.freemem());
console.log(os.hostname());
console.log(os.release());
console.log(os.uptime());
console.log(os.cpus().length);
console.log(os.networkInterfaces());
console.log(os.userInfo());
console.log(os.tmpdir());
console.log(os.homedir());
console.log(os.availableParallelism());