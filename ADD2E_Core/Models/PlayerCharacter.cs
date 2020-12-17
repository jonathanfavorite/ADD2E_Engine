using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;
using ADD2E_Core.Services;
namespace ADD2E_Core.Models
{
    public class PlayerCharacter : IPlayerCharacter
    {
        public int? PlayerID { get; set; } = null;
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public int Level { get; set; } = 1;
        public int? HitPoints { get; set; } = null;
        public int ArmorClass { get; set; } = 10;
        public bool RandomizeStats { get; set; } = false;
        public IRace Race { get; set; }
        public Money CoinPurse { get; set; } = new Money();
        public IClass Class { get; set; }
        public ThacoScore Thaco { get; set; }
        public AbilityScores AbilityScores { get; set; } = new AbilityScores();
        public List<IEquipment> Equipment { get; set; } = new List<IEquipment>();
        public IWeapon PrimaryWeapon { get; set; } = null;
        public IWeapon SecondaryWeapon { get; set; } = null;
        public List<IEquipment> EquippedGear { get; set; } = new List<IEquipment>();
        public ClassExperienceLevel LevelInfo { get; set; }
        public ClassExperienceLevel NextLevelInfo { get; set; }
        public int Experience { get; set; } = 0;

        private CharacterManager characterManager = new CharacterManager();
        public RaceType RaceType { get; set; }
        public ClassType ClassType { get; set; }

        public void CreateCharacter()
        {
            ClassManager classManager = new ClassManager();

            Race = characterManager.SetPlayerRace(RaceType);
            if(characterManager.CanRacePlayClass(Race, ClassType))
            {
                Class = characterManager.setCharacterClass(ClassType);
                LevelInfo = classManager.getExperienceLevels(ClassType, Level);
                NextLevelInfo = classManager.getExperienceLevels(ClassType, Level + 1);
                HitPoints = characterManager.SetHitPoints(Level, Class, AbilityScores, HitPoints);
                Thaco = characterManager.SetupThaco(Class.ClassGroup, Level);
                if(RandomizeStats)
                {
                    AbilityScores = characterManager.RandomizeAbilityScores(AbilityScores);
                }
                else
                {
                    AbilityScores = characterManager.UpdateAbilityScores(AbilityScores);
                }
            }
            else
            {
                string expMessage = string.Format("{0} cannot be a {1}", Race.ToString(), ClassType.ToString());
                throw new Exception(expMessage);
            }
        }

        public void AddItem(IEquipment Item, int Quantity = 1)
        {
            var addedItems = characterManager.AddItem(Item, Quantity);
            foreach(IEquipment item in addedItems)
            {
                Equipment.Add(item);
            }
        }
        public void RemoveItem(IEquipment Item, int Quantity = 1)
        {
            Equipment = characterManager.RemoveItem(Item, Quantity, Equipment);
        }
        public void AddMoney(Money m)
        {
            CoinPurse = characterManager.AddMoney(CoinPurse, m);
        }
        public void RemoveMoney(Money m)
        {
            CoinPurse = characterManager.RemoveMoney(CoinPurse, m);
        }


        public void EquipItem(object item)
        {
            if (item is IWeapon)
            {
                EquipPrimary((IWeapon)item);
            }
            else if(item is IGear)
            {
                EquipGear((IGear)item);
            }
            else
            {
                string exceptionMsg = string.Format($"Item is not a weapon or piece of gear.");
                throw new Exception(exceptionMsg);
            }
        }
        private void EquipPrimary(IWeapon item)
        {
            if (item.SlotType == EquipmentSlot.PRIMARY)
            {
                Equipment = characterManager.NoLongerEquipped(item, Equipment);
                PrimaryWeapon = item;
            }
            else
            {
                string exceptionMsg = string.Format($"{item.Name} is not a primary weapon.");
                throw new Exception();
            }
        }
        private void EquipGear(IGear item)
        {
            EquippedGear.Add(item);
        }

    }
}
