<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/DXWebApplication1/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/DXWebApplication1/Controllers/HomeController.vb))
* [DataProvider.cs](./CS/DXWebApplication1/Models/DataProvider.cs) (VB: [DataProvider.vb](./VB/DXWebApplication1/Models/DataProvider.vb))
* [ComboBoxPartial.cshtml](./CS/DXWebApplication1/Views/Home/ComboBoxPartial.cshtml)
* **[GridViewPartial.cshtml](./CS/DXWebApplication1/Views/Home/GridViewPartial.cshtml)**
* [Index.cshtml](./CS/DXWebApplication1/Views/Home/Index.cshtml)
<!-- default file list end -->
# GridView - How to specify a custom FilterCell Template
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e4522)**
<!-- run online end -->


<p>In MVC only an Extension can send CallBacks to the server. For this reason, when FilterRow is set to true, the GridViewDataComboBoxColumn's AutoFilterEditor.ComboBox cannot filter and load its own data.</p><p>Now this problem is solved with the help of the Filter template, where the ComboBoxExtension can be rendered.</p><p>This example demonstrates how to set up the ComboBoxExtension and put it in the FilterTemplate via the MVCxGridViewColumn.SetFilterTemplateContent method.</p>

<br/>


