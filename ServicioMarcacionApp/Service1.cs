using ServicioMarcacionApp.Utilitarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMarcacionApp
{
    public partial class Service1 : ServiceBase
    {
        
        public Service1()
        {
            InitializeComponent();
        }
        Process p;
        Process myCSharpProcess;
        protected override void OnStart(string[] args)
        {
            try
            {
                /*Funcionando Inicio*/
                /* p = new Process();
                 AppConfigSettings app = new AppConfigSettings();

                 string targetDir;

                 targetDir = string.Format(@"" + app.GetAppSettings("rutaArchivoServicio"));   //directory where the batch script is saved.

                 p.StartInfo.UseShellExecute = true;
                 //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                 p.StartInfo.WorkingDirectory = targetDir;
                 p.StartInfo.FileName = app.GetAppSettings("nombreArchivoServicio");          //this is the batch script that needs to run.
                 p.StartInfo.CreateNoWindow = false;
                 p.Start();
           */
                //p.WaitForExit();
                /*Funcionando Fin*/
                AppConfigSettings app = new AppConfigSettings();
                myCSharpProcess = new Process();
                myCSharpProcess.StartInfo.FileName = "java.exe";
                myCSharpProcess.StartInfo.Arguments = "-jar "+ app.GetAppSettings("rutaArchivoServicio")+"\\"+ app.GetAppSettings("nombreArchivoServicio")+"";
                myCSharpProcess.StartInfo.CreateNoWindow = false;
                //myProcess.StartInfo.CreateNoWindow = true;
                myCSharpProcess.Start();
                EscribeVisorEventos("Se inició con éxito el Servicio MarcacionApp", null, 1);


            }
            catch (Exception ex)
            {
                EscribeVisorEventos("Error al iniciar el Servicio MarcacionApp", ex, 2);
                OnStop();
            }


        }

        protected override void OnStop()
        {
            try
            {
                myCSharpProcess.Kill();
                EscribeVisorEventos("Se cierra con éxito el Servicio MarcacionApp", null, 1);
            }
            catch (Exception ex)
            {
                EscribeVisorEventos("Error al cerrar el Servicio MarcacionApp", ex, 2);
            }
        }

        private void EscribeVisorEventos(string procedencia, Exception ex, int tipo)
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists("Servicio MarcacionApp"))
                    System.Diagnostics.EventLog.CreateEventSource("Servicio MarcacionApp", "Application");
                else
                {
                    if (tipo == 1)
                    {
                        System.Diagnostics.EventLog.WriteEntry("Servicio MarcacionApp", "" + procedencia + ". ",
                             System.Diagnostics.EventLogEntryType.Information, 20, 10);
                    }
                    else
                    {
                        System.Diagnostics.EventLog.WriteEntry("Servicio MarcacionApp", "" + procedencia + ". " + ex.Message,
                            System.Diagnostics.EventLogEntryType.Error, 20, 10);
                    }

                }
            }
            catch (Exception e)
            {
                
            }
        }
    }
}
