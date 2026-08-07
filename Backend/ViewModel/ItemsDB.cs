using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ItemsDB:BaseDB
    {
        public override BaseEntity CreateModel(BaseEntity be)
        {
            Items i = be as Items;
            i.Id = Convert.ToInt32(reader["Id"]);
            i.ItemName = reader["ItemName"].ToString();
            i.CategoryId = new CategoryDB().SelectByIDCategory(Convert.ToInt32(reader["CategoryId"]));
           
            i.Pic = reader["Pic"].ToString();
            i.FullName = GetCurrectPath() + @"\Images\" + i.Pic;
            i.Ingredients = reader["Ingredients"].ToString();

            return i;
        }

        public ItemsList SelectAllItems()
        {
            command.CommandText = "SELECT * FROM Items";
            ItemsList il = new ItemsList(base.Select());
            return il;
        }
        public Items SelectByIDItems(int id)
        {
            command.CommandText = "SELECT * FROM Items WHERE Items.ID = " + id + "";
            ItemsList il = new ItemsList(base.Select());
            if (il.Count > 0)
                return il[0];
            return null;
        }

        public override BaseEntity NewEntity()
        {
            return new Items() as BaseEntity;
        }

        public void InsertItems(Items i)

        {
            string sqlText = string.Format("INSERT INTO Items (ItemName, CategoryId,  Pic, Ingredients) VALUES ('{0}',{1},'{2}','{3}')",  i.ItemName, i.CategoryId.Id ,  i.Pic, i.Ingredients);
            base.SaveChanges(sqlText);
            
        }
        public void UpdateItems(Items i)
        {
            string sqlText = "UPDATE Items SET  ItemName='" + i.ItemName + "' ,CategoryId= " + i.CategoryId.Id + " ,  Pic='" + i.Pic + "', Ingredients='" + i.Ingredients + "'  WHERE Id=" + i.Id;
            base.SaveChanges(sqlText);
        }
    }
}
