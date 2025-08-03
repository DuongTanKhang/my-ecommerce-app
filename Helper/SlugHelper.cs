using System.Text.RegularExpressions;
using System.Globalization;
using System.Text;

namespace ECommerceBackend.Helper
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            // 1. Chuyển về lowercase
            string str = phrase.ToLowerInvariant();

            // 2. Loại bỏ dấu tiếng Việt
            str = RemoveDiacritics(str);

            // 3. Xóa ký tự đặc biệt, giữ lại chữ cái, số và khoảng trắng
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");

            // 4. Thay khoảng trắng bằng dấu gạch ngang
            str = Regex.Replace(str, @"\s+", "-").Trim('-');

            return str;
        }
        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
