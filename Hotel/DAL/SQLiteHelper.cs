using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL
{
    internal class SQLiteHelper
    {
        internal static List<Guest> GetUsers()
        {
            try
            {
                using(var connection = new SQLiteConnection(@"Data Source=Guests.sqlite;Version=3;"))
                {
                    connection.Open();
                    using(var cmd = new SQLiteCommand(@"SELECT id,
       Name,
       Status,
       DateIn,
       DateOut
  FROM guests;", connection))
                    {
                        using(var rdr = cmd.ExecuteReader())
                        {
                            List<Guest> guests = new List<Guest>();
                            while (rdr.Read())
                            {
                                guests.Add(new Guest
                                {
                                    id = rdr.GetInt32(0),
                                    Name = rdr.GetString(1),
                                    Status = rdr.GetString(2),
                                    DateIn = rdr.GetString(3),
                                    DateOut = rdr.GetString(4),
                                });
                            }

                            return guests;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
