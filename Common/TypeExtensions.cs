using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class TypeExtensions
    {
        public static bool IsOpenGenericType(this Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementInterface in type.FindInterfaces((objType,objCriterial)=>true,null))
                {
                    if (implementInterface.IsGenericType)
                        continue;
                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
