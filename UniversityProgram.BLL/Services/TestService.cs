using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityProgram.BLL.Services
{
    public class TestService : ITestService
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public TestEnum TestEnum { get; set; }
    }


    public interface ITestService
    {
        string Name { get; set; }
        int Age { get; set; }
        TestEnum TestEnum { get; set; }
    }

    public enum TestEnum
    {
        Test1,
        Test2,
        Test3
    }
}
