using System;
using System.Threading.Tasks;

using MyRestfullApp.Models;

namespace MyRestfullApp.Services.Cotizacion
{
    /// <summary>
    /// Servicio de cotizacion. Selecciona la estrategia segun la moneda (Dolar, Pesos, Real)
    /// y delega en ella la obtencion del valor de la cotizacion.
    /// </summary>
    public class CotizacionService
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia del servicio configurando la estrategia
        /// que corresponde a la moneda indicada.
        /// </summary>
        /// <param name="moneda">Moneda solicitada: "Dolar", "Pesos" o "Real" (no distingue mayusculas/minusculas).</param>
        /// <exception cref="NotImplementedException">Si la moneda indicada no es ninguna de las soportadas.</exception>
        public CotizacionService(string moneda)
        {
            Strategy = CrearEstrategia(moneda);
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Estrategia seleccionada para obtener la cotizacion de la moneda configurada.
        /// </summary>
        /// <value>Instancia de <see cref="ICotizacionStrategy"/> que se encargara de obtener la cotizacion.</value>
        public ICotizacionStrategy Strategy
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Obtiene el valor de la cotizacion actual delegando en la estrategia seleccionada.
        /// </summary>
        /// <returns>Una tarea que, al completarse, devuelve la <see cref="ValorCotizacion"/> con los importes de compra y venta.</returns>
        /// <exception cref="UnauthorizedAccessException">Si la estrategia no esta autorizada para la moneda solicitada (Pesos, Real).</exception>
        public Task<ValorCotizacion> ObtenerCotizacion()
        {
            return Strategy.ObtenerCotizacion();
        }

        /// <summary>
        /// Crea la estrategia de cotizacion que corresponde a la moneda indicada.
        /// </summary>
        /// <param name="moneda">Nombre de la moneda: "Dolar", "Pesos" o "Real" (no distingue mayusculas/minusculas).</param>
        /// <returns>La estrategia concreta capaz de cotizar la moneda solicitada.</returns>
        /// <exception cref="NotImplementedException">Si la moneda no es soportada por ninguna estrategia.</exception>
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
