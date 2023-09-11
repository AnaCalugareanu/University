using Lab0;

Car car = new Car();

Console.WriteLine("Hi, give me the color that you have in mind for the car: ");
car.Color = Console.ReadLine();

Console.WriteLine("What is the speed that the car is traveling at:  ");
car.Speed = Convert.ToDecimal(Console.ReadLine());

car.PrintState();