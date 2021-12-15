using System;
using kx;

namespace QConn {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            //establish connection
            c connection = null;
            try {
                connection = new c("localhost", 5001) {
                    ReceiveTimeout = 1000
                };
                c.e = System.Text.Encoding.UTF8;

                Console.WriteLine("Unicode " + connection.k("`$\"c\"$0x52616e627920426ac3b6726b6c756e64204142"));

                //insert some data-rows
                object[] x = new object[]
                {
                    DateTime.Now.TimeOfDay,
                    "xx",
                    (double)93.5,
                    300,
                };

                for (var i = 0; i < 1000; ++i) {
                    connection.k("insert", "trade", x);
                }

                //read data
                var result = c.td(connection.k("select sum price by sym from trade"));

                Console.WriteLine("cols: " + c.n(result.x));
                Console.WriteLine("rows: " + c.n(result.y[0]));
            } finally
            {
                //finally close connection
                connection?.Close();
            }
        }
    }
}
