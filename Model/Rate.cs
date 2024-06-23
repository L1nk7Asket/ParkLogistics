using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Тариф
    /// </summary>
    public class Rate
    {
        // Идентификатор
        public int Id { get; set; }
        // Код тарифа  
        public string Code { get; set; }         
        // Наименование тарифа  
        public string Name { get; set; }         
        // Величина тарифа  
        public float ValuePerUnit { get; set; }         
        // Ед.изм.  
        public string RateUnit { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса               
                string query = @"CREATE TABLE `ставки` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Код` varchar(50) NOT NULL,
  `Имя` varchar(250) NOT NULL,
  `Ед_ставки` float NOT NULL,
  `Объем` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Code_UNIQUE` (`Код`),
  UNIQUE KEY `Name_UNIQUE` (`Имя`)
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
                string query = "DROP TABLE `ставки`";
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
            string query = "SELECT * FROM `ставки`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "ставки");
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
        public static Rate SelectItem(MySqlConnection connection, int id)
        {
            var item = new Rate();
            string query = "SELECT * FROM `ставки` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "ставки");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Code = (string)data.Tables[0].Rows[0]["Код"];
                        item.Name = (string)data.Tables[0].Rows[0]["Имя"];
                        item.ValuePerUnit = (float)data.Tables[0].Rows[0]["Ед_ставки"];
                        item.RateUnit = (string)data.Tables[0].Rows[0]["Объем"];
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
        /// <returns>Возвращает идентификатор записи объекта "Тариф"</returns>
        public static int AddItem(MySqlConnection connection, Rate item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `ставки`" +
                        " (`Код`, `Имя`, `Ед_ставки`, `Объем`)" +
                        " VALUES (@Код, @Имя, @Ед_ставки, @Объем)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Код", item.Code);
                        command.Parameters.AddWithValue("@Имя", item.Name);
                        command.Parameters.AddWithValue("@Ед_ставки", item.ValuePerUnit);
                        command.Parameters.AddWithValue("@Объем", item.RateUnit);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `ставки`";
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
        /// <param name="id">Идентификатор записи объекта "Тариф"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Rate item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `ставки` SET `Код`=@Код,`Имя`=@Имя,`Ед_ставки`=@Ед_ставки,`Объем`=@Объем WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Код", item.Code);
                    command.Parameters.AddWithValue("@Имя", item.Name);
                    command.Parameters.AddWithValue("@Ед_ставки", item.ValuePerUnit);
                    command.Parameters.AddWithValue("@Объем", item.RateUnit);
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
        /// <param name="id">Идентификатор записи объекта "Тариф"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `ставки` WHERE `Id`=@Id";
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
