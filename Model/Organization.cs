using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization
    {
        // Идентификатор
        public int Id { get; set; }
        // Наименование организации  
        public string Name { get; set; }         
        // Ф.И.О. руководителя  
        public string DirectorName { get; set; }         
        // ИНН  
        public string IndividualTaxNumber { get; set; }         
        // Контактные данные  
        public string ContactDetails { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `организации` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Имя` varchar(250) NOT NULL,
  `Директор` varchar(250) NOT NULL,
  `Индивид_налогномер` varchar(10) NOT NULL,
  `Контакт_детали` varchar(250) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Name_UNIQUE` (`Имя`),
  UNIQUE KEY `IndividualTaxNumber_UNIQUE` (`Индивид_налогномер`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
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
                string query = "DROP TABLE `организации`";
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
            string query = "SELECT * FROM `организации`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "организации");
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
        public static Organization SelectItem(MySqlConnection connection, int id)
        {
            var item = new Organization();
            string query = "SELECT * FROM `организации` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "организации");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Name = (string)data.Tables[0].Rows[0]["Имя"];
                        item.DirectorName = (string)data.Tables[0].Rows[0]["Директор"];
                        item.IndividualTaxNumber = (string)data.Tables[0].Rows[0]["Индивид_налогномер"];
                        item.ContactDetails = (string)data.Tables[0].Rows[0]["Контакт_детали"];
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
        /// <returns>Возвращает идентификатор записи объекта "Организация"</returns>
        public static int AddItem(MySqlConnection connection, Organization item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `организации`" +
                        " (`Имя`, `Директор`, `Индивид_налогномер`, `Контакт_детали`)" +
                        " VALUES (@Имя, @Директор, @Индивид_налогномер, @Контакт_детали)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Имя", item.Name);
                        command.Parameters.AddWithValue("@Директор", item.DirectorName);
                        command.Parameters.AddWithValue("@Индивид_налогномер", item.IndividualTaxNumber);
                        command.Parameters.AddWithValue("@Контакт_детали", item.ContactDetails);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `организации`";
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
        /// <param name="id">Идентификатор записи объекта "Организация"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Organization item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `организации` SET `Имя`=@Имя,`Директор`=@Директор,`Индивид_налогномер`=@Индивид_налогномер,`Контакт_детали`=@Контакт_детали WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Имя", item.Name);
                    command.Parameters.AddWithValue("@Директор", item.DirectorName);
                    command.Parameters.AddWithValue("@Индивид_налогномер", item.IndividualTaxNumber);
                    command.Parameters.AddWithValue("@Контакт_детали", item.ContactDetails);
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
        /// <param name="id">Идентификатор записи объекта "Организация"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `организации` WHERE `Id`=@Id";
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
