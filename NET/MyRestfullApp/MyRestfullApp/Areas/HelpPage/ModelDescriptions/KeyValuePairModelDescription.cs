namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public class KeyValuePairModelDescription : ModelDescription
    {
        #region Properties

        public ModelDescription KeyModelDescription
        {
            get; set;
        }

        public ModelDescription ValueModelDescription
        {
            get; set;
        }

        #endregion Properties
    }
}