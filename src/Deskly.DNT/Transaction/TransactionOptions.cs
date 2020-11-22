using System;
using System.Data;

namespace Deskly.DNT.Transaction
{
    public sealed class TransactionOptions
    {
        public TimeSpan? Timeout { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }
    }
}