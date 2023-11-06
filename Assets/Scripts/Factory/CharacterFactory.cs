﻿namespace DefaultNamespace
{
    /// <summary>
    /// For creating character instances from character data.
    /// </summary>
    public static class CharacterFactory
    {
        public static RuntimeCharacter Create(string name)
        {
            // Use the character name to get the character data/template from the database.
            CharacterData characterData = Database.characterData[name];
            
            // Create new instance of a character.
            RuntimeCharacter runtimeCharacter = new RuntimeCharacter
            {
                characterData = characterData,
                properties = new()
            };

            // Create character's properties.
            runtimeCharacter.properties.Add(PropertyKey.HEALTH, new Property<int>(characterData.health));
            runtimeCharacter.properties.Add(PropertyKey.MAX_HEALTH, new Property<int>(characterData.health));
            runtimeCharacter.properties.Add(PropertyKey.SIZE, new Property<int>(characterData.startSize));
            runtimeCharacter.properties.Add(PropertyKey.MAX_SIZE, new Property<int>(characterData.maxSize));
            runtimeCharacter.properties.Add(PropertyKey.ATTACK, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.SHIELD, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.POWER_UP, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_DISCARDED_ON_CURRENT_TURN_COUNT, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_DISCARDED_ON_CURRENT_BATTLE_COUNT, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_DESTROYED_ON_CURRENT_TURN_COUNT, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_DESTROYED_ON_CURRENT_BATTLE_COUNT, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_FADED_ON_CURRENT_TURN_COUNT, new Property<int>(0));
            runtimeCharacter.properties.Add(PropertyKey.CARDS_FADED_ON_CURRENT_BATTLE_COUNT, new Property<int>(0));
            
            return runtimeCharacter;
        }
    }
}