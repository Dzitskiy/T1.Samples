using System.Text;

namespace WebApplication1.Services
{
    public class SomeService : ISomeService
    {
        private readonly ISingleton _singleton1, _singleton2;
        private readonly IScoped _scoped1, _scoped2;
        private readonly ITransient _transient1, _transient2;

        public SomeService(
            ISingleton singleton1, ISingleton singleton2,
            IScoped scoped1, IScoped scoped2,
            ITransient transient1, ITransient transient2) 
        { 
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _transient1 = transient1;
            _transient2 = transient2;        
        }

        public string GetTestLifeCycle()
        {
            var result = new StringBuilder();
            result.AppendLine($"singleton: {_singleton1.Id}, scoped: {_scoped1.Id}, transient: {_transient1.Id}");
            result.AppendLine($"singleton: {_singleton2.Id}, scoped: {_scoped2.Id}, transient: {_transient2.Id}");
            return result.ToString();   
        }
    }
}
