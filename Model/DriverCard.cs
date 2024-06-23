using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Карточка водителя
    /// </summary>
    public class DriverCard
    {
        // Идентификатор
        public int Id { get; set; }
        // Табельный номер  
        public string ServiceNumber { get; set; }         
        // Ф.И.О.  
        public string FullName { get; set; }         
        // Класс  
        public string Grade { get; set; }         
        // Категория водительских прав  
        public string Category { get; set; }         
        // Номер удостоверения  
        public string IdentityCardNumber { get; set; }         
        // Часовая тарифная ставка  
        public double HourlyTariffRate { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `прававодителя` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Служ_номер` varchar(5) NOT NULL,
  `ФИО` varchar(250) NOT NULL,
  `Класс` varchar(50) NOT NULL,
  `Категория` varchar(3) NOT NULL,
  `ID_карты` varchar(10) NOT NULL,
  `Тариф_час` double NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DriverFullName_UNIQUE` (`ФИО`),
  UNIQUE KEY `ServiceNumber_UNIQUE` (`Служ_номер`),
  UNIQUE KEY `IdentityCardNumber_UNIQUE` (`ID_карты`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
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
                string query = "DROP TABLE `прававодителя`";
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
            string query = "SELECT * FROM `прававодителя`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "прававодителя");
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
        public static DriverCard SelectItem(MySqlConnection connection, int id)
        {
            var item = new DriverCard();
            string query = "SELECT * FROM `прававодителя` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "прававодителя");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.ServiceNumber = (string)data.Tables[0].Rows[0]["Служ_номер"];
                        item.FullName = (string)data.Tables[0].Rows[0]["ФИО"];
                        item.Grade = (string)data.Tables[0].Rows[0]["Класс"];
                        item.Category = (string)data.Tables[0].Rows[0]["Категория"];
                        item.IdentityCardNumber = (string)data.Tables[0].Rows[0]["ID_карты"];
                        item.HourlyTariffRate = (double)data.Tables[0].Rows[0]["Тариф_час"];
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
        /// <returns>Возвращает идентификатор записи объекта "Карточка водителя"</returns>
        public static int AddItem(MySqlConnection connection, DriverCard item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `прававодителя`" +
                        " (`Служ_номер`, `ФИО`, `Класс`, `Категория`, `ID_карты`, `Тариф_час`)" +
                        " VALUES (@Служ_номер, @ФИО, @Класс, @Категория, @ID_карты, @Тариф_час)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Служ_номер", item.ServiceNumber);
                        command.Parameters.AddWithValue("@ФИО", item.FullName);
                        command.Parameters.AddWithValue("@Класс", item.Grade);
                        command.Parameters.AddWithValue("@Категория", item.Category);
                        command.Parameters.AddWithValue("@ID_карты", item.IdentityCardNumber);
                        command.Parameters.AddWithValue("@Тариф_час", item.HourlyTariffRate);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `прававодителя`";
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
        /// <param name="id">Идентификатор записи объекта "Карточка водителя"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, DriverCard item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `прававодителя` SET `Служ_номер`=@Служ_номер,`ФИО`=@ФИО,`Класс`=@Класс,`Категория`=@Категория,`ID_карты`=@ID_карты,`HourlyTariffRate`=@HourlyTariffRate WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Служ_номер", item.ServiceNumber);
                    command.Parameters.AddWithValue("@ФИО", item.FullName);
                    command.Parameters.AddWithValue("@Класс", item.Grade);
                    command.Parameters.AddWithValue("@Категория", item.Category);
                    command.Parameters.AddWithValue("@ID_карты", item.IdentityCardNumber);
                    command.Parameters.AddWithValue("@Тариф_час", item.HourlyTariffRate);
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
        /// <param name="id">Идентификатор записи объекта "Карточка водителя"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `прававодителя` WHERE `Id`=@Id";
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
