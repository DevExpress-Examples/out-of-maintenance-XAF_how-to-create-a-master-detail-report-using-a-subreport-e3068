Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Editors

Namespace WinSolution3.Module
	<DefaultClassOptions> _
	Public Class DomainObject1
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _Name As String
		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _Name, value)
			End Set
		End Property
		Private _Description As String
		Public Property Description() As String
			Get
				Return _Description
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Description", _Description, value)
			End Set
		End Property
		Private _Value As Integer
		Public Property Value() As Integer
			Get
				Return _Value
			End Get
			Set(ByVal value As Integer)
				SetPropertyValue("Value", _Value, value)
			End Set
		End Property
		<Association("DomainObject1-DomainObject2s")> _
		Public ReadOnly Property DomainObject2s() As XPCollection(Of DomainObject2)
			Get
				Return GetCollection(Of DomainObject2)("DomainObject2s")
			End Get
		End Property
	End Class
End Namespace
