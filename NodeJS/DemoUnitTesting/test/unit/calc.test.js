const request = require('supertest');
const {expect} = require('chai');

const app = require('../../app');

describe('Calculator API', () => {
    describe('GET /calc/add/:a/:b', () => {
        it('should return the sum of two numbers', async () => {
            const response = await request(app)
                .get('/calc/add/5/3')
                .expect(200);
            expect(response.body.result).to.equal(8);
        });
    });

    describe('GET /calc/subtract/:a/:b', () => {
        it('should return the difference of two numbers', async () => {
            const response = await request(app)
                .get('/calc/subtract/10/4')
                .expect(200);
            expect(response.body.result).to.equal(6);
        });
    });
});