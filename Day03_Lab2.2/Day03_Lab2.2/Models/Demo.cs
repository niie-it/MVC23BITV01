namespace Day03_Lab2._2.Models
{
    public class Demo
    {
        public static int A()
        {
            Thread.Sleep(2000);
            return new Random().Next(1, 100);
        }

        public static string B()
        {
            Thread.Sleep(5000);
            return "Hello, World!";
        }

        public static void C()
        {
            Thread.Sleep(3000);
        }

        public async static Task<int> AA()
        {
            await Task.Delay(2000);
            return new Random().Next(1, 100);
        }

        public async static Task<string> BB()
        {
            await Task.Delay(5000);
            return "Hello, World!";
        }

        public async static Task CC()
        {
            await Task.Delay(3000);
        }
    }
}
