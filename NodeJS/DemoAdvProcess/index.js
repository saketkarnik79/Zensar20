// console.log(process.argv.length);
// console.log(process.argv);
// console.log(process.argv[2]);
// console.log(process.argv[3]);

console.log(`Node.js version: ${process.version}`);
console.log(`Platform: ${process.platform}`);
console.log(`Process ID: ${process.pid}`);
console.log(`Current working directory: ${process.cwd()}`);
console.log(`Memory usage: ${JSON.stringify(process.memoryUsage())}`);
console.log(`CPU Usage: ${JSON.stringify(process.cpuUsage())}`);

console.log(`PROJ_ENV value: ${process.env.PROJ_ENV}`);

const environment = process.env.PROJ_ENV;

if (environment === 'production' || environment === 'prod') {
    console.log('Running in production mode');
}
else if (environment === 'development' || environment === 'dev') {
    console.log('Running in development mode');
    //throw new Error('Simulated error in development mode');
}

process.on('exit', (code) => {
    console.log(`Exiting with code: ${code}`);
});

process.on('uncaughtException', (err) => {
    console.error('Uncaught Exception:', err);
    process.exit(1);
});

process.on('unhandledRejection', (reason, promise) => {
    console.error('Unhandled Rejection at:', promise, 'reason:', reason);
    process.exit(1);   
});

process.on('SIGINT', () => {
    console.log('Received SIGINT. Exiting gracefully...');
    process.exit(0);
});

process.on('SIGTERM', () => {
    console.log('Received SIGTERM. Exiting gracefully...');
    process.exit(0);
});

process.exit(0);

console.log('This will not be printed');