using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class MessageResolver {
        public IMessage Resolve(MessageEnvelope envelope) {
            switch(envelope.Type) {
                case AbortRequest.TypeName:
                    return envelope.Resolve<AbortRequest>();
                case AbortResponse.TypeName:
                    return envelope.Resolve<AbortResponse>();
                case CommitRequest.TypeName:
                    return envelope.Resolve<CommitRequest>();
                case CommitResponse.TypeName:
                    return envelope.Resolve<CommitResponse>();
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
