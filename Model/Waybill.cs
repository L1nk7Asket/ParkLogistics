using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CargoTransportationModel
{
    /// <summary>
    /// Путевой лист
    /// </summary>
    public class Waybill
    {
        // Идентификатор
        public int Id { get; set; }
        // Дата выдачи  
        public DateTime IssueDate { get; set; }         
        // Дата обработки  
        public DateTime ProcessingDate { get; set; }         
        // Гос.номер  
        public int StateNumber { get; set; }         
        // Показания спидометра при выезде  
        public int DepartureSpeedometerReadings { get; set; }         
        // Показания спидометра при возвращении  
        public int ReturningSpeedometerReadings { get; set; }         
        // Начальный остаток (л)  
        public int InitialFuelBalance { get; set; }         
        // Выдано (л)  
        public int FuelIssued { get; set; }         
        // Конечный остаток (л)  
        public int FinalFuelRemainder { get; set; }         
        // Сдано (л)  
        public int FuelPassed { get; set; }         
        // Заказ  
        public int Order { get; set; }         
        // Дата и время выезда  
        public DateTime DepartureDateTime { get; set; }         
        // Дата и время возвращения  
        public DateTime ReturnDateTime { get; set; }         
        // Время ремонта (ч)  
        public float RepairTime { get; set; }         
        // Время движения (ч)  
        public float DrivingTime { get; set; }         
        // Вечернее время (ч)  
        public float EveningTime { get; set; }         
        // Ночное время (ч)  
        public float NightTime { get; set; }         

        /// <summary>
        /// Метод для создания таблицы в базе данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к БД</param>
        public static void CreateTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса                
                string query = @"CREATE TABLE `накладные` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Дата_выпуска` datetime NOT NULL,
  `Дата_обработки` datetime NOT NULL,
  `Гос_номер` int NOT NULL,
  `Спидометр_отправка` int NOT NULL,
  `Спидометр_конец` int NOT NULL,
  `Топливо_начало` int NOT NULL,
  `Топливо_потрачено` int NOT NULL,
  `Топливо_конец` int NOT NULL,
  `Топливо_пропущенно` int NOT NULL,
  `Заказ` int NOT NULL,
  `Дата_отправки` datetime NOT NULL,
  `Дата_возврат` datetime NOT NULL,
  `Время_ремонт` float NOT NULL,
  `Время_вождения` float NOT NULL,
  `ВечернееВремя` float NOT NULL,
  `НочноеВРемя` float NOT NULL,
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
        /// Метод для удаления таблицы в базе данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к базе данных</param>
        public static void DropTable(MySqlConnection connection)
        {
            try
            {
                // текст запроса
                string query = "DROP TABLE `накладные`";
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
        /// Метод для получения всех записей таблицы из базы данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к базе данных</param>
        public static DataSet SelectList(MySqlConnection connection)
        {
            var data = new DataSet();
            string query = "SELECT * FROM `накладные`";
            // создаем объект MySqlCommand для выполнения запроса к базе данных
            using (var command = new MySqlCommand(query, connection))
            {
                using (var da = new MySqlDataAdapter(command))
                {
                    data = new DataSet();
                    try
                    {
                        da.Fill(data, "накладные");
                    }
                    catch
                    {
                    }
                }
            }
            return data;
        }

        /// <summary>
        /// Метод для получения одной записи таблицы из базы данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к базе данных</param>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Объект со свойствами из записи</returns>
        public static Waybill SelectItem(MySqlConnection connection, int id)
        {
            var item = new Waybill();
            string query = "SELECT * FROM `накладные` WHERE `Id`=@Id";
            // создаем объект MySqlCommand для выполнения запроса к БД
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var da = new MySqlDataAdapter(command))
                {
                    var data = new DataSet();
                    try
                    {
                        da.Fill(data, "накладные");
                        item.Id = (int)data.Tables[0].Rows[0]["Id"];
                        item.IssueDate = (DateTime)data.Tables[0].Rows[0]["Дата_выпуска"];
                        item.ProcessingDate = (DateTime)data.Tables[0].Rows[0]["Дата_обработки"];
                        item.StateNumber = (int)data.Tables[0].Rows[0]["Гос_номер"];
                        item.DepartureSpeedometerReadings = (int)data.Tables[0].Rows[0]["Спидометр_отправка"];
                        item.ReturningSpeedometerReadings = (int)data.Tables[0].Rows[0]["Спидометр_конец"];
                        item.InitialFuelBalance = (int)data.Tables[0].Rows[0]["Топливо_начало"];
                        item.FuelIssued = (int)data.Tables[0].Rows[0]["Топливо_потрачено"];
                        item.FinalFuelRemainder = (int)data.Tables[0].Rows[0]["Топливо_конец"];
                        item.FuelPassed = (int)data.Tables[0].Rows[0]["Топливо_пропущенно"];
                        item.Order = (int)data.Tables[0].Rows[0]["Заказ"];
                        item.DepartureDateTime = (DateTime)data.Tables[0].Rows[0]["Дата_отправки"];
                        item.ReturnDateTime = (DateTime)data.Tables[0].Rows[0]["Дата_возврат"];
                        item.RepairTime = (float)data.Tables[0].Rows[0]["Время_ремонт"];
                        item.DrivingTime = (float)data.Tables[0].Rows[0]["Время_вождения"];
                        item.EveningTime = (float)data.Tables[0].Rows[0]["ВечернееВремя"];
                        item.NightTime = (float)data.Tables[0].Rows[0]["НочноеВРемя"];
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
        /// Метод для добавления записи в базе данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к базе данных</param>
        /// <param name="item">Ссылка на объект с данными для добавления</param>
        /// <returns>Возвращает идентификатор записи объекта "Путевой лист"</returns>
        public static int AddItem(MySqlConnection connection, Waybill item)
        {
            int id;
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // текст запроса
                    string query = "INSERT INTO `накладные`" +
                        " (`Дата_выпуска`, `Дата_обработки`, `Гос_номер`, `Спидометр_отправка`, `Спидометр_конец`, `Топливо_начало`, `Топливо_потрачено`, `Топливо_конец`, `Топливо_пропущенно`, `Заказ`, `Дата_отправки`, `Дата_возврат`, `Время_ремонт`, `Время_вождения`, `ВечернееВремя`, `НочноеВРемя`)" +
                        " VALUES (@Дата_выпуска, @Дата_обработки, @Гос_номер, @Спидометр_отправка, @Спидометр_конец, @Топливо_начало, @Топливо_потрачено, @Топливо_конец, @Топливо_пропущенно, @Заказ, @Дата_отправки, @Дата_возврат, @Время_ремонт, @Время_вождения, @ВечернееВремя, @НочноеВРемя)";
                    // создаем объект MySqlCommand для выполнения запроса к БД
                    using (var command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@Дата_выпуска", item.IssueDate);
                        command.Parameters.AddWithValue("@Дата_обработки", item.ProcessingDate);
                        command.Parameters.AddWithValue("@Гос_номер", item.StateNumber);
                        command.Parameters.AddWithValue("@Спидометр_отправка", item.DepartureSpeedometerReadings);
                        command.Parameters.AddWithValue("@Спидометр_конец", item.ReturningSpeedometerReadings);
                        command.Parameters.AddWithValue("@Топливо_начало", item.InitialFuelBalance);
                        command.Parameters.AddWithValue("@Топливо_потрачено", item.FuelIssued);
                        command.Parameters.AddWithValue("@Топливо_конец", item.FinalFuelRemainder);
                        command.Parameters.AddWithValue("@Топливо_пропущенно", item.FuelPassed);
                        command.Parameters.AddWithValue("@Заказ", item.Order);
                        command.Parameters.AddWithValue("@Дата_отправки", item.DepartureDateTime);
                        command.Parameters.AddWithValue("@Дата_возврат", item.ReturnDateTime);
                        command.Parameters.AddWithValue("@Время_ремонт", item.RepairTime);
                        command.Parameters.AddWithValue("@Время_вождения", item.DrivingTime);
                        command.Parameters.AddWithValue("@ВечернееВремя", item.EveningTime);
                        command.Parameters.AddWithValue("@НочноеВРемя", item.NightTime);
                        // выполняем запрос к БД
                        command.ExecuteNonQuery();
                    }
                    query = "SELECT MAX(Id) FROM `накладные`";
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
        /// Метод для изменения записи в базе данных
        /// </summary>
        /// <param name="connection">Ссылка на объект подключения к базе данных</param>
        /// <param name="id">Идентификатор записи объекта "Путевой лист"</param>
        /// <param name="item">Ссылка на объект с данными для изменения</param>
        public static void ChangeItem(MySqlConnection connection, int id, Waybill item)
        {
            try
            {
                // текст запроса
                string query = "UPDATE `накладные` SET `Дата_выпуска`=@Дата_выпуска,`Дата_обработки`=@Дата_обработки,`Гос_номер`=@Гос_номер,`Спидометр_отправка`=@Спидометр_отправка,`Спидометр_конец`=@Спидометр_конец,`Топливо_начало`=@Топливо_начало,`Топливо_потрачено`=@Топливо_потрачено,`Топливо_конец`=@Топливо_конец,`Топливо_пропущенно`=@Топливо_пропущенно,`Заказ`=@Заказ,`Дата_отправки`=@Дата_отправки,`Дата_возврат`=@Дата_возврат,`Время_ремонт`=@Время_ремонт,`Время_вождения`=@Время_вождения,`ВечернееВремя`=@ВечернееВремя,`НочноеВРемя`=@НочноеВРемя WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Дата_выпуска", item.IssueDate);
                    command.Parameters.AddWithValue("@Дата_обработки", item.ProcessingDate);
                    command.Parameters.AddWithValue("@Гос_номер", item.StateNumber);
                    command.Parameters.AddWithValue("@Спидометр_отправка", item.DepartureSpeedometerReadings);
                    command.Parameters.AddWithValue("@Спидометр_конец", item.ReturningSpeedometerReadings);
                    command.Parameters.AddWithValue("@Топливо_начало", item.InitialFuelBalance);
                    command.Parameters.AddWithValue("@Топливо_потрачено", item.FuelIssued);
                    command.Parameters.AddWithValue("@Топливо_конец", item.FinalFuelRemainder);
                    command.Parameters.AddWithValue("@Топливо_пропущенно", item.FuelPassed);
                    command.Parameters.AddWithValue("@Заказ", item.Order);
                    command.Parameters.AddWithValue("@Дата_отправки", item.DepartureDateTime);
                    command.Parameters.AddWithValue("@Дата_возврат", item.ReturnDateTime);
                    command.Parameters.AddWithValue("@Время_ремонт", item.RepairTime);
                    command.Parameters.AddWithValue("@Время_вождения", item.DrivingTime);
                    command.Parameters.AddWithValue("@ВечернееВремя", item.EveningTime);
                    command.Parameters.AddWithValue("@НочноеВРемя", item.NightTime);
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
        /// <param name="id">Идентификатор записи объекта "Путевой лист"</param>
        public static void RemoveItem(MySqlConnection connection, int id)
        {
            try
            {
                // текст запроса
                string query = "DELETE FROM `накладные` WHERE `Id`=@Id";
                // создаем объект MySqlCommand для выполнения запроса к БД
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    // выполняем запрос к базе данных
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
