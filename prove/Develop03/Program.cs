using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    private string _text;
    private bool _hidden;

    public string Text { get => _text; }
    public bool Hidden { get => _hidden; }

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public void Show()
    {
        _hidden = false;
    }
}

public class Reference
{
    private string _reference;

    public string Text { get => _reference; }

    public Reference(string reference)
    {
        _reference = reference;
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Reference Reference { get => _reference; }
    public List<Word> Words { get => _words; }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Additional constructor for verse range
    public Scripture(Reference reference, List<string> text)
    {
        _reference = reference;
        _words = text.Select(word => new Word(word)).ToList();
    }

    public void HideRandomWord()
    {
        Random rnd = new Random();
        int index = rnd.Next(_words.Count);
        if (!_words[index].Hidden)
            _words[index].Hide();
    }

    public bool AllWordsHidden()
    {
        return _words.All(word => word.Hidden);
    }

    public void ShowScripture()
    {
        Console.Clear();
        Console.WriteLine($"Scripture: {_reference.Text}");
        foreach (var word in _words)
        {
            if (word.Hidden)
                Console.Write("____ ");
            else
                Console.Write(word.Text + " ");
        }
        Console.WriteLine("\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Test the program
        Reference reference = new Reference("John 3:16");
        List<string> text = new List<string>{"For", "God", "so", "loved", "the", "world,", "that", "he", "gave", "his", "only", "begotten", "Son,", "that", "whosoever", "believeth", "in", "him", "should", "not", "perish,", "but", "have", "everlasting", "life."};
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AllWordsHidden())
        {
            scripture.ShowScripture();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;
            else
                scripture.HideRandomWord();
        }

        Console.WriteLine("Program ended.");
    }
}
