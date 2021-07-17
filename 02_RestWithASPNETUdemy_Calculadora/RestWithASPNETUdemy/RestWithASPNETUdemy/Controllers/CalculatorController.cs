using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult GetLes(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult GetMult(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);

            return isNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }


    }
}
