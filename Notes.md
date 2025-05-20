# Notes from 5/20/25
Use the [NetworkStream](https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream?view=net-9.0) class to recive and decode the request. Can also be used to send Response (See Read, Write Methods)

### HTTP Request Structure
- Request line (contains HTTP method, request URI, and HTTP version)
- Headers
- Message Body (Data being sent)

```html
<REQUEST LINE>\r\n
<HEADER 1>\r\n
<HEADER 2>\r\n
...
\r\n
<BODY (optional)>
```
