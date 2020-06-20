﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculation.Application.ApplicationModel
{
    /// <summary>
    /// Object representing calculation request
    /// </summary>
    public class CalculationRequest
    {
        /// <summary>
        /// Collection of items for tax calculation
        /// </summary>
        public IEnumerable<CalculationRequestEntry> Data { get; set; }
    }
}
