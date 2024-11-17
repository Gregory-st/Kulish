using System.Data.SqlClient;
using System.Data;
using System;

namespace Kulish.net.DataBase
{
    public class RepositoryBaskets
    {
        private readonly DataBaseContext context;
        private RepositorySneakers repository;

        public RepositoryBaskets(DataBaseContext context)
        {
            this.context = context;
            repository = new RepositorySneakers(context);
        }

        public DataTable Get()
        {
            DataSet data = new DataSet();
            context.Buskets.Fill(data);
            return data.Tables[0];
        }

        public DataRow GetByUserIdAndSneakersId(int user_id, int sneaker_id)
        {
            DataSet data = new DataSet();
            context.Buskets.Fill(data);
            foreach(DataRow i in data.Tables[0].Rows)
            {
                if (
                   Convert.ToInt32(i["id_user"]) == user_id 
                   && 
                   Convert.ToInt32(i["id_sneaker"]) == sneaker_id)
                {
                    return i;
                }
            }

            throw new Exception("Корзина не найдена");
        }

        public void Add(int id_user, int id_sneaker, int count)
        {
            DataSet data = new DataSet();

            context.Buskets.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = table.NewRow();
            int price = (int)repository.GetAsId(id_sneaker)["price"] * count;

            row["id"] = table.Rows.Count + 1;
            row["id_user"] = id_user;
            row["id_sneaker"] = id_sneaker;
            row["count"] = count;
            row["price"] = price;

            table.Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Buskets);
            context.Buskets.Update(data);
        }

        public void Update(int id, int id_user, int id_sneaker, int count)
        {
            DataSet data = new DataSet();
            context.Buskets.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;
            foreach (DataRow i in table.Rows)
            {
                if ((int)i["id"] == id)
                {
                    row = i;
                    break;
                }
            }

            int price = (int)repository.GetAsId(id_sneaker)["price"] * count;

            if (row == null) throw new System.Exception("Корзина не найдена");

            row["id_user"] = id_user;
            row["id_sneaker"] = id_sneaker;
            row["count"] = count;
            row["price"] = price;

            SqlCommandBuilder builder = new SqlCommandBuilder(context.Buskets);
            context.Buskets.Update(data);
        }

        public void Delete(int id)
        {
            DataSet data = new DataSet();
            context.Buskets.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;

            foreach (DataRow i in table.Rows)
            {
                if ((int)i["id"] == id)
                {
                    row = i;
                    break;
                }
            }

            if (row == null) throw new System.Exception("Корзина не найдена");

            row.Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Buskets);
            context.Buskets.Update(data);
        }
    }
}
