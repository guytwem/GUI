using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Customisation : MonoBehaviour
{
    [SerializeField] private Player player;



    [SerializeField]
    private string TextureLocation = "Character/";

    public enum CustomiseParts { Skin, Hair, Mouth, Eyes, Clothes, Armour };

    [SerializeField] PlayerProfession[] playerProfessions;

    public Renderer characterRenderer;

    public Vector2 scrollPosition = Vector2.zero;



    public List<Texture2D>[] partsTexture = new List<Texture2D>[Enum.GetNames(typeof(CustomiseParts)).Length];
    private int[] currentPartsTextureIndex = new int[Enum.GetNames(typeof(CustomiseParts)).Length];


    private void Start()
    {
        int partCount = 0;
        //Debug.Log( Enum.GetName(typeof(test), test.one));
        foreach (string part in Enum.GetNames(typeof(CustomiseParts)))
        {
            int textureCount = 0;
            Texture2D tempTexture;

            partsTexture[partCount] = new List<Texture2D>();
            do
            {
                tempTexture = (Texture2D)Resources.Load(TextureLocation + part + "_" + textureCount);
                if (tempTexture != null)
                {
                    partsTexture[partCount].Add(tempTexture);

                }
                textureCount++;
            }
            while (tempTexture != null);
            partCount++;
        }

        if (player == null)
        {
            Debug.LogError("Player in Customisation is null");
        }

        if(playerProfessions != null && playerProfessions.Length > 0)
        {
            player.Profession = playerProfessions[0];
        }

    }

    void SetTexture(CustomiseParts part, int direction)
    {
        int partIndex = (int)part;

        int max = partsTexture[partIndex].Count;

        int currentTexture = currentPartsTextureIndex[partIndex];
        currentTexture += direction;
        if (currentTexture < 0)
        {
            currentTexture = max - 1;

        }
        else if (currentTexture > max - 1)
        {
            currentTexture = 0;
        }
        currentPartsTextureIndex[partIndex] = currentTexture;

        Material[] mats = characterRenderer.materials;
        mats[partIndex].mainTexture = partsTexture[partIndex][currentTexture];
        characterRenderer.materials = mats;
    }
    


    

    void SetTexture(string type, int direction)
    {

        int partIndex = 0;


        switch (type)
        {
            case "skin":
                partIndex = 0;
                break;
            case "Hair":
                partIndex = 1;
                break;
            case "Mouth":
                partIndex = 2;
                break;
            case "Eyes":
                partIndex = 3;
                break;
            case "Clothes":
                partIndex = 4;
                break;
            case "Armour":
                partIndex = 5;
                break;
            default:
                Debug.LogError("Invalid set texture type");
                break;

        }

        int max = partsTexture[partIndex].Count;

        int currentTexture = currentPartsTextureIndex[partIndex];
        currentTexture += direction;
        if (currentTexture < 0)
        {
            currentTexture = max - 1;
        }
        else if (currentTexture > max - 1)
        {
            currentTexture = 0;
        }

        currentPartsTextureIndex[partIndex] = currentTexture;

        Material[] mats = characterRenderer.materials;

        mats[partIndex].mainTexture = partsTexture[partIndex][currentTexture];

            characterRenderer.materials = mats;

    }

    private void OnGUI()
    {

        CustomiseOnGUI();

        StatsOnGUI();


        ProfessionsOnGUI();


    }



    private void ProfessionsOnGUI()
    {

        float currentHeight = 0;

        GUI.Box(new Rect(Screen.width - 170, 230, 155, 80), "Profession");

        scrollPosition = GUI.BeginScrollView(new Rect(Screen.width - 170, 250, 155, 50), scrollPosition, new Rect(0, 0, 100, 30 * playerProfessions.Length));

        int i = 0;
        foreach (PlayerProfession profession in playerProfessions)
        {
            if (GUI.Button(new Rect(20, currentHeight + i * 30, 100, 20), profession.ProfessionName))
            {
                player.Profession = profession;
            }
            i++;
        }


        GUI.EndScrollView();

        GUI.Box(new Rect(Screen.width - 170, Screen.height - 90, 155, 80), "Display");
        GUI.Label(new Rect(Screen.width - 140, Screen.height - 100 + 30, 100, 20), player.Profession.ProfessionName);
        GUI.Label(new Rect(Screen.width - 140, Screen.height - 100 + 45, 100, 20), player.Profession.AbilityName);
        GUI.Label(new Rect(Screen.width - 140, Screen.height - 100 + 60, 100, 20), player.Profession.AbilityDescription);

    }


    private void StatsOnGUI()
    {
        float currentHeight = 40f;
        GUI.Box(new Rect(Screen.width - 170, 10, 155, 210), "Stats : " + player.playerStats.baseStatePoints);

        for (int i = 0; i < player.playerStats.baseStats.Length; i++)
        {
            BaseStats stat = player.playerStats.baseStats[i];

            if (GUI.Button(new Rect(Screen.width - 165, currentHeight + i * 30, 20, 20), "-"))
            {
                player.playerStats.SetStats(i, -1);
            }

            GUI.Label(new Rect(Screen.width - 140, currentHeight + i * 30, 100, 20), stat.baseStatName + ": " + stat.finalStat);

            if (GUI.Button(new Rect(Screen.width - 40, currentHeight + i * 30, 20, 20), "+"))
            {
                player.playerStats.SetStats(i, 1);
            }

        }
    }

        private void CustomiseOnGUI()
        {
            float currentHeight = 40;

            GUI.Box(new Rect(10, 10, 100, 210), "Visuals");

            int i = 0;

            foreach (CustomiseParts names in Enum.GetValues(typeof(CustomiseParts)))
            {
                if (GUI.Button(new Rect(20, currentHeight + i * 30, 20, 20), "<"))
                {
                    SetTexture(names, -1);
                }

                GUI.Label(new Rect(45, currentHeight + i * 30, 60, 20), names.ToString());

                if (GUI.Button(new Rect(90, currentHeight + i * 30, 20, 20), ">"))
                {
                    SetTexture(names, 1);
                }
                i++;
            }
        }

}
        
     

       

    

