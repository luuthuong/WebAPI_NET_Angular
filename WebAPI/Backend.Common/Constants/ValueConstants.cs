using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Common.Constants
{
    public class ValueConstants
    {
        public const string SecretKey = "Secret4EE56A8E-2603-4399-8974-84BE98ADC994";
        public static Guid AdministratorId = Guid.Parse("95a16d58-df64-485a-aed5-4461d900faf2");
        public static Guid ReaderId = Guid.Parse("1001f806-66c7-4ca3-a6a9-b46cc0b5ff10");
        public static int WebsiteTimeOut = 15000;

        public static Guid ProductCategoryMediaId = Guid.Parse("9ee33d41-b087-492c-a128-bbbff72f413f");
        public static Guid BlogCategoryMediaId = Guid.Parse("957cc1d6-ddd2-4c95-b96d-62707863400e");
        public static Guid ProfileCategoryMediaId = Guid.Parse("79b1830a-f9c5-41b6-a59c-a58b95bff365");
    }
}
