using System;
using System.Collections.Generic;
using TestStack.White.Bricks;
using TestStack.White.Configuration;

namespace TestStack.White.Reporting.Configuration
{
    public class ReportingAppXmlConfiguration : AssemblyConfiguration, ReportingConfiguration
    {
        private static ReportingConfiguration instance;

        private static readonly Dictionary<string, object> DefaultValues = new Dictionary<string, object>();

        static ReportingAppXmlConfiguration()
        {
            DefaultValues.Add("PublishTestReports", true);
        }

        private ReportingAppXmlConfiguration() : base("White", "Reporting", DefaultValues, 
            CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(ReportingAppXmlConfiguration))) {}

        public static ReportingConfiguration Instance
        {
            get { return instance ?? (instance = new ReportingAppXmlConfiguration()); }
        }

        public virtual bool PublishTestReports
        {
            get { return Convert.ToBoolean(UsedValues["PublishTestReports"]); }
        }
    }
}