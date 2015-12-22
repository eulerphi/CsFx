using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    class SetHandler {
        public PreSetResponse PreSet(PreSetRequest request) {

            return new PreSetResponse {
                CanCommit = false
            };
        }
    }
}
