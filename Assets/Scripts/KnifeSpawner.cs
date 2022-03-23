using System.Collections;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
   [SerializeField] private Vector3 _spawnPos;

   private AllKnives _allKnives;
   private Sprite _spawnedKnifeSprite;
   
   private void Start()
   {
      ActiveKnife.onKnifeIsStuckInLog += SpawnKnife;
      StageController.onStartPlainStage += SpawnKnife;
      StageController.onStartBossFightStage += SpawnKnife;
      StageController.onEndBossFightStage += SetSpawnedKnifeSprite;
      _allKnives = GetComponent<AllKnives>();
      SetSpawnedKnifeSprite(0);
   }

   private void OnDisable()
   {
      ActiveKnife.onKnifeIsStuckInLog -= SpawnKnife;
      StageController.onStartPlainStage -= SpawnKnife;
      StageController.onStartBossFightStage -= SpawnKnife;
      StageController.onEndBossFightStage -= SetSpawnedKnifeSprite;
   }

   private void SpawnKnife()
   {
      if (_allKnives.GetActiveKnives().Count !=
          GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetStageKnivesCount())
      {
         StartCoroutine(WaitForSpawn());
      }
   }
   
   private IEnumerator WaitForSpawn()
   {
      yield return null;
      GameObject knife = Instantiate(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetActiveKnifePrefab(),
         _spawnPos, Quaternion.identity);
      knife.GetComponent<SpriteRenderer>().sprite = _spawnedKnifeSprite;
      knife.name = knife.name + " " + GetComponent<AllKnives>().GetActiveKnives().Count;
      _allKnives.AddKnife(knife);
   }

   private void SetSpawnedKnifeSprite(int knifeSpriteIndex)
   {
      _spawnedKnifeSprite = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings()
         .GetKnifeSprite(knifeSpriteIndex);
   }
}
