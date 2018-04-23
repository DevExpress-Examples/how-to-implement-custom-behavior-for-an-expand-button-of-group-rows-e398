Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace ExpandRecursiveProgrammatically
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			ASPxGridView1.DataSource = GetDataSource()
			ASPxGridView1.KeyFieldName = "ID"
			ASPxGridView1.DataBind()

			If (Not IsPostBack) AndAlso (Not IsCallback) Then
				ASPxGridView1.GroupBy(ASPxGridView1.Columns("Group"))
				ASPxGridView1.GroupBy(ASPxGridView1.Columns("Subgroup"))
			End If
		End Sub

		Private Function GetDataSource() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Group")
			table.Columns.Add("Subgroup")
			table.Columns.Add("ItemName")
			table.Rows.Add(1, "Group A", "Subgroup 1", "Data Item")
			Return table
		End Function

		Protected Sub ASPxGridView1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs)
			If e.Parameters Is Nothing Then
				Return
			End If
			Dim param() As String = e.Parameters.Split(";"c)
			If param.Length = 2 AndAlso param(0) = "customexpand" Then
				ASPxGridView1.ExpandRow(Convert.ToInt32(param(1)), True)
			End If
		End Sub
	End Class
End Namespace
