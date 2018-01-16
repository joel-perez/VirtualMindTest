using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public class ParameterDescription
    {
        #region Constructors

        public ParameterDescription()
        {
            Annotations = new Collection<ParameterAnnotation>();
        }

        #endregion Constructors

        #region Properties

        public Collection<ParameterAnnotation> Annotations
        {
            get; private set;
        }

        public string Documentation
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public ModelDescription TypeDescription
        {
            get; set;
        }

        #endregion Properties
    }
}