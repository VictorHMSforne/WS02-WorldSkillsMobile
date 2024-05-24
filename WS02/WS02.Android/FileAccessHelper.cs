using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WS02.Droid
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // criação do BD interno, ou seja, o caminho que vai ser salvo o BD
            return System.IO.Path.Combine(path, filename);
            //Vai salvar localmente; Local: /usr/var/WS02/data.db <-dentro do android

        }
    }
}