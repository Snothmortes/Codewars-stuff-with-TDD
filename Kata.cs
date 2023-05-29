public static class Kata
{
  public static string sumStrings(string a, string b) {
    string longestStr = a.Length >= b.Length ? a : b;
    string shortestStr = b.Length <= a.Length ? b : a;

    char[] str = new char[longestStr.Length];
    char remainder = '0';
    int diff = longestStr.Length - shortestStr.Length;

    for (int i = longestStr.Length - 1; i >= 0; i--) {
      int j = i - diff;

      if (j < 0) {
        str[i] = longestStr[i];

        if (remainder == '1') {
          str[i] += (char)1;
          remainder = '0';
        }
      }
      else {
        int sum = longestStr[i] + shortestStr[j] - 0x60;
        str[i] += (char)sum;

        if (remainder == '1') {
          str[i] += (char)1;
          remainder = '0';
        }

        if (sum >= 10) {
          str[i] -= (char)0xA; // -0xA
          remainder = '1';
        }

        str[i] += '0'; // +0x30

        if (i == 0) {
          if (remainder == '1') {
            Array.Resize(ref str, str.Length + 1);
            Array.Copy(str, 0, str, 1, str.Length - 1);
            str[i] = '\0';
            str[i] += '1';
          }
        }
      }
    }

    return new string(str);
  }
}