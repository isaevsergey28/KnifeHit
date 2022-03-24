using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossSpritesInfo", menuName = "NewBoss")]
public class BossSpritesInfo : ScriptableObject
{
    [SerializeField] private Sprite _bossSprite;
    [SerializeField] private GameObject _breakingBossPrefab;

    public Sprite GetBossSprite()
    {
        return _bossSprite;
    }

    public GameObject GetBreakingBossPrefab()
    {
        return _breakingBossPrefab;
    }
}
