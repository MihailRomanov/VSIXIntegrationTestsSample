using Microsoft.VisualStudio.ComponentModelHost;
using VSIXProject;
using Xunit;
using Xunit.Harness;

[assembly: RequireExtension("VSIXProject.vsix")]

namespace VSIXTestProject
{
    public class VSIXTest
    {
        [IdeFact(MinVersion = VisualStudioVersion.VS2019, MaxVersion = VisualStudioVersion.VS2019)]
        public void Test1()
        {
            var componentModel = GlobalServiceProvider.ServiceProvider.GetService(typeof(SComponentModel)) as IComponentModel;
            var component = componentModel.GetService<SimpleTextComponent>();

            var result = component.ConvertString("Test text buffer", "123", 1);
            Assert.Equal("T123est text buffer", result);
        }
    }
}
