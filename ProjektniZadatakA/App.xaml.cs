﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Haley.Utils;
using System.Globalization;
using System.Threading;

namespace ProjektniZadatakA
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
       
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //CultureInfo culture = CultureInfo.CreateSpecificCulture("en");
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;

        }

        public static void ChangeCulture(string code)
        {
           // LangUtils.ChangeCulture(code);
        }
    }
}
