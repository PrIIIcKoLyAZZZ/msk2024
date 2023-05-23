using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, int> _items = new Dictionary<string, int>();

    public void AddItems(string itemName)
    {
        if(_items.ContainsKey(itemName))
        {
            _items[itemName]++;
            Debug.Log(_items[itemName]);
        }
        else
        {
            _items.Add(itemName, 1);
            Debug.Log(_items[itemName]);
        }
        //TODO UPDATE INTERFACE
    }
}
