using System;
using System.Data;
using System.Data.SqlClient;

namespace Kulish.net.DataBase
{
    public class RepositoryUsers
    {
        private readonly DataBaseContext context;

        public RepositoryUsers(DataBaseContext context)
        {
            this.context = context;
        }

        public DataTable Get()
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);
            return data.Tables[0];
        }

        public DataRow GetByLoginAndPassword(string login, string pass)
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);
            DataRow row;
            foreach(DataRow i in data.Tables[0].Rows)
            {
                if (i["Login"].ToString() == login && i["Password"].ToString() == pass)
                    return i;
            }

            throw new System.Exception("Не верный логин или пароль");
        }

        public DataRow GetById(int id)
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);
            DataRow row;
            foreach (DataRow i in data.Tables[0].Rows)
            {
                if (Convert.ToInt32(i["userID"]) == id)
                    return i;
            }

            throw new System.Exception("Ошибка базы данных неверный id");
        }

        public void Add(string fullName, string phone, string login, string pass)
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);
            
            DataTable table = data.Tables[0];
            DataRow row = table.NewRow();

            row["fullName"] = fullName;
            row["phoneNumber"] = phone;
            row["Login"] = login;
            row["Password"] = pass;

            table.Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Users);
            context.Users.Update(data);
        }

        public void Update(int id, string fullName, string phone, string login, string pass)
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;
            foreach(DataRow i in table.Rows)
            {
                if ((int)i["userId"] == id)
                {
                    row = i;
                    break;
                }
            }

            if (row == null) throw new System.Exception("Пользователь не найден");

            row["fullName"] = fullName;
            row["phoneNumber"] = phone;
            row["Login"] = login;
            row["Password"] = pass;

            SqlCommandBuilder builder = new SqlCommandBuilder(context.Users);
            context.Users.Update(data);
        }

        public void Delete(int id)
        {
            DataSet data = new DataSet();
            context.Users.Fill(data);

            DataTable table = data.Tables[0];
            DataRow row = null;

            foreach (DataRow i in table.Rows)
            {
                if ((int)i["userId"] == id)
                {
                    row = i;
                    break;
                }
            }

            if (row == null) throw new System.Exception("Пользователь не найден");

            row.Delete();
            SqlCommandBuilder builder = new SqlCommandBuilder(context.Users);
            context.Users.Update(data);
        }
    }
}
