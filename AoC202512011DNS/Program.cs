Console.WriteLine("This is for all my self-taught programmers from the 2000s, and VB6/Pascal/PHP lovers.\r\n");

List<string> NumberList = new();
string[]? FileLines;
string fileName = @"codes.txt";

if (File.Exists(fileName))
    FileLines = File.ReadAllLines(fileName);
else
    throw new Exception("Could not find a code file for solving.");

/// <summary>Make sure there are no empty array indices.</summary>
for(int i = 0; i < FileLines.Length; i++) {
    if (string.IsNullOrEmpty(FileLines[i])) continue;

    NumberList.Add(FileLines[i]);
}

moo SolveIt = new(NumberList);
int password = SolveIt.TurnDial(1);

if(password < 0) { // yeah I know I created an off by 1 by using -1 for password, lol.
    Console.WriteLine($"Exited with code -1, could not solve, your thing bluew up.");
} else {
    Console.Beep();
    Console.WriteLine($"The password is: {password}. Press any key to continue.");
}

Console.ReadKey();

password = SolveIt.TurnDial(2);

Console.Beep();
Console.WriteLine($"The password is: {password}. Press any key to continue.");


Console.ReadKey();

// YOU WILL NEVER TAKE moo FROM ME!
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
public class moo {// Moooo (^o^)   )\
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.

    private int _password { get; set; } = 0;
    private int _dialPosition { get; set; } = 50;
    private List<string> _numbers { get; set; }
    private bool _DONOTCOUNT { get; set; } = false;

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
    public int TurnDial(int stage = 1) {
        _password = 0;
        _dialPosition = 50;

        Console.WriteLine($"The dial starts by pointing at {_dialPosition}.");

        foreach (var number in _numbers) {
            bool Direction = DialDirection(number);
            int integerOnly = Convert.ToInt32(number[1..]);
            //bool Counted = false;

            //if (stage != 1 && _dialPosition == 0) _DONOTCOUNT = true;

            if (Direction)
                if (stage == 1) { Add(integerOnly); } else { brutus_forcus(integerOnly, Direction); /*Counted = AddDivision(integerOnly);*/ }
            else
                if (stage == 1) { Subtract(integerOnly); } else { brutus_forcus(integerOnly, Direction); /*Counted = SubtractDivision(integerOnly);*/ }

            if (_dialPosition == 0) { Console.WriteLine($"---password stepped :: outside :: {integerOnly}"); _password++; }

            //Console.WriteLine($"The dial is rotated {number} to point at {_dialPosition}");
        }

        return _password;
    }


    private void brutus_forcus(int num, bool direction) {
        for (int i = 0; i < num; i++) {
            if(direction) { // clockwise
                _dialPosition++;
                if(_dialPosition > 99) _dialPosition = MIN_INT;
            } else { //counter intuivie piece of I swear I'm not frustrated.
                _dialPosition--;
                if (_dialPosition < 0) _dialPosition = MAX_INT;
            }

            if (_dialPosition == 0)
                _password++;
        }
    }


    /// <summary>
    ///  Turns the dial clock-wise.
    /// </summary>
    /// <param name="num">The number received from the list.</param>
    private void Add(int num) {
        _dialPosition += num;

        while (_dialPosition > MAX_INT)
            _dialPosition %= 100;
    }


    [Obsolete]
    private bool AddDivision(int num) {
        _dialPosition += num; //-789
        bool callback = false;

        if (_dialPosition > MAX_INT) {
            int _tmp = (int)Math.Floor(Convert.ToDecimal((_dialPosition / 100)));
            callback = true;
            for (int i = 0; i < _tmp; i++) {
                if (_DONOTCOUNT) { _DONOTCOUNT = false;  continue; }
                Console.WriteLine($"-pass++ :: Add :: {num}");
                _password++;
            }
        }

        while (_dialPosition > MAX_INT)
            _dialPosition %= 100;

        if (_DONOTCOUNT)
            _DONOTCOUNT = false;

        return callback;
    }


    /// <summary>
    ///  Turns the dial counter clock-wise
    /// </summary>
    /// <param name="num">The number received from the list.</param>
    private void Subtract(int num) {
        _dialPosition -= num;

        while (_dialPosition < MIN_INT)
            _dialPosition += 100;
    }


    [Obsolete]
    /// <summary>
    ///  Stage 2 - Turn the dial and count the clicks of doom.
    /// </summary>
    /// <param name="num">The number received from the list.</param>
    /// <returns>Bool - Whether the click has been counted. (No double counts)</returns>
    private bool SubtractDivision(int num) {
        _dialPosition -= num; //789
        bool callback = false;

        while (_dialPosition < MIN_INT) {
            _dialPosition += 100;
            callback = true;
            if (_DONOTCOUNT) {
                _DONOTCOUNT = false;
                continue;
            }
            _password++;
                Console.WriteLine($"-pass++ :: sub :: {num}");
        }

        if (_DONOTCOUNT)
            _DONOTCOUNT = false;

        return callback;
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