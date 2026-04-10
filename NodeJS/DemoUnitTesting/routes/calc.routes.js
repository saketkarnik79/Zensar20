const calc=require('../controllers/calc.controller');
const express=require('express');
const router=express.Router();

router.get('/add/:a/:b',calc.add);
router.get('/subtract/:a/:b',calc.subtract);
module.exports = router;