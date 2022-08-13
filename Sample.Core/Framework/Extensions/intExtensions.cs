namespace Sample.Core.Framework
{
    public partial class Extensions
    {
        public static bool IsPositive(this int number)
            =>  number > 0;

        public static bool IsNegative(this int number)
            =>  number < 0;

        public static bool IsZero(this int number)
            =>  number == 0;
    }
}