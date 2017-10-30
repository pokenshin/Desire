using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Desire.WinApp.Data
{
    public class SQLiteController
    {
        SQLiteConnection conn;
        string dbPath = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\Desire.WinApp\";
        string dbName = "desire.db";
        string connString = "Data Source=";

        public SQLiteConnection GetConnection()
        {
            if (!System.IO.File.Exists(dbPath + dbName))
                CriarBanco();

            conn = new SQLiteConnection(connString + dbPath + dbName);
            return conn;
        }

        private void CriarBanco()
        {
            System.IO.Directory.CreateDirectory(dbPath);
            SQLiteConnection.CreateFile(dbPath+dbName);
        }

        private void ImportarDadosWeb()
        {
            throw new NotImplementedException();
        }
    }
}
