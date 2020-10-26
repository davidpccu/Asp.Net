<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HttpReqRes.aspx.cs" Inherits="HttpReqRes.HttpReqRes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<table>
				<tr>
					<td style="width: 50%;">
						<asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
						<br />
						<asp:Button ID="Button1" runat="server" Text="request" OnClick="Button1_Click" />
						<br />
						<asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple" Height="200px"></asp:ListBox>
					</td>
					<td style="width: 50%;">
						<br />
						<asp:Button ID="Button2" runat="server" Text="request" OnClick="Button2_Click" />
						<br />
						<asp:ListBox ID="ListBox2" runat="server" SelectionMode="Multiple" Height="200px"></asp:ListBox>
					</td>
				</tr>
			</table>
			<br />
			------------------------------------------------------------
			<asp:Button ID="Button3" runat="server" Text="取網頁資料" OnClick="Button3_Click"/>
			<br />
			<asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="500px" Height="800px"></asp:TextBox>
			<br />
			--------------------------------------------------------------
			<asp:Button ID="Button4" runat="server" Text="取網頁資料2" OnClick="Button4_Click" />
			<br />
			--------------------------------------------------------------
			<asp:Button ID="Button5" runat="server" Text="Button" OnClick="Button5_Click" />
		</div>
	</form>
</body>
</html>
