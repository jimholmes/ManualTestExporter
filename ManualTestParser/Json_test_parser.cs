using System;
using System.Collections.Generic;
using System.IO;
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

        public Json_test_parser(FileInfo jsonFile)
        {
            barf_if_file_is_not_present(jsonFile);
            add_filename_to_first_descriptions_item(jsonFile);
            string test_json = read_json_file(jsonFile);
            parse_json_string(test_json);
        }

        private static string read_json_file(FileInfo jsonFile)
        {
            StreamReader reader = new StreamReader(jsonFile.FullName);
            string test_json = reader.ReadToEnd();
            return test_json;
        }

        private void add_filename_to_first_descriptions_item(FileInfo jsonFile)
        {
            Step title = new Step();
            title.Description = jsonFile.FullName;
            descriptions.Add(title);
        }

        private static void barf_if_file_is_not_present(FileInfo jsonFile)
        {
            if (!jsonFile.Exists)
            {
                throw new FileNotFoundException("File doesn't exist! " + jsonFile.FullName);
            }
        }
        public Json_test_parser(string test_json)
        {
            parse_json_string(test_json);
        }
        private void parse_json_string(string test_json)
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
            if (test["__type"].ToString().
                Equals("ArtOfTest.WebAii.Design.ProjectModel.Test") 
                &&
                test["__value"]["IsManual"].ToString().
                Equals("true", StringComparison.CurrentCultureIgnoreCase))
            {
                isValid = true;
            }
        }   
    }
}
