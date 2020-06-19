using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Response entry for currencies dictionary
    /// </summary>
    public class CurreciesResponse
    {
        /// <summary>
        /// Currency code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Currency Id
        /// </summary>
        public int  Id { get; set; }
    }
}
