using System;
using MySql.Data.MySqlClient;

namespace CargoTransportationView
{
    public delegate void GetReaded(object[] values);

    public sealed class Server : IDisposable
    {
        // Строка подключения к базе данных.
        private readonly string connectionString = string.Empty;
        // Статическая строка для хранения последней ошибки.
        private static string lasterrorString = string.Empty;
        // Объект подключения к базе данных.
        public MySqlConnection Connection;
        // Флаг, указывающий на состояние подключения к серверу.
        private readonly bool serverConnected = false;
        // Свойство для доступа к последней ошибке.
        public static string LastError { get { return lasterrorString; } }

        public Server()
        {
            // Создание строки подключения
            connectionString = $"server={ApplicationData.Server};user={ApplicationData.User};port={ApplicationData.Port};password={ApplicationData.Password};";
            if (!string.IsNullOrWhiteSpace(ApplicationData.Database)) connectionString += $"database={ApplicationData.Database};";
            Connection = new MySqlConnection(connectionString);
            // Тест соедининения
            serverConnected = TryToConnect();
        }
        // Реализация метода Dispose интерфейса IDisposable.
        public void Dispose()
        {
            // Освобождение ресурсов подключения.
            Connection.Dispose();
        }
        // Метод для попытки подключения к серверу.
        private bool TryToConnect()
        {
            try
            {
                // Попытка открыть подключение
                Connection.Open();
                // Если подключение открыто успешно, очистка строки ошибки и возврат true.
                lasterrorString = string.Empty;
                return true;
            }
            catch (Exception e)
            {
                // Если при попытке подключения возникла ошибка, сохранение сообщения об ошибке и возврат false.
                lasterrorString = e.Message;
                return false;
            }
        }
        // Свойство для проверки состояния подключения.
        public bool Connected
        {
            get
            {
                return serverConnected;
            }
        }
    }
}
