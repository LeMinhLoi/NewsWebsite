using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Utilities.CreatePathImage
{
    public static class CreatePathImage
    {
        public static string PathImage(string path)
        {
            string[] item = path.Split("\\");
            string newPath = "";
            for(int i = 0; i < item.Length; i++)
            {
                if (i == 0)
                {
                    newPath += item[i];
                }
                else
                {
                    newPath += "/" + item[i];
                }
                //newPath += "/" + item[i];

            }
            Console.WriteLine(newPath);
            return newPath;
        }
    }
}
