using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Оплаты
    /// </summary>
    public class Payment
    {
        // Идентификатор
        public int Id { get; set; }
        // Путевой лист  
        public int Waybill { get; set; }         
        // Вид оплаты  
        public int PaymentType { get; set; }
        // Сумма к оплате  
        public double Summa { get; set; }

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса              
                string query = @"CREATE TABLE `платежи` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Накладная` int NOT NULL,
  `Тип_платежа` int NOT NULL,
  `Сумма` double NOT NULL,
  PRIMARY KEY (`Id`) 
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    // выполняем запрос к БД
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Метод для удаления таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void DropTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса
                string query = "DROP TABLE `платежи`";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    // выполняем запрос к БД
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Метод для получения всех записей таблицы из БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static DataSet SelectList(MySqlConnection connection)
        {
            var data = new DataSet();
            string query = "SELECT * FROM `платежи`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "платежи");
                    }
                    catch
                    {
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// Метод для получения одной записи таблицы из БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Объект со свойствами из записи</returns>
        public static Payment SelectItem(MySqlConnection connection, int id)
        {
            var item = new Payment();
            string query = "SELECT * FROM `платежи` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "платежи");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Waybill = (int)data.Tables[0].Rows[0]["Накладная"];
                        item.PaymentType = (int)data.Tables[0].Rows[0]["Тип_платежа"];
                        item.Summa = (double)data.Tables[0].Rows[0]["Сумма"];
                    }
                    catch
                    {
                        throw;
                    }
                }
            }
            return item;
        }

        /// <summary>
        /// Метод для добавления записи в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        /// <param name="item">Ссылка на объект с данными для добавления</param>
        /// <returns>Возвращает идентификатор записи объекта "Оплаты"</returns>
        public static int AddItem(MySqlConnection connection, Payment item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `платежи`" +
                        " (`Накладная`, `Тип_платежа`,`Сумма`)" +
                        " VALUES (@Накладная, @Тип_платежа, @Сумма)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Накладная", item.Waybill);
                        command.Parameters.AddWithValue("@Тип_платежа", item.PaymentType);
                        command.Parameters.AddWithValue("@Сумма", item.Summa);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `платежи`";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        // выполняем запрос к БД
                        id = (int)command.ExecuteScalar();
                    }
                    transaction.Commit();
                    item.Id = id;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return id;
        }

        /// <summary>
        /// Метод для изменения записи в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        /// <param name="id">Идентификатор записи объекта "Оплаты"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Payment item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `платежи` SET `Накладная`=@Накладная,`Тип_платежа`=@Тип_платежа,`Сумма`=@Сумма WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Накладная", item.Waybill);
                    command.Parameters.AddWithValue("@Тип_платежа", item.PaymentType);
                    command.Parameters.AddWithValue("@Сумма", item.Summa);
                    command.Parameters.AddWithValue("@Id", id);
                    // выполняем запрос к БД
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Метод для удаления записи в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        /// <param name="id">Идентификатор записи объекта "Оплаты"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `платежи` WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    // выполняем запрос к БД
                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
