using System.Text;

namespace MHFCharacterIDConverter
{
    public static class HunterIDHelper
    {
        public static string UIntIDToInGameID(uint Id)
        {
            string base32String = MHFBase32Converter.ToBase32((int)Id);
            string inGameID = Base32StringToInGameID(base32String);
            return inGameID;
        }

        public static uint InGameIDToUIntID(string inGameID)
        {
            string base32String = InGameIDToBase32String(inGameID);
            uint Id = (uint)MHFBase32Converter.FromBase32(base32String);
            return Id;
        }


        static string Base32StringToInGameID(string str)
        {
            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }

            while (result.Length < 6)
            {
                result += "1";
            }
            return result;
        }


        static string InGameIDToBase32String(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
                result = str[i] + result;

            List<char> temp = result.ToList();

            result = "";

            bool bhadfristVal = false;
            for (int i = 0; i < temp.Count; i++)
            {
                if (!bhadfristVal && temp[i] == '1')
                    continue;
                bhadfristVal = true;
                result += temp[i];
            }

            return result;
        }
    }

    public static class MHFBase32Converter
    {
        private const string Base35Chars = "123456789ABCDEFGHJKLMNPQRTUVWXYZ"; // 35个字符，从'1'到'Z'  

        // 整数转换为35进制字符串（自定义的，其中'1'代表0）  
        public static string ToBase32(int number)
        {

            StringBuilder result = new StringBuilder();
            while (number > 0)
            {
                int remainder = number % 32;
                result.Insert(0, Base35Chars[remainder]); // 注意这里不需要减1，因为直接从'1'开始  
                number /= 32;
            }

            // 如果number是0，则添加'1'表示  
            if (result.Length == 0)
            {
                result.Append(Base35Chars[0]);
            }

            return result.ToString();
        }

        // 35进制字符串转换为整数（自定义的，其中'1'代表0）  
        public static int FromBase32(string base32String)
        {
            if (string.IsNullOrWhiteSpace(base32String)) throw new ArgumentNullException(nameof(base32String));

            int result = 0;
            int power = 1;

            for (int i = base32String.Length - 1; i >= 0; i--)
            {
                char currentChar = base32String[i];
                int index = Base35Chars.IndexOf(currentChar);

                if (index == -1)
                {
                    throw new ArgumentException("Invalid character in base32 string.");
                }

                // 如果第一个字符是'1'，则不需要加1，因为'1'代表0  
                result += (i == 0 && currentChar == '1' ? 0 : index) * power;
                power *= 32;
            }

            return result;
        }

    }
}
