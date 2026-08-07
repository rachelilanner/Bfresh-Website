using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CategoryDB:BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Category c = be as Category;
            c.Id = Convert.ToInt32(reader["Id"]);
            c.CategoryName = reader["CategoryName"].ToString();
            c.Topping= Convert.ToBoolean(reader["Topping"]);
            c.PriceSmall = Convert.ToInt32(reader["PriceSmall"]);
            c.PriceMedium = Convert.ToInt32(reader["PriceMedium"]);
            c.PriceLarge = Convert.ToInt32(reader["PriceLarge"]);

            return c;
        }
        public override BaseEntity NewEntity()
        {
            return new Category() as BaseEntity;
        }

        public CategoryList SelectAllCategory()
        {
            command.CommandText = "SELECT * FROM Category";

            CategoryList c = new CategoryList(base.Select());
            return c;
        }
        public Category SelectByIDCategory(int id)
        {
            command.CommandText = "SELECT * FROM Category WHERE Category.ID = " + id + "";
            CategoryList c = new CategoryList(base.Select());
            if (c.Count > 0)
                return c[0];
            return null;
        }

        public void InsertCategory(Category c)

        {
            string sqlText = string.Format("INSERT INTO Category ( CategoryName, Topping,PriceSmall,PriceMedium,PriceLarge) VALUES" + " ('{0}','{1}',{2},{3},{4})",  c.CategoryName, c.Topping ,c.PriceSmall,c.PriceMedium,c.PriceLarge);
            base.SaveChanges(sqlText);
        }
        public void UpdateCategory(Category c)
        {
            string sqlText = "UPDATE Category SET CategoryName = '" + c.CategoryName +
"', Topping = '" + c.Topping +
"', PriceSmall = " + c.PriceSmall +
", PriceMedium = " + c.PriceMedium +
", PriceLarge = " + c.PriceLarge +
" WHERE Id = " + c.Id;
            base.SaveChanges(sqlText);
        }
    }
}
