using System.Collections;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
   [SerializeField] private Vector3 _spawnPos;

   private AllKnives _allKnives;
   
   private void Start()
   {
      ActiveKnife.onKnifeIsStuckInLog += SpawnKnife;
      StageController.onStartStage += SpawnKnife;
      _allKnives = GetComponent<AllKnives>();
   }

   private void OnDisable()
   {
      ActiveKnife.onKnifeIsStuckInLog -= SpawnKnife;
      StageController.onStartStage -= SpawnKnife;
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
      knife.name = knife.name + " " + GetComponent<AllKnives>().GetActiveKnives().Count;
      _allKnives.AddKnife(knife);
   }
}
