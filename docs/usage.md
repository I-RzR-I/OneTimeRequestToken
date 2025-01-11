From the beginning, you must add a few rows in the `Startup.cs` class: 

-> Register service; <br /> 
-> Middleware implementation.

For the service registration add the following data in `ConfigureServices` method.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...
    
    services.RegisterOTRTService(
        o =>
            {
                o.AppName = "***"; //Current application code
                o.AppKey = "***"; //Application token encryption key
                o.AppKeyInitVector = new byte[16]; // The token encryption  initialization vector
                o.TokenValidTime = TimeSpan.FromSeconds(60); // Token alive time
                o.ExcludedPaths = new string[] { "/path1", "/path2" }; // List of excluded paths from validation
                o.AutoCleanInvalidToken = 5.0; // Time to auto clean invalid tokens
            }
        );
        
        // ...
}
```

The next step is to add middleware and endpoints using in the `Configure` method:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ...
    
    app.UseOTRTEndpointsAndMiddleware();
    
    // ...
}
```
or use only endpoints

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // ...
    
    app.UseOTRTEndpoints();
    
    // ...
}
```

On the service registration, step is available a few parameters which can be supplied:

 -> `AppName` - Current application name/code; <br />
 -> `AppKey` - Token encryption token key; <br />
 -> `AppKeyInitVector`- The token encryption initialization vector; <br />
 -> `ExcludedPaths` -  List of paths which will be excluded from validation; <br />
 -> `TokenValidTime` - Token lifetime, the default value is 5 minutes; <br />
 -> `AutoCleanInvalidToken` - Time in minutes to auto clean/remove invalid tokens.
 
 Once the service is registered, in your application will be available 2 endpoints: `/otrt/token`, and `/otrt/verify-token`.
 
### **Endpoints description:**
 
 Both endpoints process and respond in `JSON` and `XML`. This can be controlled by specifying the HTTP request header variable `Accept`.
 
 `/otrt/token` -> Generate a new access token for the specified resource.
 
| Param       | Description |
|-------------|-------------|
| HTTP method | `GET`        |
| GET query parameters | `requestPath` -> resource path for which will be generated token; <br /> `httpMethod` -> resource access HTTP method.        |

#### Example:
`JSON`
```json
//Request//:
http://localhost:5000/otrt/token?requestPath=/weatherforecast&httpMethod=GET

//Response//:
{
   "isSuccess" : true,
   "messages" : [ ],
   "response" : {
      "tokenHeaderName" : "X-XSRF-TOKEN.MyApp",
      "tokenHeaderValue" : "X-XSRF-TOKEN.MyApp.XXXXX"
   }
}
```

`XML`
```xml
//Request//:
http://localhost:5000/otrt/token?requestPath=/weatherforecast&httpMethod=GET

//Response//:
<OTRTResponse xmlns="OTRTNS" xmlns:a="http://schemas.datacontract.org/2004/07/AggregatedGenericResultMessage" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
   <a:IsSuccess>true</a:IsSuccess>
   <a:Messages xmlns:b="http://schemas.datacontract.org/2004/07/AggregatedGenericResultMessage.Models"/>
   <a:Response>
      <SoapResultResponse xmlns="AggregatedGenericResultMessage.SoapResult" xmlns:a="http://schemas.datacontract.org/2004/07/OneTimeRequestToken.Models.Result">
         <a:TokenHeaderName>X-XSRF-TOKEN.MyApp</a:TokenHeaderName>
         <a:TokenHeaderValue>X-XSRF-TOKEN.MyApp.XXXXX</a:TokenHeaderValue>
      </SoapResultResponse>
   </a:Response>
</OTRTResponse>
```
 
 `/otrt/verify-token` -> Verify the generated access token (the same one used in registered middleware).
 
 | Param       | Description |
|-------------|-------------|
| HTTP method | `POST`        |
| Body parameters | `requestPath` -> resource path for which will be generated token; <br /> `httpMethod` -> resource access HTTP method; <br /> `token` -> resource generated token        |


#### Example:
`JSON`
```json
//Request//:
http://localhost:5000/otrt/verify-token
{
    "requestPath": "/weatherforecast",
    "httpMethod": "GET",
    "token": "X-XSRF-TOKEN.MyApp.XXXXX"
}

//Response//:
{
   "isSuccess" : true,
   "messages" : [ ],
   "response" : {
      "isValid" : true
   }
}
```

`XML`
```xml
//Request//:
http://localhost:5000/otrt/verify-token
<VerifyOTRTToken>
	<RequestPath>/weatherforecast</RequestPath>
	<HttpMethod>GET</HttpMethod>
	<Token>X-XSRF-TOKEN.MyApp.XXXXX</Token>
</VerifyOTRTToken>

//Response//:
<OTRTResponse xmlns="OTRTNS" xmlns:a="http://schemas.datacontract.org/2004/07/AggregatedGenericResultMessage" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
   <a:IsSuccess>true</a:IsSuccess>
   <a:Messages xmlns:b="http://schemas.datacontract.org/2004/07/AggregatedGenericResultMessage.Models"/>
   <a:Response>
      <SoapResultResponse xmlns="AggregatedGenericResultMessage.SoapResult" xmlns:a="http://schemas.datacontract.org/2004/07/OneTimeRequestToken.Models.Result">
         <a:IsValid>true</a:IsValid>
      </SoapResultResponse>
   </a:Response>
</OTRTResponse>
```