using System;
using System.Linq;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    public class CotizacionService
    {
        #region Constructors

        public CotizacionService(string moneda)
        {
            var className = string.Concat(moneda, "CotizacionStrategy");
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var firstDefinedType = assembly.DefinedTypes.FirstOrDefault(x => x.Name.Equals(className, StringComparison.InvariantCultureIgnoreCase));
            if (firstDefinedType == null)
                throw new NotImplementedException();
            var typeFullName = firstDefinedType.FullName;
            if (typeFullName != null)
                Strategy = (ICotizacionStrategy)assembly.CreateInstance(typeFullName);
        }

        #endregion Constructors

        #region Properties

        public ICotizacionStrategy Strategy
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public Task<ValorCotizacion> ObtenerCotizacion()
        {
            return Strategy.ObtenerCotizacion();
        }

        #endregion Methods
    }
}