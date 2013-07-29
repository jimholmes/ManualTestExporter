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
        private IList<Step> descriptions;

        public IList<Step> Descriptions
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
            descriptions = new List<Step>();

            try
            {
                test = JObject.Parse(test_json);
            }
            catch (Newtonsoft.Json.JsonReaderException error)
            {
                throw new ArgumentException("Error parsing input data. Are you sure you're using a JSON format file?");
            }

            validiate_test_type();
            if (isValid)
            {
                load_descriptions();                
            }
            
        }

        private void load_descriptions()
        {
            var data =
                      from p in test["__value"]["Steps"]["__value"].Children()["__value"]
                      select new { Description = p["Description"], Custom = p["CustomDescription"] };
            foreach (var item in data)
            {
                Step step = new Step();
                string listDescr = item.Description.ToString();
                if (listDescr != null)
                {
                    step.Description = listDescr;
                }
                if (item.Custom != null)
                {
                    step.Custom = item.Custom.ToString();
                }
                descriptions.Add(step);
            }
        }   

        private void validiate_test_type()
        {
            if (test["__type"].ToString().Equals("ArtOfTest.WebAii.Design.ProjectModel.Test") &&
                test["__value"]["IsManual"].ToString().Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
            }
        }   
    }

    public class Step
    {
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private string custom;

        public string Custom
        {
            get { return custom; }
            set { custom = value; }
        }
    }
}   
