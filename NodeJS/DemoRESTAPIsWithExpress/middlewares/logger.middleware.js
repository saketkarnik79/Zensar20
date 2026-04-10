const logger = (req, res, next) => {
    const startTime = Date.now();

    //Log incoming request details
    console.log(`[REQUEST]: ${req.method} ${req.originalUrl} - ${new Date().toISOString()}`);

    //Hook into the response finish event to log outgoing response details
    res.on('finish', () => {
        const duration = Date.now() - startTime;
        console.log(`[RESPONSE]: ${req.method} ${req.originalUrl} - Status: ${res.statusCode} - Duration: ${duration}ms`);
    });
    next();
};

module.exports = logger;