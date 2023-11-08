using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace DefaultNamespace
{
    /// <summary>
    /// Where can we drag and drop the card? Does it need to be dropped on enemy,
    /// player or is dropping it to the background enough?
    /// </summary>
    [Flags]
    public enum CardDragTarget
    {
        NONE = 0,
        ENEMY = 1,
        PLAYER = 1 << 1,
        BACKGROUND = 1 << 2,
    }

    // TODO: Include more types? We can use the CardType for filtering cards among other things.
    // TODO: See Slay the Spire for reference. We can also show the CardType as a "subtitle" below the card name in the card graphic.
    public enum CardType
    {
        NONE,
        ATTACK,
        DEFEND,
    }
    
    /// <summary>
    /// The base data for a card which is immutable and should not be modified during runtime.
    /// This data is used as a template for creating card instances.
    /// </summary>
    [CreateAssetMenu(menuName = "Gamejam/Card", fileName = "New Card")]
    public class CardData : ScriptableObject
    {
        [InfoBox("Card type can be used for the card graphic and other things (you can refer to Slay the Spire).")]
        public CardType cardType;
        
        [InfoBox("Determines the valid drag target when player is dragging and dropping the card. " +
                 "For example: an AOE attack card can be dropped anywhere because it doesn't need a target.")]
        public CardDragTarget cardDragTarget;
        
        [InfoBox("Unless you know what you're doing don't edit effect data directly from " +
                 "here because it affects other cards that are using the same effect. " +
                 "You can always create a new Effect from Assets/Create/Gamejam/Effect/ or " +
                 "you can duplicate an existing effect and edit it.", EInfoBoxType.Warning)]
        [Expandable] public List<EffectData> effects;
    }
}