using System.Configuration;
using System.IO;
namespace ALMAServiceListenXML
{
    partial class ALMAServiceListenXML
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FSWatcher = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).BeginInit();
            // 
            // FSWatcher
            // 
            this.FSWatcher.EnableRaisingEvents = true;
            this.FSWatcher.Filter = "*.xml";
            this.FSWatcher.Changed += new System.IO.FileSystemEventHandler(this.FSWatcher_Changed);
            this.FSWatcher.Created += new System.IO.FileSystemEventHandler(this.FSWatcher_Created);
            this.FSWatcher.Deleted += new System.IO.FileSystemEventHandler(this.FSWatcher_Deleted);
            // 
            // ALMAServiceListenXML
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.FSWatcher)).EndInit();

        }

        #endregion

        private System.IO.FileSystemWatcher FSWatcher;

        /* DEFINE WATCHER EVENTS... */
        /// <summary>
        /// Event occurs when the contents of a File or Directory are changed
        /// </summary>
        private void FSWatcher_Changed(object sender,
                        System.IO.FileSystemEventArgs e)
        {
            //code here for newly changed file or directory
        }
        /// <summary>
        /// Event occurs when the a File or Directory is created
        /// </summary>
        private void FSWatcher_Created(object sender,
                        System.IO.FileSystemEventArgs e)
        {
            //code here for newly created file or directory

            string ruta = new FileInfo(e.FullPath).Directory.FullName;
            string archivo = Path.GetFileName(e.FullPath);
            //string codigo = ConfigurationSettings.AppSettings["Codigo"];
            Archivo.getXML(ruta, archivo);
            
        }
        /// <summary>
        /// Event occurs when the a File or Directory is deleted
        /// </summary>
        private void FSWatcher_Deleted(object sender,
                        System.IO.FileSystemEventArgs e)
        {
            //code here for newly deleted file or directory
        }
        /// <summary>
        /// Event occurs when the a File or Directory is renamed
        /// </summary>
        private void FSWatcher_Renamed(object sender,
                        System.IO.RenamedEventArgs e)
        {
            //code here for newly renamed file or directory
        }
    }
}
