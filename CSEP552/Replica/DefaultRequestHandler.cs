using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class DefaultRequestHandler : IRequestHandler {
        private readonly IList<IRequestHandler> handlers;

        public DefaultRequestHandler(IList<IRequestHandler> handlers) {
            this.handlers = handlers;
        }

        public static DefaultRequestHandler ForConnection(SQLiteConnection connection) {
            return new DefaultRequestHandler(new List<IRequestHandler> {
                GetHandler.ForConnection(connection),
                SetHandler.ForConnection(connection)
            });
        }

        public bool TryHandle(BaseMessage request, out BaseMessage response) {
            response = null;

            foreach (var h in handlers) {
                if (h.TryHandle(request, out response)) {
                    return true;
                }
            }

            return false;
        }
    }
}
