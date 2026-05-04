using UnityEngine;

public class Level2
{
    private static Level2 instance;

    private static string[] kata = new string[] {
    "Buku",
    "Kota",
    "Nama",
    "Sana",
    "Sini",
    "Hari",
    "Mata",
    "Kopi",
    "Mata",
    "Laut"
    };

    public static Level2 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Level2();
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
