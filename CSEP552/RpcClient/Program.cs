﻿using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RpcClient {
    class Program {
        static void Main(string[] args) {
            Foo("1");

            Console.Read();
        }

        static void Foo(string id) {
            var endpoint = new IPEndPoint(IPAddress.Loopback, 1112);
            var replica = KeyValueReplica.ForEndpoint(endpoint);

            var fooKey = "foo";

            var fooValue = replica.Get(fooKey);

            using (var tx = replica.StartSet(fooKey, "moo")) {
                if (tx.Prepare()) {
                    tx.Commit();
                }
                else {
                    Console.WriteLine("Prepare failed");
                }
            }

            var fooValue2 = replica.Get(fooKey);

            using (var tx = replica.StartDelete(fooKey)) {
                if (tx.Prepare()) {
                    tx.Commit();
                }
            }

            var fooValue3 = replica.Get(fooKey);
        }
    }
}
