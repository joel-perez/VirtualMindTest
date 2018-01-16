using System;
using System.Reflection;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        #region Methods

        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);

        #endregion Methods
    }
}