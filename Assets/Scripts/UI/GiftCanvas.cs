using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftCanvas : ScreenView
{
   [SerializeField] private Button _hideButton;
   [SerializeField] private GameObject _knifeIcon;

   private Sprite _newKnifeSprite;
   
   public override void Init()
   {
      _hideButton.onClick.AddListener(HideGiftCanvas);
   }

   public override void OnShow()
   {
      GameServicesProvider.instance.GetService<InputSystem>().enabled = false;
      _newKnifeSprite = GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings()
         .GetKnifeSprite(GameServicesProvider.instance.GetService<GameManager>().GetCurrentLevelSettings().GetCurrentKnifeIndex());
      _knifeIcon.GetComponent<Image>().sprite = _newKnifeSprite;
   }

   private void HideGiftCanvas()
   {
      GameServicesProvider.instance.GetService<InputSystem>().enabled = true;
      UIManager.instance.Show<GameCanvas>();
   }
}
