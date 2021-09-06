using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Text;
using Xunit;
using Xunit.Harness;

namespace VSIXTestProject
{
    public class UnitTest1
    {
        [IdeFact(MinVersion = VisualStudioVersion.VS2019, MaxVersion = VisualStudioVersion.VS2019)]
        public void Test1()
        {
            var componentModel = GlobalServiceProvider.ServiceProvider.GetService(typeof(SComponentModel)) as IComponentModel;
            var textBufferFactoryService = componentModel.GetService<ITextBufferFactoryService>();

            var buffer = textBufferFactoryService.CreateTextBuffer("Test text buffer", textBufferFactoryService.PlaintextContentType);
            var firstSnapshot = buffer.CurrentSnapshot;

            var secondSnapshot = buffer.Insert(1, "123");

            Assert.Equal("Test text buffer", firstSnapshot.GetText());
            Assert.Equal("T123est text buffer", secondSnapshot.GetText());
        }
    }
}
