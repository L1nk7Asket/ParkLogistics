using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Марка транспортного средства
    /// </summary>
    public class TransportVehicleBrand
    {
        // Идентификатор
        public int Id { get; set; }
        // Наименование марки  
        public string Name { get; set; }         
        // Тип транспортного средства  
        public int VehicleType { get; set; }         
        // Код марки  
        public string Code { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `брендытс` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ТипТС` int NOT NULL,
  `Имя` varchar(250) NOT NULL,
  `Код` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `BrandName_UNIQUE` (`Имя`),
  UNIQUE KEY `BrandCode_UNIQUE` (`Код`)  
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
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
                string query = "DROP TABLE `брендытс`";
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
            string query = "SELECT * FROM `брендытс` ORDER BY `Имя`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "брендытс");
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
        public static TransportVehicleBrand SelectItem(MySqlConnection connection, int id)
        {
            var item = new TransportVehicleBrand();
            string query = "SELECT * FROM `брендытс` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "брендытс");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Name = (string)data.Tables[0].Rows[0]["Имя"];
                        item.VehicleType = (int)data.Tables[0].Rows[0]["ТипТС"];
                        item.Code = (string)data.Tables[0].Rows[0]["Код"];
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
        /// <returns>Возвращает идентификатор записи объекта "Марка транспортного средства"</returns>
        public static int AddItem(MySqlConnection connection, TransportVehicleBrand item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `брендытс`" +
                        " (`Имя`, `ТипТС`, `Код`)" +
                        " VALUES (@Имя, @ТипТС, @Код)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Имя", item.Name);
                        command.Parameters.AddWithValue("@ТипТС", item.VehicleType);
                        command.Parameters.AddWithValue("@Код", item.Code);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `брендытс`";
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
        /// <param name="id">Идентификатор записи объекта "Марка транспортного средства"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, TransportVehicleBrand item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `брендытс` SET `Имя`=@Имя,`ТипТС`=@ТипТС,`Код`=@Код WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Имя", item.Name);
                    command.Parameters.AddWithValue("@ТипТС", item.VehicleType);
                    command.Parameters.AddWithValue("@Код", item.Code);
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
        /// <param name="id">Идентификатор записи объекта "Марка транспортного средства"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `брендытс` WHERE `Id`=@Id";
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
