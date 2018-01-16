using System.Collections.ObjectModel;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public class ComplexTypeModelDescription : ModelDescription
    {
        #region Constructors

        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        #endregion Constructors

        #region Properties

        public Collection<ParameterDescription> Properties
        {
            get; private set;
        }

        #endregion Properties
    }
}