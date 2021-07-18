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

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult GetSum(string firstNumber, string secondNumber)
        {
            if(isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult GetSubtraction(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult GetDivision(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult GetMultiplication(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult GetMean(string firstNumber, string secondNumber)
        {
            if (isNumeric(firstNumber) && isNumeric(secondNumber))
            {
                var value = ((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);
                return Ok(value.ToString());
            }

            return BadRequest("Invalid Imput");
        }

        [HttpGet("square/{firstNumber}")]
        public IActionResult GetSquareRoot(string firstNumber)
        {
            if (isNumeric(firstNumber))
            {
                var value = Math.Sqrt((double)ConvertToDecimal(firstNumber));
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
