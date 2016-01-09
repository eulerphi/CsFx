using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public interface IRequestHandler {
        bool TryHandle(IMessage request, out IMessage response);
    }
}
