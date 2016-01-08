using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class MessageEnvelope {
        public string Type { get; set; }
        public string Message { get; set; }

        public T Resolve<T>() {
            return JsonConvert.DeserializeObject<T>(this.Message);
        }
    }

    public interface IMessage {
        string Type { get; }
    }

    public interface IPrepareRequest : IMessage {
        AbortRequest GetAbortRequest();
        CommitRequest GetCommitRequest();
    }

    public class BaseMessage : IMessage {
        [JsonIgnore]
        public string Type { get; }

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

    public class PreSetRequest : BaseMessage, IPrepareRequest {
        public const string TypeName = "PreSetRequest";

        public Guid TransactionId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public PreSetRequest() : base(TypeName) { /* empty */ }

        public AbortRequest GetAbortRequest() {
            return new AbortRequest {
                TransactionId = TransactionId
            };
        }

        public CommitRequest GetCommitRequest() {
            return new CommitRequest {
                TransactionId = TransactionId,
                Action = TransactionActions.Set,
                Key = Key,
                Value = Value
            };
        }
    }

    public class PrepareResponse : BaseMessage {
        public const string TypeName = "PrepareResponse";
        public bool CanCommit { get; set; }

        public PrepareResponse() : base(TypeName) { /* empty */ }
    }

    public class PreDeleteRequest : BaseMessage, IPrepareRequest {
        public const string TypeName = "PreDeleteRequest";
        public Guid TransactionId { get; set; }
        public string Key { get; set; }

        public PreDeleteRequest() : base(TypeName) { /* empty */ }

        public AbortRequest GetAbortRequest() {
            return new AbortRequest {
                TransactionId = TransactionId
            };
        }

        public CommitRequest GetCommitRequest() {
            return new CommitRequest {
                TransactionId = TransactionId,
                Action = TransactionActions.Delete,
                Key = Key,
            };
        }
    }

    public class CommitRequest : BaseMessage {
        public const string TypeName = "CommitRequest";
        public Guid TransactionId { get; set; }
        public TransactionActions Action { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        [JsonIgnore]
        public bool IsDeleteAction => Action == TransactionActions.Delete;

        [JsonIgnore]
        public bool IsSetAction => Action == TransactionActions.Set;

        public CommitRequest() : base(TypeName) { /* empty */ }
    }

    public class CommitResponse : BaseMessage {
        public const string TypeName = "CommitResponse";

        public bool Committed { get; set; }

        public CommitResponse() : base(TypeName) { /* empty */ }
    }

    public class AbortRequest : BaseMessage {
        public const string TypeName = "AbortRequest";
        public Guid TransactionId { get; set; }

        public AbortRequest() : base(TypeName) { /* empty */ }
    }

    public class AbortResponse : BaseMessage {
        public const string TypeName = "AbortResponse";

        public bool Aborted { get; set; }

        public AbortResponse() : base(TypeName) { /* empty */ }
    }
}
