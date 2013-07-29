using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ManualTestParser
{
    [TestFixture]
    class When_writing_excel_output
    {
        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        public void invalid_path_throws_exception()
        {
            IList<string>descrs = new List<string>();
            descrs.Add("Foo");
            Excel_writer writer = new Excel_writer(descrs, Test_data.invalid_file);
        }

        
                
    }
}