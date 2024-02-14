using MySql.Data.MySqlClient;
using AdvancedDynamicServer.Network;
using AdvancedDynamicServer.model;

namespace AdvancedDynamicServer.model.Sql;

public class User
{
    //连接mysql数据库
    public static void Userinfo()
    {
<<<<<<< HEAD
        string connectionString =  //连接数据库的字符串
            "Server=" +
            "Database=" +
            "User ID=" +
            "Password=" +
            "Pooling=" +
            "CharSet=utf8;";
=======
        string connectionString = @"Server=rm-bp1885n5396ao5q8vco.mysql.rds.aliyuncs.com;" +
                                  "Port=3306;" +
                                  "Database=lianfeiaccount;" +
                                  "User ID=wangxuan;" +
                                  "Password=Wrx2918095@";
>>>>>>> 7332b56 (完成ATC登陆)


        // 创建MySqlConnection对象，用于建立与MySQL数据库的连接
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                // 打开数据库连接
                connection.Open();

                // 创建 MySqlCommand 对象，用于执行 SQL 语句
<<<<<<< HEAD
                using (MySqlCommand command = new MySqlCommand("SELECT cid, password, level FROM `user`", connection))
=======
                using (MySqlCommand command = new MySqlCommand("SELECT username, password, level FROM `user`", connection))
>>>>>>> 7332b56 (完成ATC登陆)
                {
                    // 执行查询，并返回 MySqlDataReader 对象
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //将查询的数据写入Network.Server.user
                        while (reader.Read())
                        {
                            // 获取列的值
<<<<<<< HEAD
                            string cid = reader.GetString("cid");
=======
                            string cid = reader.GetString("username");
>>>>>>> 7332b56 (完成ATC登陆)
                            string password = reader.GetString("password");
                            string level = reader.GetString("level");

                            // 检查键是否已存在
                            if (!NetworkServer.user.ContainsKey(cid))
                            {
                                // 把数据添加到字典
                                NetworkServer.user.Add(cid, Tuple.Create(password, level));
                                //使用结构体
                            }
                            else
                            {
                                // 如果键已存在，可以选择更新现有值或者采取其他操作
                                NetworkServer.user[cid] = Tuple.Create(password, level);
                            }
                        }

                    }
                }


                // 在此关闭数据库连接
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询失败：" + ex.Message);
            }
        }
    }
}