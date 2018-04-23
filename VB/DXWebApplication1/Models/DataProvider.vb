Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.SessionState
Imports DevExpress.Data.Filtering

Namespace DXWebApplication1
	Public Class DemoModel
		Public Sub New()
			Products = New List(Of Product)()
			Categories = New List(Of Category)()
		End Sub
		Private privateProducts As IList(Of Product)
		Public Property Products() As IList(Of Product)
			Get
				Return privateProducts
			End Get
			Private Set(ByVal value As IList(Of Product))
				privateProducts = value
			End Set
		End Property
		Private privateCategories As IList(Of Category)
		Public Property Categories() As IList(Of Category)
			Get
				Return privateCategories
			End Get
			Private Set(ByVal value As IList(Of Category))
				privateCategories = value
			End Set
		End Property
	End Class
	Public Class Category
		Public Property ID() As Integer
		Public Property Name() As String
	End Class
	Public Class Product
		Public Property ID() As Integer
		Public Property Name() As String
		Public Property Price() As Double
		Public Property Quantity() As Integer
		Public Property CategoryID() As Integer
	End Class

	Public NotInheritable Class DataProvider

		Private Sub New()
		End Sub

		Private Shared ReadOnly Property Session() As HttpSessionState
			Get
				Return HttpContext.Current.Session
			End Get
		End Property

		Public Shared Function GetDemoModel() As DemoModel
			Dim key = "62D18AD0-4311-4C75-881F-CDFD89B00BA7"
			If Session(key) Is Nothing Then
				Session(key) = CreateModel()
			End If
			Return DirectCast(Session(key), DemoModel)
		End Function

		Private Shared Function CreateModel() As Object
			Dim model = New DemoModel()
			PopulateProducts(model.Products)
			PopuplateCategories(model.Categories)
			Return model
		End Function

		Private Shared Sub PopulateProducts(ByVal products As IList(Of Product))
			Dim rnd = New Random()
			For i = 0 To 1999
				products.Add(New Product() With {.ID = i, .Name = "Name " & i, .Price = Math.Round(rnd.NextDouble() * 100, 2), .Quantity = rnd.Next(1, 20), .CategoryID = i Mod 200})
			Next i
		End Sub

		Private Shared Sub PopuplateCategories(ByVal categories As IList(Of Category))
			For i = 0 To 199
				categories.Add(New Category() With {.ID = i, .Name = "Category " & i})
			Next i
		End Sub
	End Class

	Public NotInheritable Class FilterUtils

		Private Sub New()
		End Sub

		Public Shared Function GetValueByFilterExpression(ByVal filterExpression As String) As Object
			Dim op = CriteriaOperator.Parse(filterExpression)
			If ReferenceEquals(op, Nothing) Then
				Return Nothing
			End If

			Dim binaryOp = TryCast(op, BinaryOperator)
			If ReferenceEquals(binaryOp, Nothing) AndAlso binaryOp.OperatorType <> BinaryOperatorType.Equal Then
				Return Nothing
			End If

			Dim opValue = TryCast(binaryOp.RightOperand, OperandValue)
			If ReferenceEquals(opValue, Nothing) Then
				Return Nothing
			End If

			Return opValue.Value
		End Function
	End Class
End Namespace