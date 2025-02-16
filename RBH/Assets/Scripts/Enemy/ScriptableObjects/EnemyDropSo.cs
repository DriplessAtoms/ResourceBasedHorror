using InventorySystem;
using UnityEngine;

[CreateAssetMenu(fileName = "MyDropSO", menuName = "Enemy Drop SO")]
public class EnemyDropSO : ScriptableObject
{
    [field: SerializeField] public int MinQuantity { get; set; } = 1;

    [field: SerializeField] public int MaxQuantity { get; set; } = 5;

    [field: SerializeField] public ItemData DropItemData { get; set; }
}