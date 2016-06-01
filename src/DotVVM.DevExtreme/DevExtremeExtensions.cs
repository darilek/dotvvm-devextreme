using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Configuration;

namespace DotVVM.DevExtreme
{
    public static class DevExtremeExtensions
    {
        public static void AddDevExtremeConfiguration(this DotvvmConfiguration config)
        {
            string assemblyName = typeof(DevExtremeExtensions).Assembly.GetName().Name;
            config.Markup.Controls.Add(new DotvvmControlConfiguration()
            {
                Assembly = assemblyName,
                Namespace = $"{assemblyName}.{nameof(Controls)}",
                TagPrefix = "dx"
            });
        }
    }
}
