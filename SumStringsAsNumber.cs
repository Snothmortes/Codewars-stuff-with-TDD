public static class SumStringsAsNumber
{
  public static string sumStrings(string a, string b) {
    string longestStr = a.Length > b.Length ? a : b;

    char[] str = new char[longestStr.Length];
    char remainder = '0';

    for (int i = longestStr.Length - 1; i >= 0; i--) {

      if (i < Math.Abs(a.Length - b.Length)) {
        str[i] = longestStr[i];
      }
      else {
        int sum = a[i] + b[i] - 0x60;
        str[i] = (char)(sum + 0x30);

        if (remainder == '1') {
          str[i] += '1';
          remainder = '0';
        }

        if (sum >= 10) {
          str[i] = (char)(sum - 10 + 0x30);
          remainder = '1';
        }

        if (i == 0 && remainder == '1') {
          Array.Resize(ref str, str.Length + 1);
          Array.Copy(str, 0, str, 1, str.Length - 1);
          str[i] = '1';
        }
      }
    }

    return new string(str);
  }
}