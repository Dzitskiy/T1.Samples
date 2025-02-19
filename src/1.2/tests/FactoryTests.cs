using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using Shouldly;
using Xunit;

namespace TestSamples
{
    public class FactoryTests
    {


        [Fact]
        public void ShouldResolveFactory()
        {
            using var serviceProvider = new ServiceCollection()
                .AddTransient<ISomeServiceFactory, SomeServiceFactory>()
                .BuildServiceProvider();

            serviceProvider
                .GetRequiredService<ISomeServiceFactory>()
                .Create()
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldResolveWithDelegateFactory1()
        {
            using var serviceProvider = new ServiceCollection()
                .AddTransient<ISomeServiceFactory, SomeServiceFactory>()
                .AddTransient(container =>
                    container.GetRequiredService<ISomeServiceFactory>().Create())
                .BuildServiceProvider();

            serviceProvider
                .GetRequiredService<ISomeService>()
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldResolveWithDelegateFactory2()
        {
            using var serviceProvider = new ServiceCollection()
                .AddTransient<IAnotherService>(_ =>
                    new AnotherService(new OptionsWrapper<SomeSettings>(new SomeSettings())))
                .BuildServiceProvider();

            serviceProvider
                .GetRequiredService<IAnotherService>()
                .ShouldNotBeNull();
        }

        [Fact]
        public void ShouldResolveWithDelegateFactory3()
        {
            using var serviceProvider = new ServiceCollection()
                .AddSingleton<Func<ISomeService>>(() =>
                    new SomeService())
                .BuildServiceProvider();

            serviceProvider
                .GetRequiredService<Func<ISomeService>>()
                ()
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task ShouldResolveWithAsyncDelegateFactory()
        {
            using var serviceProvider = new ServiceCollection()
                .AddSingleton<Func<Task<ISomeService>>>(async () =>
                {
                    await Task.Delay(100);
                    return new SomeService();
                })
                .BuildServiceProvider();

            var someService = await serviceProvider
                .GetRequiredService<Func<Task<ISomeService>>>()
                ();

            someService.ShouldNotBeNull();
        }
    }

    public interface ISomeServiceFactory
    {
        ISomeService Create();
    }

    public class SomeServiceFactory : ISomeServiceFactory
    {
        public ISomeService Create() => new SomeService();
    }

    public interface IAnotherService
    {
        string JoinedList { get; }
    }

    public class AnotherService : IAnotherService
    {
        private readonly IOptions<SomeSettings> _options;

        public AnotherService(IOptions<SomeSettings> options)
        {
            _options = options;
        }

        public string JoinedList => string.Join(", ", _options.Value.SomeList);
    }

    public class SomeSettings
    {
        public int SomeInt { get; set; }
        public string SomeString { get; set; }
        public SubObj SubObject { get; set; }
        public List<int> SomeList { get; set; }
    }

    public class SubObj
    {
        public string SomeProp { get; set; }
    }

}