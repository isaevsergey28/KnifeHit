using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeIcons : MonoBehaviour
{
   [SerializeField] private GameObject _knifeIconPrefab;
   [SerializeField] private Color _usedKnifeIconColor;

   private List<GameObject> _allKnives = new List<GameObject>();
   private int _activeKnifeIndex;
   
   private void Start()
   {
      ActiveKnife.onKnifeIsStuckInLog += HideActiveKnifeIcon;
      StageController.onEndStage += ClearKnivesPanel;
      StageController.onStartPlainStage += SpawnKnifeIcons;
      StageController.onStartBossFightStage += SpawnKnifeIcons;
   }

   private void OnDisable()
   {
      ActiveKnife.onKnifeIsStuckInLog -= HideActiveKnifeIcon;
      StageController.onEndStage -= ClearKnivesPanel;
      StageController.onStartPlainStage -= SpawnKnifeIcons;
      StageController.onStartBossFightStage -= SpawnKnifeIcons;
   }

   public void SpawnKnifeIcons()
   {
      int _knifeIconsCount = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetStageKnivesCount();
      for (int i = 0; i < _knifeIconsCount; i++)
      {
         _allKnives.Add(Instantiate(_knifeIconPrefab, transform));
      }
   }

   private void HideActiveKnifeIcon()
   {
      _allKnives[_activeKnifeIndex].GetComponent<Image>().color = _usedKnifeIconColor;
      _activeKnifeIndex++;
   }

   private void ClearKnivesPanel()
   {
      foreach (var knifeIcon in _allKnives)
      {
         Destroy(knifeIcon);
      }
      _allKnives.Clear();
      _activeKnifeIndex = 0;
   }
}
