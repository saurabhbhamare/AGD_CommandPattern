using Command.Actions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Command.UI
{
    public class ActionButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        private ActionSelectionUIController owner;
        private CommandType commandType;

        private void Start() => GetComponent<Button>().onClick.AddListener(OnActionButtonClicked);

        public void SetOwner(ActionSelectionUIController owner) => this.owner = owner;

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        private void OnActionButtonClicked() => owner.OnActionSelected(commandType);

        public void SetCommandType(CommandType actionType)
        {
            this.commandType = actionType;
            buttonText.SetText(actionType.ToString());
        }
    }
}