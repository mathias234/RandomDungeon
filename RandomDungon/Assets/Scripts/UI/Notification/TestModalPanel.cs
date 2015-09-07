using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
namespace RandomDungeon.UI {
    public class TestModalPanel : MonoBehaviour {
        private ModalPanel modalPanel;

        private UnityAction myYesAction;
        private UnityAction myNoAction;
        private UnityAction myCancelAction;

        void Awake() {
            modalPanel = ModalPanel.Instance();

            myYesAction = new UnityAction(TestYesFunction);
            myNoAction = new UnityAction(TestNoFunction);
            myCancelAction = new UnityAction(TestCancelFunction);
        }

        public void TestYNC() {
            modalPanel.Choice("Do ya want to do that", myYesAction, myNoAction, myCancelAction);
        }

        void TestYesFunction() {
            Debug.Log("yes");
        }
        void TestNoFunction() {
            Debug.Log("no");
        }
        void TestCancelFunction() {
            Debug.Log("cancel");
        }
    }
}