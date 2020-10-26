<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="fullCalendar.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="js/fullcalendar.min.css" rel="stylesheet" />
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.7.2.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/qtip2/2.0.0/jquery.qtip.min.js"></script>
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/locale/zh-tw.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#calendar').fullCalendar({
                events: "/handleCalendar.ashx"
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="calendar"></div>
    </form>
</body>
</html>
