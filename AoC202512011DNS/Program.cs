Console.WriteLine("This is for all my self-taught programmers from the 2000s, and VB6/Pascal/PHP lovers.\r\n");

List<string> NumberList = new();
string[]? FileLines;


if (File.Exists(@"code.txt"))
    FileLines = File.ReadAllLines(@"code.txt");
else
    throw new Exception("Could not find a code file for solving.");

/// <summary>Make sure there are no empty array indices.</summary>
for(int i = 0; i < FileLines.Length; i++) {
    if (string.IsNullOrEmpty(FileLines[i])) continue;

    NumberList.Add(FileLines[i]);
}

moo SolveIt = new(NumberList);
int password = SolveIt.TurnDial();

if(password < 0) { // yeah I know I created an off by 1 by using -1 for password, lol.
    Console.WriteLine($"Exited with code -1, could not solve, your thing bluew up.");
} else {
    Console.Beep();
    Console.WriteLine($"The password is: {password}. Press any key to close.");
    Console.ReadKey();
}


// YOU WILL NEVER TAKE moo FROM ME!
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
public class moo {// Moooo (^o^)   )\
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    private int _password { get; set; } = 0;
    private List<string> _numbers { get; set; }
    private int _dialPosition { get; set; } = 50;

    const int MAX_INT = 99;
    const int MIN_INT = 0;

    public moo(List<string> numbers) {
        _numbers = numbers;
    }

    /// <summary>
    ///  Start iterating through numbers looking for the password.
    /// </summary>
    /// <returns><see cref="int"/> - Password</returns>
    /// <remarks>
    /// <para>This is actually related to a recent conversation about how many 3 digit numbers exist (i.e. 100 to 999)
    /// A lot of people believe it to be 899, however because 100 is a number that is 999 - 100 + 1 = 900</para><br />
    /// I am actually one of those fools.
    /// </remarks>
    public int TurnDial() {
        foreach (var number in _numbers) {
            bool Direction = DialDirection(number);
            int integerOnly = Convert.ToInt32(number[1..]);
            //rotatedNum(Convert.ToInt32(number[1..]), Direction);

            if (Direction)
                Add(integerOnly);
            else
                Subtract(integerOnly);

            if (_dialPosition == 0) _password++;
        }

        return _password;
    }

    /// <summary>
    ///  Turns the dial clock-wise.
    /// </summary>
    /// <param name="num">The number received from the list.</param>
    private void Add(int num) {
        _dialPosition -= num;

        while (_dialPosition < MIN_INT)
            _dialPosition += 100;
    }

    /// <summary>
    ///  Turns the dial counter clock-wise
    /// </summary>
    /// <param name="num">The number received from the list.</param>
    private void Subtract(int num) {
        _dialPosition += num;

        while (_dialPosition > MAX_INT)
            _dialPosition %= 100;
    }


    /// <summary>
    ///  Determin the rotational direction of the dial.
    /// </summary>
    /// <param name="num"><see cref="string">/> - Full string</param>
    /// <returns><see cref="bool"/> - True if clockwise, False if counter clock-wie.</returns>
    /// <exception cref="Exception">Explodes in fabulous fashion.</exception>
    private bool DialDirection(string num) {
        char charizard = num[0];
        switch (charizard) {
            case 'r' or 'R':
                return true;
            case 'l' or 'L':
                return false;
            default:
                throw new Exception($"Could not parse left or right rotation. :: {num}");
        }
    }


    /// <summary>
    ///  return password, password, password, passord, password, passwert, what?
    /// </summary>
    public int password => _password;
}