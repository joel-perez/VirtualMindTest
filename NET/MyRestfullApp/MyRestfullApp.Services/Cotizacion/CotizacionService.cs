using System;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Servicio de cotizacion. Selecciona la estrategia segun la moneda (Dolar, Pesos, Real).
    /// </summary>
    public class CotizacionService
    {
        #region Constructors

        public CotizacionService(string moneda)
        {
            Strategy = CrearEstrategia(moneda);
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

        private static ICotizacionStrategy CrearEstrategia(string moneda)
        {
            if (string.Equals(moneda, "Dolar", StringComparison.OrdinalIgnoreCase))
                return new DolarCotizacionStrategy();
            if (string.Equals(moneda, "Pesos", StringComparison.OrdinalIgnoreCase))
                return new PesosCotizacionStrategy();
            if (string.Equals(moneda, "Real", StringComparison.OrdinalIgnoreCase))
                return new RealCotizacionStrategy();

            throw new NotImplementedException();
        }

        #endregion Methods
    }
}
