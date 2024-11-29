using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QZ14.Configuration;

public class Configuration
{
    public static string ConnectionString { get; set; }

    static Configuration()
    {
        ConnectionString = "Data Source=WKK13\\SQLEXPRESS;Initial Catalog=qz14;User ID=sa;Password=111222333aA;TrustServerCertificate=True;Encrypt=True";
    }
}
