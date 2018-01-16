using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        #region Constructors

        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        #endregion Constructors

        #region Properties

        public Collection<EnumValueDescription> Values
        {
            get; private set;
        }

        #endregion Properties
    }
}