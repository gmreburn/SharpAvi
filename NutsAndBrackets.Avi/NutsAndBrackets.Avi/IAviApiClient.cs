namespace NutsAndBrackets.Avi
{
    public interface IAviClient
    {
        IPoolsController Pools { get; }

        IVirtualServicesController VirtualServices { get; }
    }
}