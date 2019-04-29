
namespace CMD.CheckOptions
{
    class InputEdit
    {
        public static string [] Edit(string Input, string command)
        {
            string getPath = Input.Replace(command, "");
            getPath = getPath.TrimEnd(' ');
            getPath = getPath.TrimStart(' ');
            getPath = System.Text.RegularExpressions.Regex.Replace(getPath, @"\s+", " ");
            string[] modifPath = getPath.Split(new char[] { ' ' });
            return modifPath;
        }
    }
}
