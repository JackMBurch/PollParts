using System.Text;

namespace PollParts
{
    public class CSVUtils
    {

        /// <summary>
        /// Turn a string into a CSV cell output
        /// </summary>
        /// <param name="str">String to output</param>
        /// <returns>The CSV cell formatted string</returns>
        public static string? StringToCSVCell(string? str)
        {
            if (str != null)
            {
                bool mustQuote = str.Contains(',') || str.Contains('"') || str.Contains('\r') || str.Contains('\n');
                if (mustQuote)
                {
                    StringBuilder sb = new();
                    sb.Append('"');
                    foreach (char nextChar in str)
                    {
                        sb.Append(nextChar);
                        if (nextChar == '"')
                            sb.Append('"');
                    }
                    sb.Append('"');
                    return sb.ToString();
                }

                return str;
            }
            else return null;
        }
    }
}
