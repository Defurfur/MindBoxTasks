using AreaCalculatorLibrary.Abstractions;
using AreaCalculatorLibrary.Models;

namespace AreaCalculatorDemo
{
    public class CalculationWithCheckWorker : BackgroundService
    {
        private readonly ILogger<CalculationWithCheckWorker> _logger;
        private readonly IAreaCalculator _areaCalculator;
        private readonly Random _rand = new();

        public CalculationWithCheckWorker(ILogger<CalculationWithCheckWorker> logger, IAreaCalculator areaCalculator)
        {
            _logger = logger;
            _areaCalculator = areaCalculator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                IShape shape = _rand.NextDouble() switch
                {
                    < 0.5d => new Circle(_rand.Next(40)),
                    _ => new Triangle(_rand.Next(1, 10), _rand.Next(1, 10), _rand.Next(1, 10))
                };

                var result = _areaCalculator.CalculateWithCheck(shape, (shape) => {

                    if(shape is Circle) {
                        return "This is a Circle";
                    } 
                    if(shape is Triangle tr)
                    {
                        if (tr.GetArea() == 0)
                            return $"Triangle with sides A: {tr.A}, B: {tr.B}, C: {tr.C} can't exist";

                        if (tr.isRightAngled())
                            return $"The triangle with sides A: {tr.A}, B: {tr.B}, C: {tr.C} is right-angled";

                        return "The triangle is not right-angled";
                    }

                    return string.Empty;
                });

                _logger.LogInformation(
                    "{shape}. Result area is {result}. {check}",
                    shape.GetType().Name,
                    result.Value,
                    result.Check); 

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}