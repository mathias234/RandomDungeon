﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

namespace RandomDungeon.UI {
    public class ModalPanel : MonoBehaviour {
        public Text question;
        public Image iconImage;
        public Button yesButton;
        public Button cancelButton;
        public GameObject modalPanelObject;

        private static ModalPanel modalPanel;

        public static ModalPanel Instance() {
            if (!modalPanel) {
                modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
                if (!modalPanel)
                    Debug.LogError("There needs to be one active ModalPanel script on you GameObject in your scene.");
            }

            return modalPanel;
        }

        public void Choice(string question, UnityAction yesEvent,  UnityAction cancelEvent) {
            modalPanelObject.SetActive(true);

            yesButton.onClick.RemoveAllListeners();
            yesButton.onClick.AddListener(yesEvent);
            yesButton.onClick.AddListener(ClosePanel);

            cancelButton.onClick.RemoveAllListeners();
            cancelButton.onClick.AddListener(cancelEvent);
            cancelButton.onClick.AddListener(ClosePanel);

            this.question.text = question;

            this.iconImage.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(true);
            cancelButton.gameObject.SetActive(true);
        }


        void ClosePanel() {
            modalPanelObject.SetActive(false);
        }
    }
}