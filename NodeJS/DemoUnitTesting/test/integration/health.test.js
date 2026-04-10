const request = require('supertest');
const {expect} = require('chai');
const app = require('../../app');

describe('Health Check API', () => {
    it('should return status ok', async () => {
        const response = await request(app)
            .get('/health')
            .expect(200);
        expect(response.body.status).to.equal('ok');
    });
});