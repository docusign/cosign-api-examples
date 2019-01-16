'use strict';

var fs = require('fs');

// function to encode file data to base64 encoded string
function base64_encode(file) {
    // read binary data
    var bitmap = fs.readFileSync(file);
    // convert binary data to base64 encoded string
    return new Buffer.from(bitmap).toString('base64');
}

// function to create file from base64 encoded string
function base64_decode(base64str, file) {
    // create buffer object from base64 encoded string, it is important to tell the constructor that the string is base64 encoded
    var bitmap = new Buffer.from(base64str, 'base64');
    // write buffer to file
    fs.writeFileSync(file, bitmap);
}

// convert PDF to base64 encoded string
var base64PDFstr = base64_encode('c:\\tmp\\PurchaseOrder.pdf');

//prepare 'digital_signature' request
var request = require("request");

var options = {
    method: 'PUT',
    url: 'https://prime-dsa-devctr.docusign.net:8081/sapiws/v1/digital_signature',
    headers:
        {
            'content-type': 'application/json',
            authorization: 'Basic ' + Buffer.from("John Miller" + ":" +"12345678").toString('base64')
        },
    body:
        {
            CreateAndSignField:
                {
                    file: base64PDFstr,
                    FileType: 'PDF',
                    x: '359',
                    y: '149',
                    width: '123',
                    height: '53',
                    Reason: 'Purchase approved',
                    appearance: ['GRAPHICAL_IMAGE', 'SIGNED_BY', 'REASON']
                }
        },
    json: true
};

console.log('calling PUT https://prime-dsa-devctr.docusign.net:8081/sapiws/v1/digital_signature');

//make the call
request(options, function (error, response, body) {
    if (error) throw new Error(error);

    console.log('call returned ...');
    // convert base64 string back to signed PDF binary file 
    base64_decode(body.signedFile, "c:\\tmp\\PurchaseOrder.Node-JS-Signed.pdf");
    console.log('******** Signed PDF created from base64 encoded string ********');
});

