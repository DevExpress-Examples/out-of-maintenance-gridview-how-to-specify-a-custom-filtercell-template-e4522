# GridView - How to specify a custom FilterCell Template


<p>In MVC only an Extension can send CallBacks to the server. For this reason, when FilterRow is set to true, the GridViewDataComboBoxColumn's AutoFilterEditor.ComboBox cannot filter and load its own data.</p><p>Now this problem is solved with the help of the Filter template, where the ComboBoxExtension can be rendered.</p><p>This example demonstrates how to set up the ComboBoxExtension and put it in the FilterTemplate via the MVCxGridViewColumn.SetFilterTemplateContent method.</p>

<br/>


