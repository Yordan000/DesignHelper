using DesignHelper.Core.Contracts;
using System.Text;
using System.Text.RegularExpressions;

namespace DesignHelper.Core.Exceptions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IProjectModel project)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(project.Title.Replace(" ", "-"));
            sb.Append("-");
            sb.Append(GetLocation(project.Location));

            return sb.ToString();
        }

        private static string GetLocation(string location)
        {
            string result = string.Join("-",location.Split(" ", StringSplitOptions.RemoveEmptyEntries).Take(3));
         
            return Regex.Replace(location, @"[^a-zA-Z0-9\-]", string.Empty);
        }
    }
}
