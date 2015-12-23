using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica {
    public interface IRequestHandler {
        bool TryHandle(BaseMessage request, out BaseMessage response);
    }
}
