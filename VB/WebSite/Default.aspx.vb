Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
		Protected Sub grid_CustomColumnGroup(ByVal sender As Object, ByVal e As CustomColumnSortEventArgs)
		If e.Column IsNot Nothing AndAlso e.Column.FieldName = "ProductName" Then
			Dim intervalValue1 As Integer= GetInterval(e.Value1.ToString())
			Dim intervalValue2 As Integer= GetInterval(e.Value2.ToString())
			e.Result = Comparer.Default.Compare(intervalValue1,intervalValue2)
			e.Handled = True
		End If
		End Sub
	Private Function GetInterval(ByVal str As String) As Integer
		str = str.ToLower()
		Dim ch As Char = str.Chars(0)
		If ch >= "a"c AndAlso ch <= "e"c Then
			Return 1
		End If
		If ch >= "f"c AndAlso ch <= "j"c Then
			Return 2
		End If
		If ch >= "k"c AndAlso ch <= "q"c Then
			Return 3
		End If
		If ch >= "r"c AndAlso ch <= "v"c Then
			Return 4
		End If
		If ch >= "w"c AndAlso ch <= "z"c Then
			Return 5
		End If
		Return -1
	End Function
	Protected Sub grid_CustomGroupDisplayText(ByVal sender As Object, ByVal e As ASPxGridViewColumnDisplayTextEventArgs)
		If e.Column.FieldName <> "ProductName" Then
			Return
		End If
		Dim interval As Integer = GetInterval(e.Value.ToString())
		Select Case interval
			Case 1
				e.DisplayText = "A-E"
			Case 2
				e.DisplayText = "F-J"
			Case 3
				e.DisplayText = "K-Q"
			Case 4
				e.DisplayText = "R-V"
			Case 5
				e.DisplayText = "W-Z"
		End Select
	End Sub
End Class
