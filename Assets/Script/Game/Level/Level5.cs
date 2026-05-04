using UnityEngine;

public class Level5
{
    private static Level5 instance;

    private static string[] kata = new string[] {
        "Memotong",
        "Bagaimana",
        "Televisi",
        "Dispense",
        "Alpukat",
        "Terlambat",
        "Plastik",
        "Estetika",
        "Cukuplah",
        "Monitor"
    };

    public static Level5 Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Level5();
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
