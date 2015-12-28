using System;

namespace ShanesSpot.ExtensionMethods
{
    public class CustomHtml
    {

        // fail
        public static string SubmitButton(string text = "Submit")
        {
            return String.Format(@"", text);
        }
    }
}