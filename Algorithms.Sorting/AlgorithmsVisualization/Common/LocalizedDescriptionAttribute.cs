using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Text;

namespace AlgorithmsVisualization.Common
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private ResourceManager resourceManager;
        private readonly string resourceKey;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            resourceManager = new ResourceManager(resourceType);
            this.resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string description = resourceManager.GetString(resourceKey);
                return string.IsNullOrEmpty(description) ? $"[[{resourceKey}]]" : description;
            }
        }
    }
}
