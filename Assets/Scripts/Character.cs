using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    // TODO: This can be attached to character prefab
    public class Character : MonoBehaviour
    {
        public RuntimeCharacter runtimeCharacter;
        [SerializeField] private TextMeshPro hpTxt;
        [SerializeField] private TextMeshPro statText;

        public void Init(RuntimeCharacter _runtimeCharacter)
        {
            runtimeCharacter = _runtimeCharacter;
            runtimeCharacter.Character = this;
            
            //Update visual
            UpdateHpVisual(runtimeCharacter.properties.Get<int>(PropertyKey.HEALTH).Value);
            UpdateSizeVisual(runtimeCharacter.properties.Get<int>(PropertyKey.SIZE).Value);
            UpdateFormVisual(runtimeCharacter.GetCurrentForm());
            
            runtimeCharacter.properties.Get<int>(PropertyKey.HEALTH).OnChanged +=
                _property => UpdateHpVisual(_property.Value);
            
            
        }

        public void UpdateStat()
        {
            
        }

        public void UpdateHpVisual(int _value)
        {
            hpTxt.SetText($"HP: {_value}");
        }

        public void UpdateSizeVisual(int _size)
        {
            
        }

        public void UpdateFormVisual(FormData _form)
        {
            
        }
    }
}