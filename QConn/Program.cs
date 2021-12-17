using System;
using kx;

namespace QConn {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello World!");

            //establish connection
            c connection = null;
            try {
                connection = new c("localhost", 5002) {
                    ReceiveTimeout = 1000
                };
                c.e = System.Text.Encoding.UTF8;

                Console.WriteLine("Unicode " + connection.k("`$\"c\"$0x52616e627920426ac3b6726b6c756e64204142"));

                //insert some data-rows
                object[] x = new object[]
                {
                    300
		};

                for (var i = 0; i < 1000; ++i) {
//                    x[2] = i+1;
//		    connection.k("insert", "traded", 100);
               }


                //read data
                var result = c.td(connection.k("select sum price from traded"));

                Console.WriteLine("cols: " + result.x[0]);
                Console.WriteLine("rows: " + ((int[])result.y[0])[0]);
            } finally
            {
                //finally close connection
                connection?.Close();
		Console.WriteLine("Done.");
	    }
        }
    }
}
