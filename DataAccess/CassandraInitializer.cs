    using System;
    using Cassandra;  
    using System.Diagnostics;  
    //using System.Net.Security;  
    //using System.Security.Authentication;  
    //using System.Security.Cryptography.X509Certificates;  
    using System.Threading.Tasks;  
      
    namespace cassandraWebapi.DataAccess 
    {  
        public static class CassandraInitializer  
        {  
            // Cassandra Cluster Configs        
           
            public static ISession session;  
      
            public static async Task InitializeCassandraSession()  
            {  
                // Connect to cassandra cluster  (Cassandra API on Azure Cosmos DB supports only TLSv1.2)  
                // var options = new SSLOptions(SslProtocols.Tls12, true, ValidateServerCertificate);  
                // options.SetHostNameResolver((ipAddress) => CassandraContactPoint);  
                // Cluster cluster = Cluster.Builder().WithCredentials(UserName, Password).WithPort(CassandraPort).AddContactPoint(CassandraContactPoint).WithSSL(options).Build();  
      
                // session = await cluster.ConnectAsync("sarathlal");  
                 var cluster = Cluster.Builder()
                     .AddContactPoints("localhost")
                     .Build();

                  // Connect to the nodes using a keyspace     
                session = await cluster.ConnectAsync("cycling");       
                 var rs = session.Execute("SELECT * FROM MusicPlaylist");
                // Iterate through the RowSet
                // foreach (var row in rs)
                // {
                //     Console.WriteLine(row[0]);
                //     Console.WriteLine(row[1]);
                //     Console.WriteLine(row[2]);
                
                // }

            }  
      
            // public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)  
            // {  
            //     if (sslPolicyErrors == SslPolicyErrors.None)  
            //         return true;  
      
            //     Trace.WriteLine("Certificate error: {0}", sslPolicyErrors.ToString());  
            //     // Do not allow this client to communicate with unauthenticated servers.  
            //     return false;  
            // }  
        }  
    }  
