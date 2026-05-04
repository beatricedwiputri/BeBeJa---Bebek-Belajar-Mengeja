using UnityEngine;

public class Level1
{
    private static Level1 instance;

    private string[] kata = new string[]
    {
        "ada",
        "aja",
        "api",
        "adu",
        "aku",
        "ayo",
        "bau",
        "kau",
        "mau",
        "jus"
    };

    public static Level1 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Level1();
            }
            return instance;
        }
    }

    public void MulaiMudah()
    {
        int kataIndex = Random.Range(0, kata.Length);
        WordManager.setWord(kata[kataIndex]);
    }
}
