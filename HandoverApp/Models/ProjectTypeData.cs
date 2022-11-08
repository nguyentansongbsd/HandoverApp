using System;
using System.Collections.Generic;
using System.Linq;
using HandoverApp.Resources;

namespace HandoverApp.Models
{
    public class ProjectTypeData
    {
        public static OptionSet GetProjectType(string projectType)
        {
            return ProjectTypes().SingleOrDefault(x => x.Val == projectType);
        }
        public static List<OptionSet> ProjectTypes()
        {
            return new List<OptionSet>()
            {
                new OptionSet("false",Language.nha_o),
                new OptionSet("true",Language.thuong_mai),
            };
        }
    }
}
