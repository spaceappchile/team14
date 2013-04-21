using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Configuration;

namespace ALMAServiceListenXML
{
    public partial class ALMAServiceListenXML : ServiceBase
    {
        public ALMAServiceListenXML()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            FSWatcher.Path = ConfigurationSettings.AppSettings["WatchPath"];
        }

        protected override void OnStop()
        {
        }
    }
}
