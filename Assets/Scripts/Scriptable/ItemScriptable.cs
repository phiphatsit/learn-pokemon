using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject/ItemData", order = 1)]
public class ItemScriptable : ScriptableObject
{
    public int itemId;
    public string itemCategory;
    public Sprite itemSprite;
    public string itemName;
    public int itemAmount;
    public string itemDescription;
}
