<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ExpandRecursiveProgrammatically._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v8.1, Version=8.1.1.0, Culture=neutral, PublicKeyToken=9B171C9FD64DA1D1"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dxwgv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<dxe:aspxradiobutton id="ASPxRadioButton1" runat="server" Checked="True" ClientInstanceName="ASPxRadioButton1" GroupName="1" Text="Custom row expanding behavior"></dxe:aspxradiobutton>
		<dxe:aspxradiobutton id="ASPxRadioButton2" runat="server" GroupName="1" Text="Default row expanding"></dxe:aspxradiobutton>
		<dxe:aspxbutton id="ASPxButton1" runat="server" checked="True" groupname="1" text="Full Collapse" AutoPostBack="False" CausesValidation="False">
			<ClientSideEvents Click="function(s, e) {
	ASPxGridView1.CollapseAll();
}" />
		</dxe:aspxbutton>
		<dxwgv:ASPxGridView ID="ASPxGridView1" runat="server" OnCustomCallback="ASPxGridView1_CustomCallback">
			<ClientSideEvents RowExpanding="function(s, e) {
	if(ASPxRadioButton1.GetChecked()) {
		e.cancel = true;
		ASPxGridView1.PerformCallback('customexpand;' + e.visibleIndex);
	}
}" />
		</dxwgv:ASPxGridView>
	</div>
	</form>
</body>
</html>
