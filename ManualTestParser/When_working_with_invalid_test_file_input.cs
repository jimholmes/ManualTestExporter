using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ManualTestParser
{
    [TestFixture]
    public class When_working_with_invalid_test_file_input
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void xml_input_throws_exception()
        {
            Json_test_parser reader = new Json_test_parser(Test_data.xml_test_snippet);
        }

        [Test]
        public void invalid_json_type_sets_isValid_false()
        {
            Json_test_parser reader = new Json_test_parser(Test_data.Invalid_type_small_json);
            Assert.IsFalse(reader.IsValid);
        }
    }
}
