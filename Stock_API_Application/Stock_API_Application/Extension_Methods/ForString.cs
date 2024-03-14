using System.Text;

namespace Stock_API_Application.Extension_Methods
{
    public static class ForString
    {
        public static String FormatQueryForLikeOperator(this String pattern)
        {
            String[] patterns = pattern.Split("-");
            StringBuilder sb = new StringBuilder("");
            sb.Append(patterns[0] +"%");
            for(int i = 1; i < patterns.Length; i++) {
                sb.Append(" or name like " + patterns[i]+"%");
            }
            return sb.ToString();
        }
    }
}
