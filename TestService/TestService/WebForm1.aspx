<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestService.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="http://localhost:8090/socket.io/socket.io.js"  type="text/javascript"></script>
    <script  type="text/javascript">
        var socket = io.connect('http://localhost:8090');
        var logging = true;

        socket.on('cdcevent', function (data) {
            var txt = document.getElementById("eventdata").innerHTML;
            txt += data.item;
            document.getElementById("eventdata").innerHTML = txt + "<br />";
        });

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="eventdata">
        
    </div>
    </form>
</body>
</html>
