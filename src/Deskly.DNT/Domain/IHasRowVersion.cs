namespace Deskly.DNT.Domain
{
    public interface IHasRowVersion
    {
        byte[] Version { get; set; }
    }
}