Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WinSolution3.Module
	<DefaultClassOptions> _
	Public Class DomainObject2
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
		Private _DomainObject1 As DomainObject1
		<Association("DomainObject1-DomainObject2s")> _
		Public Property DomainObject1() As DomainObject1
			Get
				Return _DomainObject1
			End Get
			Set(ByVal value As DomainObject1)
				SetPropertyValue("DomainObject1", _DomainObject1, value)
			End Set
		End Property
	End Class
End Namespace
