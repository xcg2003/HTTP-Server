# Notes
Use the [NetworkStream](https://learn.microsoft.com/en-us/dotnet/api/system.net.sockets.networkstream?view=net-9.0) class to recive and decode the request. Can also be used to send Response (See Read, Write Methods)

### HTTP Request Structure
- Request line (contains HTTP method, request URI, and HTTP version)
  - Example: GET /index.html HTTP/1.1\r\n
  - Read the first line using \r\n as the delimiter — that's your request line.
 
- Headers
  - The end of the headers is marked by an empty line: \r\n
  - After reading the request line, read line-by-line. Stop when you get an empty line (just \r\n). That marks the end of the headers.
       
- Message Body (Data being sent)
  - 3 cases to know if the message body is over
    - Case 1: Content-Length Header (Most Common for POST/PUT)
      - If a body is present (e.g., in a POST), the server knows how many bytes to read based on the Content-Length header
      - Read exactly Content-Length bytes after the \r\n\r\n

    - Case 2: Transfer-Encoding: chunked
        - Used in streaming scenarios or when content length is unknown ahead of time.
        - Body is sent in chucks like this:

        ```html
        Transfer-Encoding: chunked\r\n
        \r\n
        4\r\n
        Wiki\r\n
        5\r\n
        pedia\r\n
        0\r\n
        \r\n
        ```
        -  End of body is marked by a chunk size of 0, followed by a blank line

    - Case 3: GET Requests or No Body
      - GET requests typically have no body, so after the headers end (\r\n\r\n), there's nothing more to read.
  
### Example Request
```html
<REQUEST LINE>\r\n
<HEADER 1>\r\n
<HEADER 2>\r\n
...
\r\n
<BODY (optional)>
```
