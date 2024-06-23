using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Транспортное средство
    /// </summary>
    public class TransportVehicle
    {
        // Идентификатор
        public int Id { get; set; }
        // Гос.номер  
        public string StateNumber { get; set; }         
        // Марка ТС  
        public int BrandCode { get; set; }         
        // Подразделение  
        public int DivisionCode { get; set; }         
        // ГСМ для основного оборудования  
        public int MainEquipmentFuel { get; set; }         
        // ГСМ для дополнительного оборудования  
        public int AdditionalEquipmentFuel { get; set; }         
        // Ф.И.О. водителя  
        public int DriverName { get; set; }         
        // Норма расхода ГСМ (основное оборудование)  
        public int MainConsumptionRate { get; set; }         
        // Норма расхода ГСМ (дополнительное оборудование)  
        public int AdditionalConsumptionRate { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в БД
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `тс` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Гос_номер` varchar(6) NOT NULL,
  `Бренд_код` int NOT NULL,
  `Код_подразделения` int NOT NULL,
  `Основ_топливо` int NOT NULL,
  `Доп_топливо` int NOT NULL,
  `Имя_подразделения` int NOT NULL,
  `Основ_потребление` int NOT NULL,
  `Коэф_доппотребления` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `StateNumber_UNIQUE` (`Гос_номер`)  
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
                string query = "DROP TABLE `тс`";
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
            string query = "SELECT * FROM `тс`";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "тс");
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
        public static TransportVehicle SelectItem(MySqlConnection connection, int id)
        {
            var item = new TransportVehicle();
            string query = "SELECT * FROM `тс` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "тс");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.StateNumber = (string)data.Tables[0].Rows[0]["Гос_номер"];
                        item.BrandCode = (int)data.Tables[0].Rows[0]["Бренд_код"];
                        item.DivisionCode = (int)data.Tables[0].Rows[0]["Код_подразделения"];
                        item.MainEquipmentFuel = (int)data.Tables[0].Rows[0]["Основ_топливо"];
                        item.AdditionalEquipmentFuel = (int)data.Tables[0].Rows[0]["Доп_топливо"];
                        item.DriverName = (int)data.Tables[0].Rows[0]["Имя_подразделения"];
                        item.MainConsumptionRate = (int)data.Tables[0].Rows[0]["Основ_потребление"];
                        item.AdditionalConsumptionRate = (int)data.Tables[0].Rows[0]["Коэф_доппотребления"];
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
        /// <returns>Возвращает идентификатор записи объекта "Транспортное средство"</returns>
        public static int AddItem(MySqlConnection connection, TransportVehicle item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `тс`" +
                        " (`Гос_номер`, `Бренд_код`, `Код_подразделения`, `Основ_топливо`, `Доп_топливо`, `Имя_подразделения`, `Основ_потребление`, `Коэф_доппотребления`)" +
                        " VALUES (@Гос_номер, @Бренд_код, @Код_подразделения, @Основ_топливо, @Доп_топливо, @Имя_подразделения, @Основ_потребление, @Коэф_доппотребления)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Гос_номер", item.StateNumber);
                        command.Parameters.AddWithValue("@Бренд_код", item.BrandCode);
                        command.Parameters.AddWithValue("@Код_подразделения", item.DivisionCode);
                        command.Parameters.AddWithValue("@Основ_топливо", item.MainEquipmentFuel);
                        command.Parameters.AddWithValue("@Доп_топливо", item.AdditionalEquipmentFuel);
                        command.Parameters.AddWithValue("@Имя_подразделения", item.DriverName);
                        command.Parameters.AddWithValue("@Основ_потребление", item.MainConsumptionRate);
                        command.Parameters.AddWithValue("@Коэф_доппотребления", item.AdditionalConsumptionRate);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `тс`";
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
        /// <param name="id">Идентификатор записи объекта "Транспортное средство"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, TransportVehicle item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `тс` SET `Гос_номер`=@Гос_номер,`Бренд_код`=@Бренд_код,`Код_подразделения`=@Код_подразделения,`Основ_топливо`=@Основ_топливо,`Доп_топливо`=@Доп_топливо,`Имя_подразделения`=@Имя_подразделения,`Основ_потребление`=@Основ_потребление,`Коэф_доппотребления`=@Коэф_доппотребления WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Гос_номер", item.StateNumber);
                    command.Parameters.AddWithValue("@Бренд_код", item.BrandCode);
                    command.Parameters.AddWithValue("@Код_подразделения", item.DivisionCode);
                    command.Parameters.AddWithValue("@Основ_топливо", item.MainEquipmentFuel);
                    command.Parameters.AddWithValue("@Доп_топливо", item.AdditionalEquipmentFuel);
                    command.Parameters.AddWithValue("@Имя_подразделения", item.DriverName);
                    command.Parameters.AddWithValue("@Основ_потребление", item.MainConsumptionRate);
                    command.Parameters.AddWithValue("@Коэф_доппотребления", item.AdditionalConsumptionRate);
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
        /// <param name="id">Идентификатор записи объекта "Транспортное средство"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `тс` WHERE `Id`=@Id";
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
