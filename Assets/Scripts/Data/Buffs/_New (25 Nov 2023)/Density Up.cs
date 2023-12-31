using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "Gamejam/Buff/ShieldUp", fileName = "New ShieldUp")]
    public class ShieldUp : BuffData
    {
        public override string GetDescriptionWithModifier(RuntimeCharacter character)
        {
            int shield_up = character.properties.Get<int>(PropertyKey.SHIELD_UP).GetValueWithModifiers(character);
            return $"Increase <color={Colors.COLOR_STATUS}>Shield</color> gained from cards by {shield_up}.";
        }

        public override string GetDescription(int value)
        {
            return $"Increase <color={Colors.COLOR_STATUS}>Shield</color> gained from cards by {value}.";
        }
    }
}