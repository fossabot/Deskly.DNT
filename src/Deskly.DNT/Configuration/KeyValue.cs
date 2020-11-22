using Deskly.DNT.Domain;

namespace Deskly.DNT.Configuration
{
    public class KeyValue : IHasRowVersion, IHasRowIntegrity, ICreationTracking, IModificationTracking
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }
        public byte[] Version { get; set; }
    }
}