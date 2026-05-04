using UnityEngine;

public class Level3
{
    private static Level3 instance;

    private static string[] kata = new string[] {
        "Candi",
        "Busuk",
        "Siang",
        "Tikus",
        "Lemon",
        "Panda",
        "Malam",
        "Udara",
        "Kipas",
        "Kursi"
    };

    public static Level3 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Level3();
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
