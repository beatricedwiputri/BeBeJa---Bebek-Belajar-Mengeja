using UnityEngine;

public class Level4
{
    private static Level4 instance;

    private static string[] kata = new string[] {
        "Kertas",
        "Petang",
        "Sekali",
        "Minyak",
        "Cermin",
        "Masker",
        "Guling",
        "Pantai",
        "Gedung",
        "Gunung"
    };

    public static Level4 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Level4();
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
