namespace TestApp.Services
{
    public class TextProcessor: ITextProcessor
    {
        public string ProcessText(string s)
        {
            return string.Format("Processed text: {0}", s);
        }
    }
}