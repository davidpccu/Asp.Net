<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListView2.aspx.cs" Inherits="ListViewExample.ListView2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title></title>
	<style type="text/css">
		.txt_HotelRemark {
			width: 400px;
			height: 120px;
		}
	</style>
</head>
<body>
	<form id="form1" runat="server">
		<%-- 旅館備註List --%>
		<asp:Panel ID="Panel_List" runat="server" HorizontalAlign="Center">
			<table cellspacing="0" cellpadding="4" width="100%" align="center" border="0">
				<tr>
					<td>
						<asp:ListView ID="ListView1" runat="server">

							<%-- 如查無資料, 版面的設置 --%>
							<EmptyDataTemplate>
								<table id="itemPlaceholderContainer" runat="server" cellspacing="0" cellpadding="4" border="0" frame="box">
									<tr>
										<th class="TableHeading" style="width: 100px; height: 30px;">建檔日期</th>
										<th class="TableHeading" style="width: 390px; height: 30px;">備註內容</th>
										<th class="TableHeading" style="width: 70px; height: 30px;">建檔人</th>
									</tr>
									<tr id="itemPlaceholder" runat="server"></tr>
								</table>
								<div style="color: blue; font-size: 13px; font-family: 'Courier New', Courier, 'Nimbus Mono L', monospace">（備註無歷史紀錄）</div>
							</EmptyDataTemplate>

							<%-- 版面設置 --%>
							<LayoutTemplate>
								<table id="itemPlaceholderContainer" runat="server" cellspacing="0" cellpadding="4" border="0" frame="box">
									<%-- 欄位標題 --%>
									<tr>
										<th class="TableHeading" style="width: 100px; height: 30px;">建檔日期</th>
										<th class="TableHeading" style="width: 390px; height: 30px;">備註內容</th>
										<th class="TableHeading" style="width: 70px; height: 30px;">建檔人</th>
									</tr>
									<%-- 欄位內容 --%>
									<tr id="itemPlaceholder" runat="server"></tr>
								</table>

								<%-- 分頁設定 --%>
								<table style="width: 100%">
									<tr>
										<td style="text-align: left">
											<asp:DataPager ID="DataPager1" runat="server" PageSize="5" OnPreRender="DataPager1_PreRender">
												<Fields>
													<asp:NextPreviousPagerField FirstPageText="首頁" PreviousPageText="前頁" ShowFirstPageButton="true" ShowNextPageButton="false" ButtonType="Button" />
													<asp:NumericPagerField />
													<asp:NextPreviousPagerField LastPageText="末頁" NextPageText="下頁" ShowLastPageButton="true" ShowPreviousPageButton="false" ButtonType="Button" />
												</Fields>
											</asp:DataPager>
										</td>
										<td style="text-align: right">
											<asp:DataPager ID="DataPager2" runat="server" PageSize="5">
												<Fields>
													<asp:TemplatePagerField>
														<PagerTemplate>
															共
															<asp:Label runat="server" ID="TotalPagesLabel" Text="<%# Math.Ceiling ((double)Container.TotalRowCount / Container.PageSize) %>" />
															頁 (
															<asp:Label Style="color: red;" runat="server" ID="TotalItemsLabel" Text="<%# Container.TotalRowCount%>" />
															筆資料)									
														</PagerTemplate>
													</asp:TemplatePagerField>
												</Fields>
											</asp:DataPager>
										</td>
									</tr>
								</table>
							</LayoutTemplate>

							<%-- 欄位內容 --%>
							<ItemTemplate>
								<tr>
									<td >
										<%# Set_InputTime( DateTime.Parse(Eval("Input_Time","")) ) %>
									</td>
									<td >
										<%# Set_HotelRemark( Eval("Hotel_Remark","")) %>
									</td>
									<td >
										<%# Set_InputName( Eval("Input_Name","")) %>
									</td>
								</tr>
							</ItemTemplate>

						</asp:ListView>
					</td>
				</tr>
			</table>
		</asp:Panel>

	</form>
</body>
</html>
