namespace Lab0
{
    public class Car
    {
        public decimal Speed { get; set; }
        public bool IsStateMoving { get => Speed > 0; }
        public string Color { get; set; }

        public void PrintState()
        {
            Console.WriteLine(string.IsNullOrWhiteSpace(Color)
                              ? "The car has no color"
                              : "Color is " + Color);

            Console.WriteLine(IsStateMoving
                              ? $"The car is moving at the speed of {Speed} km/h"
                              : "The car is not moving");
        }
    }
}
