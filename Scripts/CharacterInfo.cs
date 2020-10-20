using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterInfo : MonoBehaviour
{
    public static CharacterInfo instance;

    void Awake()
    {
        if(instance != null && instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public List<string> playerModels;

    public void AddSelectedCharacterModel(GameObject selectedModel)
    {
        if(selectedModel == null)
        {
            playerModels.Add("Player");
        }
        else
        {
            playerModels.Add(selectedModel.name);
            Debug.Log("I've been added");
        }
    }
}
