@ModelType DXWebApplication1.DemoModel
@Html.DevExpress().GridView( _
    Sub(settings)
            settings.Name = "grid"
            settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

            settings.CommandColumn.Visible = True
            settings.CommandColumn.ShowClearFilterButton = True
    
            settings.Columns.Add("Name", "Product")
            settings.Columns.Add( _
                Sub(c)
                        c.FieldName = "Price"
                        c.ColumnType = MVCxGridViewColumnType.TextBox
                        CType(c.PropertiesEdit, TextBoxProperties).DisplayFormatString = "c"
                End Sub)
            settings.Columns.Add("Quantity")
            settings.Columns.Add( _
                Sub(c)
                        c.FieldName = "CategoryID"
                        c.Caption = "Category"
                        c.ColumnType = MVCxGridViewColumnType.ComboBox

                        Dim comboBoxProperties = CType(c.PropertiesEdit, ComboBoxProperties)
                        comboBoxProperties.DataSource = Model.Categories
                        comboBoxProperties.ValueField = "ID"
                        comboBoxProperties.ValueType = GetType(Integer)
                        comboBoxProperties.TextField = "Name"

                        c.SetFilterTemplateContent( _
                            Sub(t)
                                    ViewBag.FilterTemplateContainer = t
                                    Html.RenderPartial("ComboBoxPartial", Model)
                            End Sub)
                End Sub)
            settings.Settings.ShowFilterRow = True
    End Sub).Bind(Model.Products).GetHtml()