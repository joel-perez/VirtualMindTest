using System;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        #region Properties

        public string Documentation
        {
            get; set;
        }

        public Type ModelType
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        #endregion Properties
    }
}