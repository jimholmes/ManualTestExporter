using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ManualTestParser
{
    [TestFixture]
    public class When_working_with_valid_json
    { 
        Json_test_parser reader;

        [TestFixtureSetUp]
        public void Run_once_before_anything_else()
        {
            reader = new Json_test_parser(Test_data.Valid_small_json);
        }
        

        [Test]
        public void sets_isValid_true()
        {
            Assert.IsTrue(reader.IsValid);
        }

        [Test]
        public void description_list_is_not_empty()
        {
            Assert.IsTrue(reader.Descriptions.Count > 0);
        }

        [Test]
        public void custom_description_shows_in_descriptions()
        {
            Assert.IsTrue(reader.Descriptions.Contains("bbb"));
        }

        [Test]
        public void custom_description_of_null_doesnt_show_in_descriptions()
        {
            Assert.IsFalse(reader.Descriptions.Contains("null"));
        }       
    }

}