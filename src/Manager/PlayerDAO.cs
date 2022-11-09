using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Serialization;

namespace Dungeon_Crawl.src.Manager
{
    internal class PlayerDao : IPlayerDao
    {
        private readonly string _connectionString;
        private const string DateFormat = "yyyy-MM-dd";
        public PlayerDao(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static string SerializeToXml(object value)
        {
            StringWriter writer = new StringWriter(CultureInfo.InvariantCulture);
            XmlSerializer serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public void Add(Player player)
        {
            const string insertCommand = @"INSERT INTO characters (player)
                        VALUES (@serialized_player)
                        SELECT SCOPE_IDENTITY();";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand(insertCommand, connection);
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    cmd.Parameters.AddWithValue("@serialized_player", SerializeToXml(player));

                    Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                throw new RuntimeWrappedException(e);
            }
        }

        public Player Get(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
