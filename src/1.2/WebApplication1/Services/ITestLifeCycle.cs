namespace WebApplication1.Services
{
    public interface ITestLifeCycle
    {
        string Id { get; set; }
    }

    public interface ISingleton : ITestLifeCycle { }
    public interface IScoped : ITestLifeCycle { }
    public interface ITransient : ITestLifeCycle { }




}
