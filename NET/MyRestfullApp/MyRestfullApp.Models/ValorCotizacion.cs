namespace MyRestfullApp.Models
{
    /// <summary>
    /// Modelo de transferencia de datos que representa los valores de una cotizacion de moneda
    /// (precio de compra y de venta) devuelto por el endpoint de cotizaciones.
    /// </summary>
    public class ValorCotizacion
    {
        #region Properties

        /// <summary>
        /// Precio al que la entidad compra la moneda.
        /// </summary>
        /// <value>Importe numerico expresado en la moneda de la cotizacion.</value>
        public double Compra
        {
            get; set;
        }

        /// <summary>
        /// Precio al que la entidad vende la moneda.
        /// </summary>
        /// <value>Importe numerico expresado en la moneda de la cotizacion.</value>
        public double Venta
        {
            get; set;
        }

        #endregion Properties
    }
}
