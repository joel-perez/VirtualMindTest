using System;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public class ParameterAnnotation
    {
        #region Properties

        public Attribute AnnotationAttribute
        {
            get; set;
        }

        public string Documentation
        {
            get; set;
        }

        #endregion Properties
    }
}