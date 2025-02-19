namespace WebApplication1.Services
{
    public class TestLifeCycle : ISingleton, IScoped, ITransient
    {
        public string Id { get; set; }

        public TestLifeCycle()
        { 
            Id = Guid.NewGuid().ToString();        
        }
    }
}
