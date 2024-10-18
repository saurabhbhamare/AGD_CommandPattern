using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Command.UI
{
    public class BattleEndUIView : MonoBehaviour, IUIView
    {
        private BattleEndUIController controller;
        [SerializeField] private TextMeshProUGUI resultText;
        [SerializeField] private Button homeButton;
        [SerializeField] private Button replayButton;

        private void Start() => SubscribeToButtonClicks();

        private void SubscribeToButtonClicks()
        {
            homeButton.onClick.AddListener(controller.OnHomeButtonClicked);
            replayButton.onClick.AddListener(controller.OnReplayButtonClicked);
        }

        public void SetController(BattleEndUIController controllerToSet) => controller = controllerToSet;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetResultText(string textToSet) => resultText.SetText(textToSet);
    }
}
