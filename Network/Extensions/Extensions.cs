namespace Network.Extensions
{
    public static class Extensions
    {
        public static double GetRandomNumber(this double variable, double minimum, double maximum)
        {
            Random random = new Random();
            variable = random.NextDouble() * (maximum - minimum) + minimum;

            return Math.Round(variable, 2, MidpointRounding.AwayFromZero);
        }
    }
}
