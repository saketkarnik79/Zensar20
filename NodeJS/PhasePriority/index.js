console.log('Start');
setTimeout(() => {
  console.log('Timeout');
}, 0);
setImmediate(() => console.log('Immediate'));
Promise.resolve().then(() => console.log('Promise'));
process.nextTick(() => console.log('Next Tick'));
console.log('End');