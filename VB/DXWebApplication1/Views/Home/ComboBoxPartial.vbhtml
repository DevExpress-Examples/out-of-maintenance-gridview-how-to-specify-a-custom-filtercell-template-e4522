@ModelType DXWebApplication1.DemoModel
@Html.DevExpress().ComboBox( _
    Sub(comboSettings)
            comboSettings.Name = "comboBox"
            comboSettings.CallbackRouteValues = New With {.Controller = "Home", .Action = "ComboBoxPartial"}

            comboSettings.Width = Unit.Percentage(100)
    
            Dim properties = CType(comboSettings.Properties, ComboBoxProperties)
            properties.TextField = "Name"
            properties.ValueField = "ID"
            properties.ValueType = GetType(Integer)

            properties.CallbackPageSize = 15
            properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
        
            properties.ClientSideEvents.ValueChanged = "function(s, e) { grid.AutoFilterByColumn(grid.GetColumnByField('CategoryID'), s.GetValue()); }"

            comboSettings.PreRender = _
                Sub(s, e)
                        Dim column = CType(ViewBag.FilterTemplateContainer.Column, GridViewDataColumn)
                        CType(s, MVCxComboBox).Value = DXWebApplication1.FilterUtils.GetValueByFilterExpression(column.FilterExpression)
                End Sub
    End Sub).BindList(Model.Categories).GetHtml()