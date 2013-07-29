using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ManualTestParser
{
    public class Json_test_parser
    {
        private JObject test;
        private bool isValid;
        private IList<string> descriptions;

        public IList<string> Descriptions
        {
            get { return descriptions; }
        }

        public bool IsValid
        {
            get { return isValid; }
        }

        public Json_test_parser(string test_json)
        {
            isValid = false;
            test = new JObject();
            descriptions = new List<string>();

            try
            {
                test = JObject.Parse(test_json);
            }
            catch (Newtonsoft.Json.JsonReaderException error)
            {
                throw new ArgumentException("Error parsing input data. Are you sure you're using a JSON format file?");
            }

            ValidateTestType();
            if (isValid)
            {
                LoadDescriptions();                
            }
            
        }

        private void LoadDescriptions()
        {
            var data =
                      from p in test["__value"]["Steps"]["__value"].Children()["__value"]
                      select new { Description = p["Description"], Custom = p["CustomDescription"] };
            foreach (var item in data)
            {
                descriptions.Add(item.Description.ToString());
                if (item.Custom != null)
                {
                    descriptions.Add(item.Custom.ToString());
                }
            }
        }

        private void ValidateTestType()
        {
            if (test["__type"].ToString().Equals("ArtOfTest.WebAii.Design.ProjectModel.Test") &&
                test["__value"]["IsManual"].ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
            }
        }

        
    }
}   
