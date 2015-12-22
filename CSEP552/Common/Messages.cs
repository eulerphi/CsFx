using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class BaseMessage {
        public string Type { get; set; }

        public BaseMessage(string type) {
            this.Type = type;
        }
    }

    public class GetValueRequest : BaseMessage {
        public const string TypeName = "GetValueRequest";

        public string Key { get; set; }

        public GetValueRequest() : base(TypeName) { /* empty */ }
    }

    public class GetValueResponse : BaseMessage {
        public const string TypeName = "GetValueResponse";

        public string Value { get; set; }

        public GetValueResponse() : base(TypeName) { /* empty */ }
    }

    public class PreSetRequest : BaseMessage {
        public const string TypeName = "PreSetRequest";

        public Guid TransactionId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public PreSetRequest() : base(TypeName) { /* empty */ }
    }

    public class PreSetResponse : BaseMessage {
        public const string TypeName = "PreSetResponse";
        public bool CanCommit { get; set; }

        public PreSetResponse() : base(TypeName) { /* empty */ }
    }

    public class PreDeleteRequest : BaseMessage {
        public const string TypeName = "PreDeleteRequest";
        public Guid TransactionId { get; set; }
        public string Key { get; set; }

        public PreDeleteRequest() : base(TypeName) { /* empty */ }
    }

    public class PreDeleteResponse : BaseMessage {
        public const string TypeName = "PreDeleteResponse";
        public bool CanCommit { get; set; }

        public PreDeleteResponse() : base(TypeName) { /* empty */ }
    }

    public class CommitRequest : BaseMessage {
        public const string TypeName = "CommitRequest";
        public Guid TransactionId { get; set; }

        public CommitRequest() : base(TypeName) { /* empty */ }
    }
}
