using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace HelloWorld
{
    public static class DatabaseService
    {
        public static bool EnableLogging = true;

        public static void ExecuteCommands(this string sql, IDbConnection connection)
        {
            if (EnableLogging) { Console.WriteLine("Queries Beginning: " + DateTime.Now.ToString()); }
            string[] sqlCommands = sql.Split(";");
            for (int i = 0; i < sqlCommands.Length; i++)
            {
                if (EnableLogging) { Console.WriteLine(string.Format("Executing Query {0} of {1}", (i + 1).ToString(), sqlCommands.Length.ToString())); }
                string sqlCommand = sqlCommands[i];
                sqlCommand.ExecuteCommand(connection);
            }
            if (EnableLogging) { Console.WriteLine("Queries Ended: " + DateTime.Now.ToString()); }

        }
        public static int ExecuteCommand(this string sql, IDbConnection connection)
        {
            if (connection.GetType() == typeof(NpgsqlConnection))
            {
                return ExecuteCommand(sql, (NpgsqlConnection)connection);
            }
            else
            {
                throw new NotImplementedException();
            }

        }

        

        public static void BulkLoad<T>(string tableName, List<T> list, NpgsqlConnection connection)
        {
            connection.OpenConnection();
            using (var writer = connection.BeginBinaryImport(string.Format("Copy {0} from STDIN (FORMAT BINARY)", tableName)))
            {
                foreach (object obj in list)
                {
                    writer.StartRow();
                    foreach (var propertyInfo in obj.GetType()
                                .GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            writer.Write(propertyInfo.GetValue(obj).ToString());
                        }
                        else if(propertyInfo.PropertyType == typeof(Color))
                        {
                            Color colorVal = (Color)propertyInfo.GetValue(obj); 
                            writer.Write(colorVal.ToString());
                        }
                        else if(propertyInfo.PropertyType.IsArray)
                        {
                            ShoeOrientation[] arrayVals = (ShoeOrientation[])propertyInfo.GetValue(obj);
                            writer.Write(string.Join(",",arrayVals.Select(a => a.ToString()).ToArray()));                            
                        }
                        else
                        {
                            var val = propertyInfo.GetValue(obj);
                            if (val == null)
                            {
                                writer.WriteNull();
                            }
                            else
                            {
                                
                                writer.Write(val,getPostgresType(propertyInfo));
                            }
                        }
                    }

                }
                writer.Complete();
            }
        }
        private static NpgsqlDbType getPostgresType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(decimal))
            {
                return NpgsqlDbType.Numeric;
            }
            else if(prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
            {
                return NpgsqlDbType.Date;
            }
            else if(prop.PropertyType == typeof(int))
            {
                return NpgsqlDbType.Integer;
            }
            else
            {
                return NpgsqlDbType.Varchar;
            }
        }

        private static int ExecuteCommand(this string sql, NpgsqlConnection connection)
        {
            NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            OpenConnection(connection);
            int val = cmd.ExecuteNonQuery();
            if (EnableLogging) { Console.WriteLine(val.ToString() + " Records Affected"); }
            return val;
        }


        public static void OpenConnection(this IDbConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

    }
}