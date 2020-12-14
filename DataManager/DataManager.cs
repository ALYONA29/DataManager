using ConfigurationManager;
using ServiceLayer.DTO;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataManager
{
    public class DataManager
    {
        OptionManager optionManager;
        DataManagerOptions dataOptions;
        string connectionString;
        public DataManager(string xml, string json)
        {
            optionManager = new OptionManager(json, xml);
            dataOptions = new DataManagerOptions();
            dataOptions = optionManager.GetOptions<DataManagerOptions>();
            connectionString = $"Data Source={dataOptions.DataSource};" +
                $"Initial Catalog={dataOptions.InitialCatalog};" +
                $"Integrated Security={dataOptions.IntegratedSecurity}";
        }

        public void GetInformation()
        {
            OrderService orderService = new OrderService();
            List<RequiredInformation> information = new List<RequiredInformation>();
            information = orderService.GetInformation(connectionString);
            XmlGenerator xmlGenerator = new XmlGenerator();
            xmlGenerator.CreateXml(information);
            FileTransfer fileTransfer = new FileTransfer();
            fileTransfer.SendFile(dataOptions);
        }
    }
}
