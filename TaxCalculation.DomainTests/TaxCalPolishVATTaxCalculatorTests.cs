using System;
using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using TaxCalculation.Domain;
using TaxCalculation.Domain.Models;
using TaxCalculation.Domain.TaxCalculator;

namespace TaxCalculation.DomainTests
{
    [TestOf(typeof(PolishVATTaxCalculator))]
    [TestFixture]
    public class TaxCalPolishVATTaxCalculatorTests
    {
        private IPolishVATTaxCalculator _taxCalculator;

        [OneTimeSetUp]
        public void Setup()
        {
            _taxCalculator = new PolishVATTaxCalculator();
        }

        [TestCase(10, 2.3, TestName = "TaxForBaseRate_Return_CorrectTaxCalculation_When_IntegerValue")]
        [TestCase(12.33, 2.84, TestName = "TaxForBaseRate_Return_CorrectTaxCalculation_When_RealValue")]
        [TestCase(0.02, 0, TestName = "TaxForBaseRate_Return_0_When_ValueIsSmall")]
        [TestCase(0.0, 0, TestName = "TaxForBaseRate_Return_0_When_ValueIs0")]
        public void BaseRateTests(decimal inputValue, decimal taxValue)
        {
            //Arrange
            var input = inputValue;
            var expected = new PriceWithTaxes(input, taxValue, input+taxValue);

            //Act
            var result =  _taxCalculator.VATTaxBaseRate(input);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestCase(10, 0, TestName = "VATTax0Rate_Return_CorrectTaxCalculation_When_IntegerValue")]
        [TestCase(12.33, 0, TestName = "VATTax0Rate_Return_CorrectTaxCalculation_When_RealValue")]
        [TestCase(0.02, 0, TestName = "VATTax0Rate_Return_0_When_ValueIsSmall")]
        [TestCase(0.0, 0, TestName = "VATTax0Rate_Return_0_When_ValueIs0")]
        public void Tax0RateTests(decimal inputValue, decimal taxValue)
        {
            //Arrange
            var input = inputValue;
            var expected = new PriceWithTaxes(input, taxValue, input + taxValue);

            //Act
            var result = _taxCalculator.VATTax0Rate(input);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestCase(10, 0.5, TestName = "VATTax5Rate_Return_CorrectTaxCalculation_When_IntegerValue")]
        [TestCase(12.33, 0.62, TestName = "VATTax5Rate_Return_CorrectTaxCalculation_When_RealValue")]
        [TestCase(0.09, 0, TestName = "VATTax5Rate_Return_0_When_ValueIsSmall")]
        [TestCase(0.0, 0, TestName = "VATTax5Rate_Return_0_When_ValueIs0")]
        public void Tax5RateTests(decimal inputValue, decimal taxValue)
        {
            //Arrange
            var input = inputValue;
            var expected = new PriceWithTaxes(input, taxValue, input + taxValue);

            //Act
            var result = _taxCalculator.VATTax5Rate(input);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestCase(10, 0.8, TestName = "VATTax8Rate_Return_CorrectTaxCalculation_When_IntegerValue")]
        [TestCase(12.33, 0.99, TestName = "VATTax8Rate_Return_CorrectTaxCalculation_When_RealValue")]
        [TestCase(0.06, 0, TestName = "VATTax8Rate_Return_0_When_ValueIsSmall")]
        [TestCase(0.0, 0, TestName = "VATTax8Rate_Return_0_When_ValueIs0")]
        public void Tax8RateTests(decimal inputValue, decimal taxValue)
        {
            //Arrange
            var input = inputValue;
            var expected = new PriceWithTaxes(input, taxValue, input + taxValue);

            //Act
            var result = _taxCalculator.VATTax8Rate(input);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
