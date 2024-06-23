using System;
using System.IO;

namespace CargoTransportationView
{
    public static class ApplicationData
    {
        private static string configName;
        public static string Database { get; set; }
        public static string Server { get; set; }
        public static int Port { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }

        /// <summary>
        /// Загрузка значений настроек для подключения к серверу, ранее сохраненных на диске
        /// </summary>
        /// <param name="name">Наименование конфигурации</param>
        public static void LoadConfiguration(string name)
        {
            configName = $"{name}.ini";
            var mif = new MemIniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configName));
            var section = "DatabaseSettings";
            Database = mif.ReadString(section, "Database", "CargoTransportation");
            Server = mif.ReadString(section, "Host", "localhost");
            Port = mif.ReadInteger(section, "Port", 3306);
            User = mif.ReadString(section, "User", "root");
            Password = mif.ReadString(section, "Password", "");
        }

        /// <summary>
        /// Загрузка тестовых значений настроек для подключения к серверу, не сохраняется на диске
        /// </summary>
        /// <param name="database"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static void TestConfiguration(string database, string server, int port, string user, string password)
        {
            Database = database;
            Server = server;
            Port = port;
            User = user;
            Password = password;
        }

        /// <summary>
        /// Сохранение конфигурации связи на диск
        /// </summary>
        /// <param name="database"></param>
        /// <param name="server"></param>
        /// <param name="port"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        public static void SaveConfiguration(string database, string server, int port, string user, string password)
        {
            Database = database;
            Server = server;
            Port = port;
            User = user;
            Password = password;
            var mif = new MemIniFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configName));
            var section = "DatabaseSettings";
            mif.WriteString(section, "Database", database);
            mif.WriteString(section, "Host", server);
            mif.WriteInteger(section, "Port", port);
            mif.WriteString(section, "User", user);
            mif.WriteString(section, "Password", password);
            mif.UpdateFile();
        }

        /// <summary>
        /// Проверка, что сервер связывается с приложением
        /// </summary>
        /// <returns></returns>
        public static bool ServerConnected()
        {
            using (var server = new Server())
            {
                return server.Connected;
            }
        }
    }
}
