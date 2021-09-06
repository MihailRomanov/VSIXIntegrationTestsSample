using Microsoft.VisualStudio.Text;
using System.ComponentModel.Composition;

namespace VSIXProject
{
    [Export]
    public class SimpleTextComponent
    {
        [Import]
        ITextBufferFactoryService textBufferFactoryService;

        public string ConvertString(string str1, string str2, int position)
        {
            var buffer = textBufferFactoryService.CreateTextBuffer(str1, textBufferFactoryService.TextContentType);
            var result = buffer.Insert(position, str2);

            return result.GetText();
        }
    }
}
