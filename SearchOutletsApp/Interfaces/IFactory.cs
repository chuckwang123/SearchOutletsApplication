namespace SearchOutletsApp.Interfaces
{
    public interface IFactory
    {
        IConfigurationManager WebConfig { get; }
        IFileReader Files { get; }
    }

}
