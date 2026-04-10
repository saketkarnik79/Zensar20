const express = require('express');

const app=express();

app.use(express.json());
app.use((req, res, next) => {
    console.log('Request received at:', new Date().toISOString());
    console.log(`Method: ${req.method}, URL: ${req.url}`);
    next();
});
app.use((err, req, res, next) => {
    console.error('Error occurred:', err);
    res.status(500).json({ error: 'An internal server error occurred.' });
});

app.get('/users',(req,res)=>{
    const users=[
        {id:1,name:'John'},
        {id:2,name:'Jane'},
        {id:3,name:'Doe'},
        {id:4,name:'Smith'},
        {id:5,name:'Emily'}
    ];
    let query=req.query;
    let id=req.query.id;
    console.log('Query parameters:', query);

    // Filter users based on the provided ID
    const filteredUsers = id ? users.filter(user => user.id === parseInt(id)) : users;

    res.json(filteredUsers);
});

app.get('/users/:id',(req,res)=>{
    const users=[
        {id:1,name:'John'},
        {id:2,name:'Jane'},
        {id:3,name:'Doe'},
        {id:4,name:'Smith'},
        {id:5,name:'Emily'}
    ];
    let parameters=req.params;
    console.log('Route parameters:', parameters);
    let id=req.params.id;
    
    // Filter users based on the provided ID
    const filteredUsers = id ? users.filter(user => user.id === parseInt(id)) : users;

    res.json(filteredUsers);
});

app.post('/users',(req,res)=>{
   // console.log(req.body);
   console.log(`Received a POST request to create a new user: ${JSON.stringify(req.body)}`);
    //res.send('User created successfully!');
    res.status(201).json({ message: 'User created successfully!' });
});

app.listen(3000,()=>{
    console.log('Server is running on port 3000...');
});