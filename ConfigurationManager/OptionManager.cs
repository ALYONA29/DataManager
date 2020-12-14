using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationManager
{
    public class OptionManager
    {
        string jsonPath;
        string xmlPath;
        public OptionManager(string jsonPath, string xmlPath)
        {
            this.jsonPath = jsonPath;
            this.xmlPath = xmlPath;
        }
        public T GetOptions<T>() where T : new()
        {
            T options;
            try
            {
                using (StreamReader sr = new StreamReader(jsonPath))
                {
                    string json = sr.ReadToEnd();
                    options = ParserJson.Parser.DeserializeJson<T>(json);
                    return options;
                }
            }
            catch
            {
            }
            try
            {
                using (StreamReader sr = new StreamReader(xmlPath))
                {
                    string xml = sr.ReadToEnd();
                    options = ParserXml.Parser.DeserializeXml<T>(xml);
                    return options;
                }
            }
            catch
            {
            }
            options = new T();
            return options;
        }
    }
}
