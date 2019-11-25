       const express = require('express');
       const app = express();
       const fs = require('fs');
       
       const PORT = 3212;
       const FILE = './feedbacks.json';
       
       var http = require('http');
   
   
   fs.readFile('./index.html', function (err, html) {
       if (err) {
           throw err; 
       }       
       http.createServer(function(request, response) {  
           response.writeHeader(200, {"Content-Type": "text/html"});  
           response.write(html);  
           response.end();  
       }).listen(3211);
   });

       async function writeToFile(body) {
           console.log("Writing to file");
           const comments = await readFromFile();
           comments.push(body);
           const error = fs.writeFileSync('./feedbacks.json', JSON.stringify(comments));
           return error;
       }
       
       async function readFromFile() {
           const rawdata = await fs.readFileSync('./feedbacks.json', 'utf8');
           const comments = JSON.parse(rawdata);
       
           return comments;
       }
       
       app.use(express.json());
       app.use(express.urlencoded({ extended: true }));
       
       app.post('/feedbacks', async function(req, res) {
           await writeToFile(req.body);
               res.json({
                   success: true,
                   body: req.body
               });
       });
       
       app.get('/feedbacks', async function(req, res) {
           res.json({
               success: true,
               body: await readFromFile()
           });
       });
       
       app.listen(PORT, () => console.log(`Server app listening on port ${PORT}!`));

       

        // var currentDate = new Date();
        // document.getElementById('date').value = currentDate;
        // //document.getElementById("ass").addEventListener("click", writeToFile(this)); 
        // document.getElementById("submitFeedback").addEventListener("click", function(){
        // document.getElementById("demo").innerHTML = "Hello World";});
    
    
 
        