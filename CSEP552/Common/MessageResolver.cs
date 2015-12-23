using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class MessageResolver {
        public BaseMessage Resolve(MessageEnvelope envelope) {
            switch(envelope.Type) {
                case GetValueRequest.TypeName:
                    return envelope.Resolve<GetValueRequest>();
                case GetValueResponse.TypeName:
                    return envelope.Resolve<GetValueResponse>();
                case PreDeleteRequest.TypeName:
                    return envelope.Resolve<PreDeleteRequest>();
                case PreDeleteResponse.TypeName:
                    return envelope.Resolve<PreDeleteResponse>();
                case PreSetRequest.TypeName:
                    return envelope.Resolve<PreSetRequest>();
                case PreSetResponse.TypeName:
                    return envelope.Resolve<PreSetResponse>();
                default:
                    throw new ArgumentOutOfRangeException("envelope.Type");
            }
        }
    }
}
