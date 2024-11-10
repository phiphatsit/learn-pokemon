using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Pokemon pokemonPrefab;
    [SerializeField] private PlayerMovement playerObject;
    [SerializeField] private GameObject mapObject;
    [SerializeField] private Transform pokemonGroup;
    [SerializeField] private int spawnAmount = 5;

    private Vector2 mapMinBounds;
    private Vector2 mapMaxBounds;
    private List<Pokemon> pokemons = new List<Pokemon>();

    private void Start()
    {
        CalculateMapBounds();

        for (int i = 0; i < spawnAmount; i++)
        {
            SpawnObject();
        }
    }

    private void CalculateMapBounds()
    {
        SpriteRenderer renderer = mapObject.GetComponent<SpriteRenderer>();
        Vector2 mapCenter = renderer.bounds.center;
        Vector2 mapSize = renderer.bounds.size;

        mapMinBounds = mapCenter - (mapSize / 2);
        mapMaxBounds = mapCenter + (mapSize / 2);
    }

    private void SpawnObject()
    {
        SpriteRenderer objRenderer = pokemonPrefab.GetComponent<SpriteRenderer>();
        Vector2 objSize = objRenderer.bounds.size;

        float randomX = Random.Range(mapMinBounds.x + objSize.x / 2, mapMaxBounds.x - objSize.x / 2);
        float randomY = Random.Range(mapMinBounds.y + objSize.y / 2, mapMaxBounds.y - objSize.y / 2);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Pokemon pokemon = Instantiate(pokemonPrefab, pokemonGroup);

        if (IsOverlapping(spawnPosition, objSize) || IsOverlappingWithPlayer(spawnPosition, objSize))
        {
            Destroy(pokemon.gameObject);
        }
        else
        {
            pokemon.transform.position = spawnPosition;
            pokemon.Init();
            pokemons.Add(pokemon);
        }
    }


    bool IsOverlapping(Vector2 position, Vector2 size)
    {
        foreach (Pokemon obj in pokemons)
        {
            SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
            Vector2 otherPosition = obj.transform.position;
            Vector2 otherSize = renderer.bounds.size;

            if (position.x < otherPosition.x + otherSize.x &&
                position.x + size.x > otherPosition.x &&
                position.y < otherPosition.y + otherSize.y &&
                position.y + size.y > otherPosition.y)
            {
                return true;
            }
        }
        return false;
    }

    bool IsOverlappingWithPlayer(Vector2 position, Vector2 size)
    {
        SpriteRenderer playerRenderer = playerObject.GetComponent<SpriteRenderer>();
        Vector2 playerPosition = playerObject.transform.position;
        Vector2 playerSize = playerRenderer.bounds.size;

        return position.x < playerPosition.x + playerSize.x &&
               position.x + size.x > playerPosition.x &&
               position.y < playerPosition.y + playerSize.y &&
               position.y + size.y > playerPosition.y;
    }
}
