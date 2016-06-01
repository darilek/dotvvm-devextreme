using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.DevExtreme
{
    public static class BasicValidations
    {
        public static void AssertIsNotNull(object param, string paramName)
        {
            if (param == null)
                throw new ArgumentNullException(paramName);
        }

        public static void AssertIsNotNullOrEmpty(string param, string paramName)
        {
            if (String.IsNullOrEmpty(param))
                throw new ArgumentNullException(paramName);
        }
    }
}
