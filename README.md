# XMLToJSON

How to Run:
-  Console Application
1. Open Solution in visual studio
2. Set ConsoleXMLToJSON as the startup project
3. Start Debugging
4. Follow the prompt and enter the filepath\filename of the file to convert
5. Repeat step #3 and #4 as desired

-  Web API
1. Open Solution in visual studio
2. Set XMLToJSON as the startup project
3. Start Debugging and note the port in the address bar 
4. Open Postman or curl
5. Send a Post request to http://localhost:57400/api/convert/ substituting 57400 with the port # from step 3
6. Request Headers should contain Content-Type = application/x-www-form-urlencoded
7. Request Body should contain key value pair i.e. {filePath: C:\temp\original.xml}
8. Here is an example of the HTTP request:
   POST /api/convert/ HTTP/1.1
   Host: localhost:57400
   Content-Type: application/x-www-form-urlencoded
   Cache-Control: no-cache

   filePath=C%3A%5CUsers%5Cmathieu%5CDocuments%5Csample.xml

Design Decisions:
1. The Post request of Web API ConvertController uses Dependancy Injection
2. MVC Pattern is adhered to. Business logic is in Models and Application logic in controllers
3. ConversionModels's class interacts with FileModels's interface (abstraction vs concrete details) as per SOLID design's Dependancy Inversion principal. 
4. RESTful API - API method is the name of the HTTP Verb and the url (with no parameters) is responsible for scoping
5. File and Conversion Models logic re-used in API and console APP (DRY)
6. Used 3rd party library JSON.NET to convert from XML to JSON and vice versa
