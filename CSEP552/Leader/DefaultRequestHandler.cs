using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leader {
    class DefaultRequestHandler : IRequestHandler {
        private readonly IList<IRequestHandler> handlers;

        public DefaultRequestHandler(IList<IRequestHandler> handlers) {
            this.handlers = handlers;
        }

        public static DefaultRequestHandler Create(
            SQLiteConnection connection,
            KeyValueReplicaEnsemble ensemble) {

            var manager = CommittedTransactionManager.ForConnection(connection);

            return new DefaultRequestHandler(new List<IRequestHandler> {
                new DeleteValueHandler(ensemble, manager.Add),
                new GetHandler(ensemble),
                new SetHandler(ensemble, manager.Add)
            });
        }

        public bool TryHandle(IMessage request, out IMessage response) {
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
