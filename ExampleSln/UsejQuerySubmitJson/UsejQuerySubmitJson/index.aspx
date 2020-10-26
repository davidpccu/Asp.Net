<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="UsejQuerySubmitJson.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
	<script src="http://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=" crossorigin="anonymous"></script>
	<script>
		$(function ()
		{
			//點選新增時，將定義好的div Template抓回，取代掉使用者字串，將Html加入UserList這個div裡面
			$('#btn_add').click(function ()
			{
				var Template = $('.UserTemplate').html().replace('UserName', $('#UserName').val());
				$('#UserList').append(Template);
			});

			//點選儲存
			$('#btn_save').click(function ()
			{
				var Users = new Array();
				//找出UserList裡面的fieldset區塊，抓取使用者資料
				$('#UserList').find('fieldset').each(function ()
				{
					var self = $(this);
					var User = {};
					User.Skill = [];
					User.UserName = $(self).find('legend').html();
					//找出所有勾選的技能
					$(self).find('input[type="checkbox"]:checked').each(function ()
					{
						User.Skill.push($(this).val());
					});
					Users.push(User);
				});

				//console.log(JSON.stringify(Users));
				$.ajax({
					url: 'HandleIndex.ashx',
					data: { array: JSON.stringify(Users) }, //將陣列轉成Json
					type: 'GET',
					contentType: 'application/json; charset=utf-8',
					dataType: 'json',
					success: function (data)
					{
						console.dir(data);
						alert("Save!");
					},
					error: function () { 
						alert('error');
					}
				});
			});
		});

	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div class="UserTemplate" style="display: none;">
			<fieldset>
				<legend>UserName</legend>
				<input type="checkbox" value="asp" />ASP.NET
                <input type="checkbox" value="php" />PHP
                <input type="checkbox" value="jsp" />JSP
			</fieldset>
		</div>
		<div>
			<input type="text" id="UserName" />
			<input type="button" id="btn_add" value="新增" />
			<input type="button" id="btn_save" value="儲存" />
			<div id="UserList">
			</div>
		</div>
	</form>
</body>
</html>
