<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="ListViewExample.ListView" %>

<!DOCTYPE html>

<html>
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta name="viewport" content="width=device-width">
	<title></title>
	<script src="http://code.jquery.com/jquery-3.3.1.js" integrity="sha256-2Kok7MbOyxpgUVvAk/HJ2jigOSYS2auK4Pfzbm7uH60=" crossorigin="anonymous"></script>

	<style>
		.TableHeading {
			background-color: #10daee;
			border: 1px solid;
		}

		.GridItem {
			border: 1px solid;
		}

		.cityName {
			width: 50px;
		}

		.dmUrl {
			width: 200px;
		}

		.inputName {
			width: 50px;
		}
	</style>

	<script>
		$(function ()
		{
			// 儲存按鈕, 編輯Row 隱藏
			$('.btn-save, .item-editing').each(function (i, v, a)
			{
				$(this).css('display', 'none');
			});

			// 新增Row
			$('.header').on('click', '[type=button]', function ()
			{
				var $ListView = $('#ViewView');
				var $tr = $('.item').first();
				var $clone = $tr.clone();
				$clone.find('label').text('');
				$clone.find(':text').val('');
				$clone.find('td input.btn-edit').css('display', 'none');
				$clone.find('td input.btn-edit').next().css('display', '');
				$clone.find('label').css('display','none');
				$clone.find(':text').css('display','');
				$ListView .append($clone)
			});

			$('#ViewView').on("click", "[type=button]", function ()
			{
				var $className = $(this).attr('class');

				switch ($className)
				{
					case 'btn-edit':
						$(this).css('display', 'none');
						$(this).next().css('display', '');

						var $Item = $(this).parent('.GridItem').parent('.item')[0].cells;
						for (var i = 0; i < $Item.length; i++)
						{
							$Item[i].children[0].style.display = 'none';
							$Item[i].children[1].style.display = '';
						}
						break;
					case 'btn-save':
						var $btnSave = $(this);
						var $dataitems = $(this).parent('.GridItem').parent('.item').find('input[type=text]');

						var $dataitem = $dataitems.map(function (index, element, array) {
							return element.value;
						})

						var Obj = {
							'International_City_Code': $dataitem[0],
							'DM_URL': $dataitem[1],
							'Input_Name': $dataitem[2]
						};

						$.ajax({
							type: "POST",
							url: "ListView.aspx/PostData",
							async: false,
							data: JSON.stringify(Obj),
							contentType: "application/json; charset=utf-8",
							dataType: "json",
							success: function (response)
							{
								$btnSave.css('display', 'none');
								$btnSave.prev().css('display', '');

								var res = response.d;
								var objects = $.parseJSON(res);
								var $CityName = $($btnSave.parent('.GridItem').parent('.item')[0]).find('.cityName');
								$CityName[0].innerText = objects.International_City_Code;
								$CityName[1].value = objects.International_City_Code;

								var $DMUrl = $($btnSave.parent('.GridItem').parent('.item')[0]).find('.dmUrl');
								$DMUrl[0].innerText = objects.DM_URL
								$DMUrl[1].value = objects.DM_URL;

								var $InputName = $($btnSave.parent('.GridItem').parent('.item')[0]).find('.inputName');
								$InputName[0].innerText = objects.Input_Name
								$InputName[1].value = objects.Input_Name;

								var $ItemData = $btnSave.parent('.GridItem').parent('.item')[0].cells;
								for (var i = 0; i < $ItemData.length; i++)
								{
									$ItemData[i].children[0].style.display = '';
									$ItemData[i].children[1].style.display = 'none';
								}
							},
							failure: function ()
							{
								alert("error")
							}
						});

						break;
					default:
						break;
				}
			});
		});

	</script>
</head>
<body>
	<form id="form1" runat="server">
		

		<div id="Panel_List" class="Panel" style="text-align: center;">
			<table width="600px" cellpadding="4" cellspacing="0" align="center">
				<tr>
					<td>

						<%-- 資料 --%>
						<asp:ListView ID="ListView1" runat="server">

							<%-- 如查無資料, 版面的設置 --%>
							<EmptyDataTemplate>
								<table id="itemPlaceholderContainer" runat="server" cellspacing="0" cellpadding="4" border="0" frame="box">
									<tr>
										<th class="TableHeading" style="width: 80px;">城市</th>
										<th class="TableHeading" style="width: 600px;">網址</th>
										<th class="TableHeading" style="width: 80px;">建檔人</th>
										<th class="TableHeading" style="width: 40px;">
											<asp:Button ID="Button1" runat="server" Text="新增" />
										</th>
									</tr>
									<tr id="itemPlaceholder" runat="server"></tr>
								</table>
								<div style="color: blue; font-size: 13px; font-family: 'Courier New', Courier, 'Nimbus Mono L', monospace; text-align: center">（無資料）</div>
							</EmptyDataTemplate>

							<%-- 版面設置 --%>
							<LayoutTemplate>
								<table class="Grid" style="width: 100%" cellspacing="0" cellpadding="4" border="0" frame="box" id="ViewView">
									<tr class="header">
										<th class="TableHeading" style="width: 100px;">城市</th>
										<th class="TableHeading" style="width: 600px;">網址</th>
										<th class="TableHeading" style="width: 80px;">建檔人</th>
										<th class="TableHeading" style="width: 40px;">
											<input type="button" class="header" value="新增" />
										</th>
									</tr>
									<tr id="itemPlaceholder" runat="server"></tr>
									<%-- 分頁設定 --%>																												
									<table style="width:100%">
										<tr>
											<td style="text-align:left">
												<asp:DataPager ID="DataPager1" runat="server" PageSize="5" OnPreRender="DataPager1_PreRender">
													<Fields>							
														<asp:NextPreviousPagerField FirstPageText="首頁" PreviousPageText="前頁" ShowFirstPageButton="true" ShowNextPageButton="false" ButtonType="Button" />
														<asp:NumericPagerField />
														<asp:NextPreviousPagerField LastPageText="末頁" NextPageText="下頁" ShowLastPageButton="true" ShowPreviousPageButton="false" ButtonType="Button" />
													</Fields>
												</asp:DataPager>
											</td>
											<td style="text-align:right">
												<asp:DataPager ID="DataPager2" runat="server"  PageSize="5">
													<Fields>
														<asp:TemplatePagerField>
															<PagerTemplate>		
																共
																<asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>" />
																頁 (
																<asp:Label style="color:red;" runat="server" ID="TotalItemsLabel" Text="<%# Container.TotalRowCount%>" />
																筆資料)									
															</PagerTemplate>
														</asp:TemplatePagerField>
													</Fields>
												</asp:DataPager>
											</td>
										</tr>
									</table>
								</table>
							</LayoutTemplate>

							<%-- 資料 --%>
							<ItemTemplate>
								<tr id="Tr1" runat="server" class="item">
									<td class="GridItem" style="width: 100px;">
										<label class="cityName">
											<%# Eval("International_City_Code","") %>
										</label>
										<input type="text" class="item-editing cityName" value="<%# Eval("International_City_Code","") %>" />
									</td>
									<td class="GridItem" style="width: 600px;">
										<label class="dmUrl">
											<%# Eval("DM_URL","") %>
										</label>
										<input type="text" class="item-editing dmUrl" value="<%# Eval("DM_URL","") %>" />
									</td>
									<td class="GridItem" style="width: 80px;">
										<label class="inputName">
											<%# Eval("Input_Name","") %>
										</label>
										<input type="text" class="item-editing inputName" value="<%# Eval("Input_Name","") %>" />
									</td>
									<td class="GridItem" style="width: 40px;">
										<input type="button" class="btn-edit" value="編輯" />
										<input type="button" class="btn-save" value="儲存" />
									</td>
								</tr>
							</ItemTemplate>
						</asp:ListView>
					</td>
				</tr>
			</table>
		</div>
	</form>
</body>
</html>
