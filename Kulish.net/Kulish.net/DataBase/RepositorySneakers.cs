using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Xml.Linq;

namespace Kulish.net.DataBase
{
    public class RepositorySneakers
    {
        private readonly DataBaseContext context;

        public RepositorySneakers(DataBaseContext context)
        {
            this.context = context;
        }

        public DataTable Get()
        {
            DataSet data = new DataSet();
            context.Sneakers.Fill(data);
            return data.Tables[0];
        }

        public DataRow GetAsId(int id)
        {
            DataSet data = new DataSet();
            context.Sneakers.Fill(data);
            
            DataTable table = data.Tables[0];
            foreach(DataRow i in table.Rows)
            {
                if ((int)i["sneakersID"] == id)
                    return i;
            }

            throw new System.Exception("Товар не найден");
        }

        public DataTable GetAsOrderBy(string orderBy)
        {
            context.Sneakers.SelectCommand.CommandText = "SELECT * FROM dbo.[Sneakers] ORDER BY " + orderBy + ";";
            DataTable table = Get();
            context.Sneakers.SelectCommand.CommandText = "SELECT * FROM dbo.[Sneakers];";
            return table;
        }

        public DataTable GetAsSearch(string line)
        {
            DataTable table = Get();

            for(int i = table.Rows.Count - 1; i >= 0; i--)
            {
                DataRow row = table.Rows[i];
                bool exist = false;
                for(int j = 0; j < table.Columns.Count; j++)
                {
                    if (row["name"].ToString()?.IndexOf(line) != -1)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                    table.Rows.Remove(row);
            }

            return table;
        }

        public void Add(string name, int size, int price, string desc)
        {
            DataSet data = new DataSet();
            context.Sneakers.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = table.NewRow();

            row["name"] = name;
            row["size"] = size;
            row["price"] = price;
            row["descryption"] = desc;

            table.Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Sneakers);
            context.Sneakers.Update(data);
        }

        public void Update(int id, string name, int size, int price, string desc)
        {
            DataSet data = new DataSet();
            context.Sneakers.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;
            foreach (DataRow i in table.Rows)
            {
                if ((int)i["sneakersID"] == id)
                {
                    row = i;
                    break;
                }
            }

            if (row == null) throw new System.Exception("Ошибка базы данных неверный id");

            row["name"] = name;
            row["size"] = size;
            row["price"] = price;
            row["descryption"] = desc;

            SqlCommandBuilder builder = new SqlCommandBuilder(context.Sneakers);
            context.Sneakers.Update(data);
        }

        public void Delete(int id)
        {
            DataSet data = new DataSet();
            context.Sneakers.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;

            foreach (DataRow i in table.Rows)
            {
                if ((int)i["sneakersID"] == id)
                {
                    row = i;
                    break;
                }
            }

            if (row == null) throw new System.Exception("Ошибка базы данных неверный id");

            row.Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Sneakers);
            context.Sneakers.Update(data);
        }
    }
}
