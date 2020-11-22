using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Deskly.DNT.EFCore.Context.Hooks
{
    public class HookEntityMetadata
    {
        public HookEntityMetadata(EntityEntry entry)
        {
            Entry = entry;
        }

        public EntityEntry Entry { get; }
    }
}