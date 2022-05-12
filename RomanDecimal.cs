using System.Text;
public static class RomanDecimal {

    private static readonly Tuple<int, string>[] letters = { 
        Tuple.Create(1000, "M"), Tuple.Create(900, "CM"), Tuple.Create(500, "D"), 
        Tuple.Create(400, "CD"), Tuple.Create(100, "C"), Tuple.Create(90, "XC"),
        Tuple.Create(50, "L"), Tuple.Create(40, "XL"), Tuple.Create(10, "X"),
        Tuple.Create(9, "IX"), Tuple.Create(5, "V"), Tuple.Create(4, "IV"), 
        Tuple.Create(1, "I")};

    public static int ParseRomanNumeral(this string romanNumber) {
        int total = 0;
        int current = 0;
        int last = int.MaxValue;

        foreach(char rn in romanNumber.ToUpperInvariant()) {
            current = getRomanNumber(rn);
            total += current > last ? current - last - last : current;
            last = current;
        }
        return total;
    }

    public static string ToRomanNumeral(this int romanNumber) {
        int remainder = romanNumber;
        var number = new StringBuilder();
        int i = 0;

        while(i < letters.Length) {
            while(remainder >= letters[i].Item1) {
                remainder -= letters[i].Item1;
                number.Append(letters[i].Item2);
            }
            i++;
        }

        return number.ToString();
    }

    private static int getRomanNumber(char rn) {
        switch(rn) {
            case 'I':
                return 1;
            case 'V':
                return 5;
            case 'X':
                return 10;
            case 'L':
                return 50;
            case 'C':
                return 100;
            case 'D':
                return 500;
            case 'M':
                return 1000;
            default:
                throw new ArgumentException($"{rn} is an unsupported roman numeral", "rn");
        }
    }
}