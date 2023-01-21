namespace UTest_NUnit;

public class Sumator
{
    public int Sum(int[] arr)
    {
        int sum = arr[0];
        for (int i = 1; i < arr.Length; i++)
            sum += arr[i];

        return sum;
    }

    public double Average(int[] arr)
    {
        double sum = arr[0];
        for (int i = 1; i < arr.Length; i++)
            sum += arr[i];

        return sum / arr.Length;
    }

    //public void Test_SumTwoNumbers()
    //{
    //    if (Sum(new int[] { 1, 2 }) != 3)
    //        throw new Exception("1+2 != 3");
    //}

    //public void Test_SumEmptyArray()
    //{
    //    if (Sum(new int[] { }) != 0)
    //        throw new Exception("sum [] != 0");
    //}
}