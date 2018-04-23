Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Reports
Imports System.Collections

Namespace WinSolution3.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			CreateReport("DetailReport")
			CreateReport("MasterReport")
			CreateMaster("Master 1", New Object(){ CreateDetail("Detail 1"), CreateDetail("Detail 2"), CreateDetail("Detail 3")})
			CreateMaster("Master 2", New Object(){ CreateDetail("Detail 4"), CreateDetail("Detail 5")})
			CreateMaster("Master 3", New Object(){ CreateDetail("Detail 6"), CreateDetail("Detail 7"), CreateDetail("Detail 8"), CreateDetail("Detail 9")})
		End Sub
		Private Sub CreateReport(ByVal reportName As String)
			Dim reportdata As ReportData = ObjectSpace.FindObject(Of ReportData)(New BinaryOperator("Name", reportName))
			If reportdata Is Nothing Then
				reportdata = ObjectSpace.CreateObject(Of ReportData)()
				Dim rep As New XafReport()
				rep.ObjectSpace = ObjectSpace
				rep.LoadLayout(Me.GetType().Assembly.GetManifestResourceStream("SavedReports." & reportName & ".repx"))
				rep.ReportName = reportName
				reportdata.SaveReport(rep)
				reportdata.Save()
			End If
		End Sub
		Private Function CreateMaster(ByVal name As String, ByVal details As ICollection) As DomainObject1
			Dim master As DomainObject1 = ObjectSpace.FindObject(Of DomainObject1)(New BinaryOperator("Name", name))
			If master Is Nothing Then
				master = ObjectSpace.CreateObject(Of DomainObject1)()
				master.Name = name
				For Each detail As DomainObject2 In details
					master.DomainObject2s.Add(detail)
				Next detail
				master.Save()
			End If
			Return master
		End Function
		Private Function CreateDetail(ByVal name As String) As DomainObject2
			Dim detail As DomainObject2 = ObjectSpace.FindObject(Of DomainObject2)(New BinaryOperator("Name", name))
			If detail Is Nothing Then
				detail = ObjectSpace.CreateObject(Of DomainObject2)()
				detail.Name = name
				detail.Save()
			End If
			Return detail
		End Function
	End Class
End Namespace
