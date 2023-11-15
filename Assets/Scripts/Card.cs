using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoreMountains.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    // TODO: This can be attached to card prefab
    public class Card : MonoBehaviour
    {
        public UnityEvent<Card> OnDrag;
        public UnityEvent<Character> OnEnterTarget;
        public UnityEvent<Character> OnDropped;
        
        public RuntimeCard runtimeCard;

        [SerializeField] private TextMeshPro nameTxt;
        [SerializeField] private TextMeshPro effectTxt;
        [SerializeField] private DragableObject dragableObject;

        [SerializeField] private List<Character> validTargets = new List<Character>();

        private Character currentTarget;
        
        /// <summary>
        /// Init card data, need to call UpdateCard afterward to update effects text
        /// </summary>
        /// <param name="_runtimeCard"></param>
        public void InitCard(RuntimeCard _runtimeCard)
        {
            runtimeCard = _runtimeCard;
            runtimeCard.Card = this;
            nameTxt.SetText(_runtimeCard.cardData.name);
        }

        /// <summary>
        /// Call after init or when player size changed to update card's effect value
        /// </summary>
        /// <param name="_character"></param>
        public void UpdateCard(RuntimeCharacter _character)
        {
            StringBuilder _builder = new StringBuilder();
            foreach (var _effect in runtimeCard.cardData.effects)
            {
                _builder.AppendLine(_effect.GetDescriptionTextWithModifier(runtimeCard, _character));
            }
            
            effectTxt.SetText(_builder.ToString());
        }

        public void SetValidTarget(List<Character> _targets)
        {
            validTargets = _targets.ToList();
        }

        public bool ValidateTarget(Character _character)
        {
            return validTargets.Contains(_character);
        }
        
        public void ClearCallBack()
        {
            OnDrag.RemoveAllListeners();
        }

        private void OnMouseDrag()
        {
            OnDrag?.Invoke(this);
        }
        
        private void OnMouseUp()
        {
            if (ValidateTarget(currentTarget))
            {
                OnDropped?.Invoke(currentTarget);
            }
            else
            {
                dragableObject.MoveToOrigin();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            currentTarget = other.gameObject.GetComponent<Character>();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            currentTarget = null;
        }
    }
}