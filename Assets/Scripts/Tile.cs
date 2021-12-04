﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Material selectMaterial;

    int location;
    public int Location { get { return location; } set { location = value; } }
    List<Tile> surroundings;
    MeshRenderer meshRenderer;
    Material defaultMaterial;
    List<Attack> targetForAttacks = new List<Attack>();
    BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }

    private void Update()
    {
        
    }

    IEnumerator FlipCollision()
    {
        while(true)
        {
            boxCollider.enabled = !boxCollider.enabled;
            boxCollider.enabled = !boxCollider.enabled;
            yield return new WaitForSeconds(5f);
        }
    }

    public void Mark(Attack attack)
    {
        Debug.Log("Tile Marked for Attack");
        targetForAttacks.Add(attack);
    }

    public void AttackAvailableTargets()
    {
        boxCollider.enabled = false;
        boxCollider.enabled = true;
    }
   
    public void ClearTarget(Attack attack)
    {
        if(targetForAttacks.Contains(attack)) targetForAttacks.Remove(attack);
        Debug.Log("Attack cleared");
    }

    public List<Attack> GetAttacks(int team)
    {
        return targetForAttacks;
    }
    
}

public class TileLocation
{
    public int xIndex;
    public int yIndex;

    public TileLocation(int xIndex, int yIndex)
    {
        this.xIndex = xIndex;
        this.yIndex = yIndex;
    }
}

public enum TileDirection: byte
{
    NORTH = 0x01,
    NORTHEAST = 0x02,
    EAST = 0x04,
    SOUTHEAST = 0x08,
    SOUTH = 0x10,
    SOUTHWEST = 0x20,
    WEST = 0x40,
    NORTHWEST = 0x80,
    ALL = 0xFF,
    NONE = 0x00

}



