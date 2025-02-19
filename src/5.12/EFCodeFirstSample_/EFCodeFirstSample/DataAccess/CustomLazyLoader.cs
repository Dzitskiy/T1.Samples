using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFCodeFirstSample.DataAccess
{
    public class CustomLazyLoader : ILazyLoader
    {
        private readonly ILazyLoader _lazyLoader;

        public CustomLazyLoader(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsLoaded(object entity, [CallerMemberName] string navigationName = "")
        {
            throw new NotImplementedException();
        }

        public void Load(object entity, ref object navigationField)
        {
            if (navigationField == null)
            {
                var entry = ((DbContext)entity).Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    entry.State = EntityState.Unchanged;
                }
                entry.Collection(navigationField.GetType().Name).Load();
            }
        }

        public void Load(object entity, [CallerMemberName] string navigationName = "")
        {
            throw new NotImplementedException();
        }

        public Task LoadAsync(object entity, CancellationToken cancellationToken = default, [CallerMemberName] string navigationName = "")
        {
            throw new NotImplementedException();
        }

        public void SetLoaded(object entity, [CallerMemberName] string navigationName = "", bool loaded = true)
        {
            throw new NotImplementedException();
        }
    }
}
