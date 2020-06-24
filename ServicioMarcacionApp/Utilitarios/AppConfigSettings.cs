using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioMarcacionApp.Utilitarios
{
    public class AppConfigSettings
    {
        Configuration config;

        public AppConfigSettings()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public string GetConnectionString(string key)
        {
            return config.ConnectionStrings.ConnectionStrings[key].ConnectionString;
        }

        public void SaveConnectionString(string key, string value)
        {
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            //if (section.SectionInformation.IsProtected)
            //{
            //    section.ConnectionStrings[key].ConnectionString = "metadata=res://*/Entidades.DatosModelo.csdl|res://*/Entidades.DatosModelo.ssdl|res://*/Entidades.DatosModelo.msl;provider=System.Data.SqlClient;provider connection string=\"" + value + "\"";
            //}
            //else
            //{
            section.ConnectionStrings[key].ConnectionString = "metadata=res://*/Entidades.TramaDB.csdl|res://*/Entidades.TramaDB.ssdl|res://*/Entidades.TramaDB.msl;provider=System.Data.SqlClient;provider connection string=\"" + value + "\"";
            //    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //}
            config.Save();
        }

        public void SaveAppSettings(string key, string value)
        {
            AppSettingsSection section = config.GetSection("appSettings") as AppSettingsSection;

            //if (section.SectionInformation.IsProtected)
            //{
            //    config.AppSettings.Settings[key].Value = value;
            //}
            //else
            //{
            config.AppSettings.Settings[key].Value = value;
            //    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            //}
            config.Save();
        }

        public string GetAppSettings(string key)
        {
            string value = "";
            try
            {
                value = config.AppSettings.Settings[key].Value;
            }
            catch (Exception)
            {

            }
            return value;
        }
    }
}
