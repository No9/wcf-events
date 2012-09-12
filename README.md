# wcf-events

An implementation of [Harmon](https://github.com/No9/harmon) to demonstrate a proxied WCF service requests with custom events for defined elements that are contained in the XML response message.

!["Turtles Growing In A Field"](https://raw.github.com/No9/wcf-events/master/docs/images/smallbrownturtles.png)

## Install
```
git clone git@github.com:No9/wcf-events.git 
```
[Install the redis for windows](https://github.com/MSOpenTech/Redis "Redis Windows")

## Usage

Start the Redis Server

Open a command prompt and cd into the root of the ```wcf-events``` folder 
Run ```node index.js``` 

Open a command prompt and cd into the root of the ```wcf-events\lib``` folder 
Run ```node socketservercluster.js```

Open the TestService.sln in the ```wcf-events\TestProject``` folder 

Run the solution and a Windows UI should appear.

Open a web browser and navigate to [The test web page](http://localhost:10001/WebPage1.aspx)

On the windows form click on the button

The web page should display the events being routed through redis and onto socket.io and finally being displayed in a web page.


![Screen Output](https://raw.github.com/No9/wcf-events/master/docs/images/output.png)

## License

(The MIT License)

Copyright (c) 2012 Anthony Whalley

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
