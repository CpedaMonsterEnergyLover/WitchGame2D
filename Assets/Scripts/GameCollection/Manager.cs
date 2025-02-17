﻿using System.Collections.Generic;
using UnityEngine;
namespace GameCollection
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] private Items items;
        [SerializeField] private Entities entities;
        [SerializeField] private Interactables interactables;
        [SerializeField] private CraftingRecipies recipies;
        [SerializeField] private WorldScenesCollection scenesCollection;
        [SerializeField] private Hearts heartsCollection;
        [SerializeField] private Biomes biomes;
        
        private static bool Initialized { get; set; }

        private void Awake()
        {
            PrettyDebug.Log("Initialisation", this);
            Init();
        }

        private void OnDestroy()
        {
            Initialized = false;
        }

        public void Init()
        {
            if(Initialized) return;
            items.Init();
            entities.Init();
            interactables.Init();
            recipies.Init();
            scenesCollection.Init();
            heartsCollection.Init();
            Initialized = true;
            biomes.Init();
            if(Application.isPlaying) GameDataManager.CountWorldParts();
        }

        public static void MapCollection<T>(List<GameObject> objects, Dictionary<string, GameObject> dictionary, string collectionName) where T : Interactable
        {
            objects.ForEach(o =>
            {
                o.TryGetComponent(out T component);
                if (component is null)
                {
                    Debug.LogError($"Не удалось получить компонент {typeof(T)} на объекте {o.name} в коллекции {dictionary}");
                    return;
                }

                string id = component.Data.id;

                if (string.IsNullOrEmpty(id))
                {
                    Debug.LogError($"Пустой айди для объекта {component.Data.name} в коллекции {collectionName}");
                    return;
                }
                
                if (dictionary.ContainsKey(id))
                {
                    Debug.LogError($"Айди {id} в коллекции {collectionName} уже присутствует");
                    return;
                }
                
                dictionary.Add(component.Data.id, o);
            });
        }
    }

}