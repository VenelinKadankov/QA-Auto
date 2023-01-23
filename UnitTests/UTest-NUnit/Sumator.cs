namespace UTest_NUnit;

using System.Numerics;

public class Sumator
{
    public static BigInteger Sum(int[] arr)
    {
        BigInteger sum = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    public static double Average(int[] arr)
    {
        double sum = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum / arr.Length;
    }

    public static int MinimumValue(int[] arr)
    {
        var result = int.MaxValue;
        var errorMessage = "Can not find minimum of an empty array!";

        if (arr == null || arr.Length == 0)
        {
            throw new ArgumentNullException(errorMessage);
        }

        foreach (var num in arr)
        {
            if (num < result)
            {
                result = num;
            }
        }

        return result;
    }
}