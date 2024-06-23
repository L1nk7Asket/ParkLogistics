using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Маршрут движения
    /// </summary>
    public class Route
    {
        // Идентификатор
        public int Id { get; set; }
        // Код маршрута  
        public string Code { get; set; }         
        // Наименование маршрута  
        public string Name { get; set; }         
        // Протяжённость, км  
        public float Length { get; set; }         
        // Время в пути, часы  
        public float TravelTime { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса               
                string query = @"CREATE TABLE `маршруты` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Код` varchar(50) NOT NULL,
  `Имя` varchar(250) NOT NULL,
  `Длина` float NOT NULL,
  `Время_впути` float NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Code_UNIQUE` (`Код`),
  UNIQUE KEY `Name_UNIQUE` (`Имя`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
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
                string query = "DROP TABLE `маршруты`";
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
            string query = "SELECT * FROM `маршруты` ORDER BY `Код`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "маршруты");
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
        public static Route SelectItem(MySqlConnection connection, int id)
        {
            var item = new Route();
            string query = "SELECT * FROM `маршруты` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "маршруты");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Code = (string)data.Tables[0].Rows[0]["Код"];
                        item.Name = (string)data.Tables[0].Rows[0]["Имя"];
                        item.Length = (float)data.Tables[0].Rows[0]["Длина"];
                        item.TravelTime = (float)data.Tables[0].Rows[0]["Время_впути"];
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
        /// <returns>Возвращает идентификатор записи объекта "Маршрут движения"</returns>
        public static int AddItem(MySqlConnection connection, Route item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `маршруты`" +
                        " (`Код`, `Имя`, `Длина`, `Время_впути`)" +
                        " VALUES (@Код, @Имя, @Длина, @Время_впути)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Код", item.Code);
                        command.Parameters.AddWithValue("@Имя", item.Name);
                        command.Parameters.AddWithValue("@Длина", item.Length);
                        command.Parameters.AddWithValue("@Время_впути", item.TravelTime);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `маршруты`";
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
        /// <param name="id">Идентификатор записи объекта "Маршрут движения"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Route item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `маршруты` SET `Код`=@Код,`Имя`=@Имя,`Длина`=@Длина,`Время_впути`=@Время_впути WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Код", item.Code);
                    command.Parameters.AddWithValue("@Имя", item.Name);
                    command.Parameters.AddWithValue("@Длина", item.Length);
                    command.Parameters.AddWithValue("@Время_впути", item.TravelTime);
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
        /// <param name="id">Идентификатор записи объекта "Маршрут движения"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `маршруты` WHERE `Id`=@Id";
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
