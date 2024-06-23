using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        // Идентификатор
        public int Id { get; set; }
        // Маршрут  
        public int Route { get; set; }         
        // Подразделение  
        public int Division { get; set; }         
        // Заказчик  
        public int Сustomer { get; set; }         
        // Наименование услуги  
        public int Service { get; set; }         
        // Наименование тарифа  
        public int Rate { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `заказы` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Маршрут` int NOT NULL,
  `Подразделение` int NOT NULL,
  `Покупатель` int NOT NULL,
  `Услуги` int NOT NULL,
  `Ставка` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";
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
                string query = "DROP TABLE `заказы`";
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
            string query = "SELECT * FROM `заказы`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "заказы");
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
        public static Order SelectItem(MySqlConnection connection, int id)
        {
            var item = new Order();
            string query = "SELECT * FROM `заказы` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "заказы");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.Route = (int)data.Tables[0].Rows[0]["Маршрут"];
                        item.Division = (int)data.Tables[0].Rows[0]["Подразделение"];
                        item.Сustomer = (int)data.Tables[0].Rows[0]["Покупатель"];
                        item.Service = (int)data.Tables[0].Rows[0]["Услуги"];
                        item.Rate = (int)data.Tables[0].Rows[0]["Ставка"];
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
        /// <returns>Возвращает идентификатор записи объекта "Заказ"</returns>
        public static int AddItem(MySqlConnection connection, Order item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `заказы`" +
                        " (`Маршрут`, `Подразделение`, `Покупатель`, `Услуги`, `Ставка`)" +
                        " VALUES (@Маршрут, @Подразделение, @Покупатель, @Услуги, @Ставка)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Маршрут", item.Route);
                        command.Parameters.AddWithValue("@Подразделение", item.Division);
                        command.Parameters.AddWithValue("@Покупатель", item.Сustomer);
                        command.Parameters.AddWithValue("@Услуги", item.Service);
                        command.Parameters.AddWithValue("@Ставка", item.Rate);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `заказы`";
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
        /// <param name="id">Идентификатор записи объекта "Заказ"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Order item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `заказы` SET `Маршрут`=@Маршрут,`Подразделение`=@Подразделение,`Покупатель`=@Покупатель,`Услуги`=@Услуги,`Ставка`=@Ставка WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Маршрут", item.Route);
                    command.Parameters.AddWithValue("@Подразделение", item.Division);
                    command.Parameters.AddWithValue("@Покупатель", item.Сustomer);
                    command.Parameters.AddWithValue("@Услуги", item.Service);
                    command.Parameters.AddWithValue("@Ставка", item.Rate);
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
        /// <param name="id">Идентификатор записи объекта "Заказ"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `заказы` WHERE `Id`=@Id";
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
