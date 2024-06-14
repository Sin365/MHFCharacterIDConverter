namespace MHFCharacterIDConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Test
            for (uint i = 1; i < 1300u; i++)
            {
                string InGameID = HunterIDHelper.UIntIDToInGameID(i);
                uint reConvID = HunterIDHelper.InGameIDToUIntID(InGameID);
                Console.WriteLine($"srcCharID:  {i}   | InGameID:   {InGameID}  |   reConvID:   {reConvID}");
            }
            Console.ReadLine();
        }
    }
}
