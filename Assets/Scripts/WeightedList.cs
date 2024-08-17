using UnityEngine;
using System;

[Serializable]
public class WeightedList
{
    [SerializeField]
    private WeightedGameObject[] elements = new WeightedGameObject[0];

    public GameObject Choose()
    {
        int choosenWeight = UnityEngine.Random.Range(0, TotalWeight());

        int weights = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            weights += elements[i].weight;
            if(weights > choosenWeight)
            {
                return elements[i].element;
            }
        }
        //if you're here, something broke
        return null;
    }

    private int TotalWeight()
    {
        int result = 0;

        for(int i = 0; i < elements.Length; i++)
        {
            result += elements[i].weight;
        }

        return result;
    }
}

[Serializable]
public class WeightedGameObject
{
    public int weight = 1;
    public GameObject element = null;
}
