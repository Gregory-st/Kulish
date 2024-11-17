using System.IO;
using System.Text;

namespace Kulish.net.DataBase
{
    public class DbConnectionConfig
    {
        public string DataSourse { get; set; }
        public string Catalog { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        private static readonly string root = "config";
        private static readonly string file = "db.txt";

        public DbConnectionConfig(string dataSourse, string catalog, string login, string password)
        {
            DataSourse = dataSourse;
            Catalog = catalog;
            Login = login;
            Password = password;
        }

        public void Save()
        {
            string path = root;
            if(!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path, file);

            FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
            BufferedStream buffered = new BufferedStream(stream);
            StreamWriter writer = new StreamWriter(buffered);

            writer.WriteLine(DataSourse);
            writer.WriteLine(Catalog);
            writer.WriteLine(Login);
            writer.Write(Password);

            writer.Flush();
            writer.Close();
            stream.Close();
        }

        public void Open()
        {
            string path = Path.Combine(root, file);
            string[] lines = File.ReadAllLines(path);

            DataSourse = lines[0];
            Catalog = lines[1];
            Login = lines[2];
            Password = lines[3];
        }

        public static DbConnectionConfig OpenAsFile()
        {
            string path = Path.Combine(root, file);
            string[] lines = File.ReadAllLines(path);
            return new DbConnectionConfig(lines[0], lines[1], lines[2], lines[3]);
        }

        public override string? ToString() =>
            new StringBuilder()
            .AppendFormat("Data Source={0};", DataSourse)
            .AppendFormat("Initial Catalog={0};", Catalog)
            .AppendFormat("User ID={0};", Login)
            .AppendFormat("Password={0}", Password)
            .ToString();
    }
}
