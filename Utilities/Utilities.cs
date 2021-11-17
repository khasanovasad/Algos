namespace Utilities
{
    public static class Utils
    {
        public static void Swap<T>(ref T first, ref T second)
        {
            (first, second) = (second, first);
        }
    }
}