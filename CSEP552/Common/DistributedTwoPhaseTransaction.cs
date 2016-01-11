using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common {
    public class DistributedTwoPhaseTransaction : IDisposable {
        private readonly IList<TwoPhaseTransaction> transactions;

        public DistributedTwoPhaseTransaction(IList<TwoPhaseTransaction> transactions) {
            this.transactions = transactions;
        }

        public void Dispose() {
            foreach (var tx in transactions) {
                tx.Dispose();
            }
        }

        public bool Run(Action markTransactionCommitted) {
            var prepareTasks = PrepareAsync();
            Task.WaitAll(prepareTasks);

            var canCommit = prepareTasks.All(t => t.Result);

            if (canCommit) {
                markTransactionCommitted();
            }

            var tasks = canCommit
                ? CommitAsync()
                : AbortAsync();
            Task.WaitAll(tasks);

            return canCommit;
        }

        private Task[] AbortAsync() {
            return transactions
                .Where(tx => tx.State == TwoPhaseCommitState.Prepared)
                .Select(tx => Task.Run(() => tx.Abort()))
                .ToArray();
        }

        private Task[] CommitAsync() {
            return transactions
                .Select(tx => Task.Run(() => tx.Commit()))
                .ToArray();
        }

        private Task<bool>[] PrepareAsync() {
            return transactions
                .Select(tx => Task.Run(() => tx.Prepare()))
                .ToArray();
        }
    }
}
