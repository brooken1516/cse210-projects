using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random(); // to keep it from leaving 1-3 words on display. 

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');

        foreach (string word in wordArray)
        {
            string cleanWord = word.Trim(new char[] { ',', ';', '.', '!', '?' });
            Word newWord = new Word(cleanWord);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords()
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        int maxToHide = 4;
        int wordsToHide; 

        if (visibleWords.Count <= maxToHide)
        {
            wordsToHide = visibleWords.Count;
        }
        else
        {
            wordsToHide = _random.Next(1, maxToHide + 1);
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + "\n";

        foreach (Word word in _words)
        {
            result = result + word.GetDisplayText() + " ";
        }
        return result;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}