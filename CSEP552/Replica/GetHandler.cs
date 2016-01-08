using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;
using System.Data;

namespace Replica {
    class GetHandler : IRequestHandler {
        private readonly Func<GetValueRequest, string> get;

        public GetHandler(Func<GetValueRequest, string> get) {
            this.get = get;
        }

        public static GetHandler ForConnection(SQLiteConnection connection) {
            return new GetHandler(r => Get(connection, r));
        }

        public GetValueResponse Get(GetValueRequest request) {
            var value = get(request);

            return new GetValueResponse {
                Value = value
            };
        }

        public bool TryHandle(IMessage request, out IMessage response) {
            response = null;

            if (request.Type == GetValueRequest.TypeName) {
                response = Get((GetValueRequest)request);
            }

            return response != null;
        }

        private static string Get(SQLiteConnection connection, GetValueRequest request) {
            var manager = KeyValueManager.ForConnection(connection);
            return manager.GetValue(request.Key);
        }
    }
}
