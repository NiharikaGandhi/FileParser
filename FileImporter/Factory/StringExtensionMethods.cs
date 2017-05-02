using System.Text.RegularExpressions;

namespace FileImporter.Factory
{
    public interface IStringExtensionMethods
    {
        string GetString(string content, int startPos, int endPosition);
        string RemoveTab(string contentWithTab);
    }
    public class StringExtentionMethods : IStringExtensionMethods
    {
        public string GetString(string content, int startPos, int endPosition)
        {
            int count;
            var strLength = content.Length;
            if (startPos < 0)
            {
                startPos = 0;
            }
            if (startPos >= strLength)
            {
                startPos = strLength;
            }
            if (endPosition > strLength)
            {
                count = strLength - startPos;
            }
            else
            {
                count = endPosition - startPos ;
            }
            return content.Substring(startPos, count).Trim();
        }

        public string RemoveTab(string contentWithTab)
        {
            return Regex.Replace(contentWithTab, "\\t", "    ");
        }
    }
}