namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities;

public class CommandIterator
{
    private readonly string[] _words;
    private int _index;

    public CommandIterator(string command)
    {
        _words = command.Split(' ');
    }

    public bool MoveNext()
    {
        if (_index >= _words.Length - 1) return false;
        _index++;
        return true;
    }

    public string Current() => _words[_index];

    public string Current(int numberOfWords)
    {
        if (_index + numberOfWords > _words.Length)
        {
            numberOfWords = _words.Length - _index;
        }

        return string.Join(" ", _words, _index, numberOfWords);
    }
}