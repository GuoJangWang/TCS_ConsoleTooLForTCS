using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTooLForTCS
{
    public class Lib
    {
        public void UpdateUserLoginStatus()
        {
            string connectionString = @"Provider=SQLOLEDB;" +
                @"Data Source=JOHN202302ALJ\MSSQLSERVER2019;" +
                @"Initial Catalog=TCSBaNCSLinkV4TIB;" +
                @"User ID=sa;" +
                @"Password=@80138305jJ20241;";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // 創建一個命令物件，指定存儲過程的名稱
                    OleDbCommand command = new OleDbCommand("John_UpdateUserStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    // 如果有需要，可以添加存儲過程所需的參數
                    // command.Parameters.AddWithValue("@ParameterName", value);

                    // 執行存儲過程
                    command.ExecuteNonQuery();

                    Console.WriteLine("存儲過程成功執行。");

                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("存儲過程執行時出現錯誤： " + ex.Message);
                }
            }
        }
    }
}
