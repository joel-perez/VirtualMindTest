using System;

namespace MyRestfullApp.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Use this attribute to change the name of the <see cref="ModelDescription"/> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        #region Constructors

        public ModelNameAttribute(string name)
        {
            Name = name;
        }

        #endregion Constructors

        #region Properties

        public string Name
        {
            get; private set;
        }

        #endregion Properties
    }
}