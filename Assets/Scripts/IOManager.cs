using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class IOManager : MonoBehaviour
{
    private static string savePath = "Saves/save.txt";



    public static void WriteSave(List<HighScore> highScores)
    {
        List<string> names = new List<string>();
        List<string> scores = new List<string>();
        for (int i = 0; i < highScores.Count; i++)
        {
            if (highScores[i] == null) break;
            names.Add(highScores[i].playerName);
            scores.Add(highScores[i].playerScore.ToString());
        }

        StreamWriter writer = new StreamWriter(savePath, false);
        for (int i = 0; i < highScores.Count; i++)
        {
            if (names[i] == null) break;
            writer.Write(names[i]);
            writer.Write("\n");
            if (scores[i] == null) break;
            writer.Write(scores[i]);
            writer.Write("\n");
        }
        writer.Close();
    }

    public static List<HighScore> ReadSave()
    {
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory("Saves");
            StreamWriter writer = new StreamWriter(savePath, true);
            writer.Write("");
            writer.Close();
        }


        List<HighScore> highScores = new List<HighScore>();

        List<string> names = new List<string>();
        List<string> scores = new List<string>();

        StreamReader reader = new StreamReader(savePath);
        int c = 0;
        while (!reader.EndOfStream)
        {
            string name = reader.ReadLine();
            names.Add(name);
            string score = reader.ReadLine();
            scores.Add(score);
            c++;
        }
        reader.Close();

        int i = 0;
        while(i < names.Count && i < scores.Count)
        {
            HighScore high = new HighScore("", 0);
            high.playerName = names[i];
            high.playerScore = Int32.Parse(scores[i]);
            highScores.Add(high);
            i++;
        }
        return highScores;
    }
}
