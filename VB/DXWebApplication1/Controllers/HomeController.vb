Imports System
Imports System.Web.Mvc

Namespace DXWebApplication1.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function
		Public Function GridViewPartial() As ActionResult
			Return PartialView(DataProvider.GetDemoModel())
		End Function
		Public Function ComboBoxPartial() As ActionResult
			Return PartialView(DataProvider.GetDemoModel())
		End Function
	End Class
End Namespace