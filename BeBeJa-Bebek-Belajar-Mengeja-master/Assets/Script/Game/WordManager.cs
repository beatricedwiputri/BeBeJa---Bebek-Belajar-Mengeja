using UnityEngine;
using TMPro;

public static class WordManager{

    private static string word;

    public static void setWord(string wordInput)
    {
        word = wordInput.ToUpper();
    }

    public static string getWord()
    {
        return word;
    }

    public static void delWord(){
        word = null;
    }

    public static bool isWordSet(){
        if (word == null) return false;
        return true;
    }
}