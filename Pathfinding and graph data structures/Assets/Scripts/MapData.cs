using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MapData : MonoBehaviour
{
    public int width = 10;
    public int height = 5;

    public TextAsset textAsset;
    public Texture2D textureMap;

    public void SetDimentions(List<string> textLines)
    {
        height=textLines.Count;
        foreach (string line in textLines)
        {
            if (line.Length>width)
            {
                width=line.Length;
            }
        }
    }

    public List<string> getMapFromTexture(Texture2D textureAsset)
    {
        List<string> lines = new List<string>();

        for (int y = 0; y<textureAsset.height; y++)
        {
            string newLine = "";

            for (int x = 0; x<textureAsset.width; x++)
            {
                if (textureAsset.GetPixel(x, y)==Color.black)
                {
                    newLine+='1';
                }
                else if
                   (textureAsset.GetPixel(x, y)==Color.white)
                {
                    newLine+='0';
                }
                else
                {
                    newLine+=' ';
                }
            }
            lines.Add(newLine);
        }

        return lines;
    }

    public List<string> GetTextFromFile(TextAsset ta)
    {
        List<string> lines = new List<string>();

        if (ta!=null)
        {
            string textData = textAsset.text;
            string[] delimiters = { "\r\n", "\n" };
            lines.AddRange(textData.Split(delimiters, System.StringSplitOptions.None));
            lines.Reverse();
        }
        else
        {
            Debug.Log("TEXT FILE FAIL");
        }
        return lines;
    }

    public List<string> GetTextFromFile()
    {
        return GetTextFromFile(textAsset);
    }

    public int[,] MakeMap()
    {
        List<string> lines = new List<string>();

        if (textureMap!=null)
        {
            lines=getMapFromTexture(textureMap);
        }
        else
        {
            lines=GetTextFromFile();
        }
        SetDimentions(lines);
        int[,] map = new int[width, height];
        for (int y = 0; y<height; y++)
        {
            for (int x = 0; x<width; x++)
            {
                if (lines[y].Length>x)
                    map[x, y]=(int)Char.GetNumericValue(lines[y][x]);
            }
        }
        return map;
    }
}