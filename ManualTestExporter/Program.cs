using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ManualTestExporter
{
    class Program
    {
        
       
        static void Main(string[] args)
        {
            Program me = new Program();
            me.parse();
           
        }

        private void parse()
        {
            JObject test = JObject.Parse(File.ReadAllText(@"D:\projects\Telerik-Demo\test\TestStudio\New Contact\Visually validate New Contact form.tstest"));
            string indented = JsonConvert.SerializeObject(test, Formatting.Indented);
            indented.ToString();
        }
    }
}
