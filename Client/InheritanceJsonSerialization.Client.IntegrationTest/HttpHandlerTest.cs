using System.Linq;
using System.Threading.Tasks;
using InheritanceJsonSerialization.Client.Models;
using InheritanceJsonSerialization.Client.Services;
using InheritanceJsonSerialization.Client.Services.Http.Impl;
using Xunit;

namespace InheritanceJsonSerialization.Client.IntegrationTest
{
    public class HttpHandlerTest
    {
        [Fact]
        public async Task GetData_WhenInvoked_TheListHasItems()
        {
            var httpHandler = new HttpHandler();

            var result = await httpHandler.GetData();

            Assert.True(result.Any());
        }

        [Fact]
        public async Task GetData_WhenInvoked_TheListContainsOneChildClass()
        {
            var httpHandler = new HttpHandler();

            var result = await httpHandler.GetData();

            Assert.True(result.Any(r => r.GetType() == typeof(ChildClass)));
        }
    }
}
