namespace trss_lab1;

public class Program
{
    public static void Main()
    {
        try
        {
            double x = 3.14;
            double epsilon = 1e-6;
            double result = Maclaurin.Cotangent(x, epsilon);

            Console.WriteLine($"Result of Maclaurin series for cot({x}) with precision {epsilon}: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
