function add(req, res) {
    const { a, b } = req.params;
    const result = parseFloat(a) + parseFloat(b);
    res.json({ result });
}

function subtract(req, res) {
    const { a, b } = req.params;
    const result = parseFloat(a) - parseFloat(b);
    res.json({ result });
}

module.exports = {
    add,
    subtract
};