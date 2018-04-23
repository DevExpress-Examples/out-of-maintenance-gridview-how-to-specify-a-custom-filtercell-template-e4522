using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using DevExpress.Data.Filtering;

namespace DXWebApplication1 {
    public class DemoModel {
        public DemoModel() {
            Products = new List<Product>();
            Categories = new List<Category>();
        }
        public IList<Product> Products { get; private set; }
        public IList<Category> Categories { get; private set; }
    }
    public class Category {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Product {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
    }

    public static class DataProvider {
        static HttpSessionState Session { get { return HttpContext.Current.Session; } }

        public static DemoModel GetDemoModel() {
            var key = "62D18AD0-4311-4C75-881F-CDFD89B00BA7";
            if (Session[key] == null)
                Session[key] = CreateModel();
            return (DemoModel)Session[key];
        }

        static object CreateModel() {
            var model = new DemoModel();
            PopulateProducts(model.Products);
            PopuplateCategories(model.Categories);
            return model;
        }

        static void PopulateProducts(IList<Product> products) {
            var rnd = new Random();
            for (var i = 0; i < 2000; i++)
                products.Add(new Product()
                {
                    ID = i,
                    Name = "Name " + i,
                    Price = Math.Round(rnd.NextDouble() * 100, 2),
                    Quantity = rnd.Next(1, 20),
                    CategoryID = i % 200
                });
        }

        static void PopuplateCategories(IList<Category> categories) {
            for (var i = 0; i < 200; i++)
                categories.Add(new Category()
                {
                    ID = i,
                    Name = "Category " + i,
                });
        }
    }

    public static class FilterUtils {
        public static object GetValueByFilterExpression(string filterExpression) {
            var op = CriteriaOperator.Parse(filterExpression);
            if (ReferenceEquals(op, null))
                return null;

            var binaryOp = op as BinaryOperator;
            if (ReferenceEquals(binaryOp, null) && binaryOp.OperatorType != BinaryOperatorType.Equal)
                return null;

            var opValue = binaryOp.RightOperand as OperandValue;
            if (ReferenceEquals(opValue, null))
                return null;

            return opValue.Value;
        }
    }
}