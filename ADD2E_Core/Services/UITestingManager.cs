using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ADD2E_Core.Models;
using ADD2E_Core.Interfaces;
using ADD2E_Core.Enums;

namespace ADD2E_Core.Services
{
    public class UITestingManager
    {
        public void GetTypeAndDisplayString(object o, string displayName = "")
        {
            Console.WriteLine($"\r\n({o.GetType()}) {displayName}");
        }

        public void ShowCharacterInfo(ICharacter p, bool detailed = false)
        {
            if (p is IPlayerCharacter c)
            {
                Console.WriteLine($" \r\n #############################################");
                Console.WriteLine($" ########### Player Information ##############");
                Console.WriteLine($" #############################################");

                Console.WriteLine($"\r\n Player Name: {p.Name}");
                Console.WriteLine($" Class: {p.Class.Name}");
                Console.WriteLine($" Race: {p.Race.Name}");
                Console.WriteLine($" Level: {p.Level}");
                Console.WriteLine($" Experience: {p.Experience} / {p.NextLevelInfo.Experience} ({c.CurrentLevelProgressExp}% completed)");
                ShowExperienceBar(p);
                Console.WriteLine($" HP: {p.HitPoints} / {p.TmpHitPoints}");
                Console.WriteLine($" Thaco: {p.Thaco.Value}");
                Console.WriteLine($" AC: {p.ArmorClass}");
                Console.WriteLine($" Alignment: {p.Alignment}");

                if (detailed)
                {
                    ShowAbilityScores(p);
                    ShowSavingThrows(p);
                    ShowEquipmentForCharacter(p);
                    ShowTotalVendoredAmount(p);
                    ShowCoinPurse(p);
                    //ShowPrimaryWeapon(p);
                    ShowEquippedGear(p);
                    ShowSpellBook(p);
                }
            }
        }
        public void ShowAbilityScores(ICharacter p)
        {
            Console.WriteLine($"\r\n-- Ability Scores --");
            Console.WriteLine($" Strength:     {p.AbilityScores.Strength.Value} ({AbilityAdj(p.AbilityScores.Strength.HitProb)})");
            Console.WriteLine($" Dexterity:    {p.AbilityScores.Dexterity.Value} ({AbilityAdj(p.AbilityScores.Dexterity.ReactionAdjustment)})");
            Console.WriteLine($" Constitution: {p.AbilityScores.Constitution.Value} ({AbilityAdj(p.AbilityScores.Constitution.HitPointAdjustment)})");
            Console.WriteLine($" Intelligence: {p.AbilityScores.Strength.Value}");
            Console.WriteLine($" Widsom:       {p.AbilityScores.Wisdom.Value} ({AbilityAdj(p.AbilityScores.Wisdom.MagicalDefenceAdjustment)})");
            Console.WriteLine($" Charisma:     {p.AbilityScores.Charisma.Value} ({AbilityAdj(p.AbilityScores.Charisma.ReactionAdjustment)})");
        }
        private void ShowExperienceBar(ICharacter p)
        {
            if (p is IPlayerCharacter pc)
            {
                //⬜⬛
                string final = "";
                int boxTotal = 14;
                int boxes = Convert.ToInt32(Math.Round((double)boxTotal * ((double)pc.CurrentLevelProgressExp / 100)));
                for (int i = 1; i <= boxTotal; i++)
                {
                    if(i <= boxes)
                    {
                        final += "[X]";
                    }
                    else
                    {
                        final += "[ ]";
                    }
                }
                Console.WriteLine(" Experience Bar: " + final);
            }
        }
        public void ShowSavingThrows(ICharacter p)
        {
            Console.WriteLine($"\r\n-- Saving Throws --");
            Console.WriteLine($" Paralyzation:  {p.SavingThrows.Paralyzation.Value}");
            Console.WriteLine($" Poison:        {p.SavingThrows.Poison.Value}");
            Console.WriteLine($" Death Magic:   {p.SavingThrows.DeathMagic.Value}");
            Console.WriteLine($" Rod:           {p.SavingThrows.Rod.Value}");
            Console.WriteLine($" Staff:         {p.SavingThrows.Staff.Value}");
            Console.WriteLine($" Wand:          {p.SavingThrows.Wand.Value}");
            Console.WriteLine($" Petrification: {p.SavingThrows.Petrification.Value}");
            Console.WriteLine($" Polymorph:     {p.SavingThrows.Polymorph.Value}");
            Console.WriteLine($" Breath Weapon: {p.SavingThrows.BreathWeapon.Value}");
            Console.WriteLine($" Spell:         {p.SavingThrows.Spell.Value}");
        }
        private string AbilityAdj(int adjustment)
        {
            string returnVal = adjustment.ToString();
            if (!adjustment.ToString().Contains("-"))
            {
                if (adjustment != 0)
                {
                    returnVal = "+" + adjustment.ToString();
                }
            }
            return returnVal;
        }
        public void ShowEquipmentForCharacter(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Equipment --");
            // Group up items by name
            EquipmentManager eManager = new EquipmentManager(p.Equipment);
            eManager.DisplayAllEquipmentByQuantity();
            foreach (string item in eManager.DisplayAllEquipmentByQuantity())
            {
                Console.WriteLine($" {item}");
            }
        }
        public void ShowCoinPurse(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Coin Purse --");
            Console.WriteLine(" {0}", MoneyManager.PrettyMoney(p.CoinPurse));
        }
        public void ShowTotalVendoredAmount(ICharacter p)
        {
            Money finalMoney = new Money();
            foreach(IEquipment m in p.Equipment)
            {
                finalMoney.Gold += m.Price.Gold;
                finalMoney.Silver += m.Price.Silver;
                finalMoney.Copper += m.Price.Copper;
            }
            var switchedMoney = MoneyManager.CalculateMoney(finalMoney);

            Console.WriteLine($"\r\n-- {p.Name}'s Equipment Vendor Value --");
            Console.WriteLine(" {0}", MoneyManager.PrettyMoney(switchedMoney));
        }

        public void ShowPrimaryWeapon(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Primary Weapon --");
            if (p.PrimaryWeapon == null)
            {
                Console.WriteLine(" No primary weapon equipped.");
            }
            else
            {
                Console.WriteLine($" {p.PrimaryWeapon.Name}");
            }
        }
        public void ShowEquippedGear(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Equipped Gear --");
            foreach (IEquipment item in p.EquippedGear)
            {
                if (item is IWeapon w)
                {
                    Console.WriteLine($" -{w.Name} ({w.SlotType})");
                    ShowGearBonus(item.StatMods);
                }
                else if (item is IGear g)
                {
                    Console.WriteLine($" -{g.Name} ({g.SlotType})");
                    ShowGearBonus(item.StatMods);
                    Console.WriteLine($"\t-AC ({FormatAC(g.AC)})");
                }
            }
        }
        private int FormatAC(int ac)
        {
            if(ac < 0)
            {
                ac += 10;
            }
            return ac;
        }
        private void ShowGearBonus(List<StatModifier> bonus)
        {
            foreach(StatModifier b in bonus)
            {
                Console.WriteLine("\t-{0} ({1})", b.Modifier, AbilityAdj(b.Value));
            }
        }
        public void ShowSpellBook(ICharacter p)
        {
            Console.WriteLine($"\r\n-- {p.Name}'s Spell Book --");
            Console.WriteLine("");
            foreach(ISpell spell in p.SpellBook)
            {
                Console.WriteLine($"{spell.Name} (Level {spell.Level})");
                ShowSpellSchools(spell);
                Console.WriteLine($"Range: {spell.Range.yards} {spell.Range.RangeType}");
                ShowSpellComponents(spell);
                Console.WriteLine($"Duration: {spell.Duration.DurationType}");
                Console.WriteLine($"Area Of Effect: {spell.AOE.AOESize} {spell.AOE.Ruler} {spell.AOE.Type}");
                ShowSpellSavingThrows(spell);
                Console.WriteLine($"Description: {spell.Description}");
                Console.WriteLine("");
            }
        }
        private void ShowSpellSchools(ISpell s)
        {
            List<string> resp = new List<string>();
            foreach(SpellSchool school in s.School)
            {
                resp.Add(school.ToString());
            }
            string n = string.Join(", ", resp);
            Console.WriteLine($"School: {n}");
        }
        private void ShowSpellComponents(ISpell s)
        {
            List<string> resp = new List<string>();
            foreach (SpellCompontents comp in s.Compontents)
            {
                resp.Add(comp.ToString());
            }
            string n = string.Join(", ", resp);
            Console.WriteLine($"Components: {n}");
        }
        private void ShowSpellSavingThrows(ISpell s)
        {
            List<string> resp = new List<string>();
            foreach (SavingThrowType save in s.SavingThrows)
            {
                resp.Add(save.ToString());
            }
            string n = string.Join(", ", resp);
            Console.WriteLine($"Saving Throws: {n}");
        }
    }
}
