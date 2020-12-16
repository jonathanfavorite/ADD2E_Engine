using System;
using System.Collections.Generic;
using System.Text;
using ADD2E_Core.Models;
namespace ADD2E_Core.Services
{
    public class AbilityScoreManager
    {
        #region Strength
        public Strength SetStrength(int AbilityScore)
        {
            return StrengthRules().Find(strength => strength.Value == AbilityScore);
        }
        private List<Strength> StrengthRules()
        {
            var returnedList = new List<Strength>
            {
                new Strength { Value = 1, HitProb = -5, DamageAdjustment = -4, MaxPress = 3, OpenDoors = 1, BendBarsPercentage = 0 },
                new Strength { Value = 2, HitProb = -3, DamageAdjustment = -2, MaxPress = 5, OpenDoors = 1, BendBarsPercentage = 0 },
                new Strength { Value = 3, HitProb = -3, DamageAdjustment = -1, MaxPress = 10, OpenDoors = 2, BendBarsPercentage = 0 },
                new Strength { Value = 4, HitProb = -2, DamageAdjustment = -1, MaxPress = 25, OpenDoors = 3, BendBarsPercentage = 0 },
                new Strength { Value = 5, HitProb = -2, DamageAdjustment = -1, MaxPress = 25, OpenDoors = 3, BendBarsPercentage = 0 },
                new Strength { Value = 6, HitProb = -1, DamageAdjustment = 0, MaxPress = 55, OpenDoors = 4, BendBarsPercentage = 0 },
                new Strength { Value = 7, HitProb = -1, DamageAdjustment = 0, MaxPress = 55, OpenDoors = 4, BendBarsPercentage = 0 },
                new Strength { Value = 8, HitProb = 0, DamageAdjustment = 0, MaxPress = 90, OpenDoors = 5, BendBarsPercentage = 0.01 },
                new Strength { Value = 9, HitProb = 0, DamageAdjustment = 0, MaxPress = 90, OpenDoors = 5, BendBarsPercentage = 0.01 },
                new Strength { Value = 10, HitProb = 0, DamageAdjustment = 0, MaxPress = 115, OpenDoors = 6, BendBarsPercentage = 0.02 },
                new Strength { Value = 11, HitProb = 0, DamageAdjustment = 0, MaxPress = 115, OpenDoors = 6, BendBarsPercentage = 0.02 },
                new Strength { Value = 12, HitProb = 0, DamageAdjustment = 0, MaxPress = 140, OpenDoors = 7, BendBarsPercentage = 0.04 },
                new Strength { Value = 13, HitProb = 0, DamageAdjustment = 0, MaxPress = 140, OpenDoors = 7, BendBarsPercentage = 0.04 },
                new Strength { Value = 14, HitProb = 0, DamageAdjustment = 0, MaxPress = 170, OpenDoors = 8, BendBarsPercentage = 0.07 },
                new Strength { Value = 15, HitProb = 0, DamageAdjustment = 0, MaxPress = 170, OpenDoors = 8, BendBarsPercentage = 0.07 },
                new Strength { Value = 16, HitProb = 0, DamageAdjustment = 1, MaxPress = 195, OpenDoors = 9, BendBarsPercentage = 0.10 },
                new Strength { Value = 17, HitProb = 1, DamageAdjustment = 1, MaxPress = 220, OpenDoors = 10, BendBarsPercentage = 0.13 },
                new Strength { Value = 18, HitProb = 1, DamageAdjustment = 2, MaxPress = 255, OpenDoors = 11, BendBarsPercentage = 0.16 }
            };
            return returnedList;
        }
        #endregion

        #region Dexterity
        public Dexterity SetDexterity(int AbilityScore)
        {
            return DexterityRules().Find(dexterity => dexterity.Value == AbilityScore);
        }
        private List<Dexterity> DexterityRules()
        {
            var returnedList = new List<Dexterity>
            {
                new Dexterity { Value = 1, ReactionAdjustment = -6, MissleAttackAdjustment = -6, DefenceAdjustment = 5 },
                new Dexterity { Value = 2, ReactionAdjustment = -4, MissleAttackAdjustment = -6, DefenceAdjustment = 5 },
                new Dexterity { Value = 3, ReactionAdjustment = -3, MissleAttackAdjustment = -3, DefenceAdjustment = 4 },
                new Dexterity { Value = 4, ReactionAdjustment = -2, MissleAttackAdjustment = -2, DefenceAdjustment = 3 },
                new Dexterity { Value = 5, ReactionAdjustment = -1, MissleAttackAdjustment = -1, DefenceAdjustment = 2 },
                new Dexterity { Value = 6, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 1 },
                new Dexterity { Value = 7, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 8, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 9, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 10, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 11, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 12, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 13, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 14, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = 0 },
                new Dexterity { Value = 15, ReactionAdjustment = 0, MissleAttackAdjustment = 0, DefenceAdjustment = -1 },
                new Dexterity { Value = 16, ReactionAdjustment = 1, MissleAttackAdjustment = 1, DefenceAdjustment = -2 },
                new Dexterity { Value = 17, ReactionAdjustment = 2, MissleAttackAdjustment = 2, DefenceAdjustment = -3 },
                new Dexterity { Value = 18, ReactionAdjustment = 2, MissleAttackAdjustment = 2, DefenceAdjustment = -4 }
            };
            return returnedList;
        }
        #endregion

        #region Constitution
        public Constitution SetConstitution(int AbilityScore)
        {
            return ConstitutionRules().Find(constitution => constitution.Value == AbilityScore);
        }
        private List<Constitution> ConstitutionRules()
        {
            var returnedList = new List<Constitution>
            {
                new Constitution { Value = 1, HitPointAdjustment = -3, SystemShockPercentage = 0.25, ResurrectionSurvivalPercentage = 0.30, PoisionSave = -2 },
                new Constitution { Value = 2, HitPointAdjustment = -2, SystemShockPercentage = 0.30, ResurrectionSurvivalPercentage = 0.35, PoisionSave = 0 },
                new Constitution { Value = 3, HitPointAdjustment = -2, SystemShockPercentage = 0.35, ResurrectionSurvivalPercentage = 0.40, PoisionSave = 0 },
                new Constitution { Value = 4, HitPointAdjustment = -1, SystemShockPercentage = 0.40, ResurrectionSurvivalPercentage = 0.45, PoisionSave = 0 },
                new Constitution { Value = 5, HitPointAdjustment = -1, SystemShockPercentage = 0.45, ResurrectionSurvivalPercentage = 0.50, PoisionSave = 0 },
                new Constitution { Value = 6, HitPointAdjustment = -1, SystemShockPercentage = 0.50, ResurrectionSurvivalPercentage = 0.55, PoisionSave = 0 },
                new Constitution { Value = 7, HitPointAdjustment = 0, SystemShockPercentage = 0.55, ResurrectionSurvivalPercentage = 0.60, PoisionSave = 0 },
                new Constitution { Value = 8, HitPointAdjustment = 0, SystemShockPercentage = 0.60, ResurrectionSurvivalPercentage = 0.65, PoisionSave = 0 },
                new Constitution { Value = 9, HitPointAdjustment = 0, SystemShockPercentage = 0.65, ResurrectionSurvivalPercentage = 0.70, PoisionSave = 0 },
                new Constitution { Value = 10, HitPointAdjustment = 0, SystemShockPercentage = 0.70, ResurrectionSurvivalPercentage = 0.75, PoisionSave = 0 },
                new Constitution { Value = 11, HitPointAdjustment = 0, SystemShockPercentage = 0.75, ResurrectionSurvivalPercentage = 0.80, PoisionSave = 0 },
                new Constitution { Value = 12, HitPointAdjustment = 0, SystemShockPercentage = 0.80, ResurrectionSurvivalPercentage = 0.85, PoisionSave = 0 },
                new Constitution { Value = 13, HitPointAdjustment = 0, SystemShockPercentage = 0.85, ResurrectionSurvivalPercentage = 0.90, PoisionSave = 0 },
                new Constitution { Value = 14, HitPointAdjustment = 0, SystemShockPercentage = 0.88, ResurrectionSurvivalPercentage = 0.92, PoisionSave = 0 },
                new Constitution { Value = 15, HitPointAdjustment = 1, SystemShockPercentage = 0.90, ResurrectionSurvivalPercentage = 0.94, PoisionSave = 0 },
                new Constitution { Value = 16, HitPointAdjustment = 2, SystemShockPercentage = 0.95, ResurrectionSurvivalPercentage = 0.96, PoisionSave = 0},
                new Constitution { Value = 17, HitPointAdjustment = 2, WarriorsHPBonus = 3, SystemShockPercentage = 0.98, ResurrectionSurvivalPercentage = 0.3, PoisionSave = 0 },
                new Constitution { Value = 18, HitPointAdjustment = 2, WarriorsHPBonus = 4, SystemShockPercentage = 1.00, ResurrectionSurvivalPercentage = 0.3, PoisionSave = 0 }
            };
            return returnedList;
        }
        #endregion

        #region Intelligence
        public Intelligence SetIntelligence(int AbilityScore)
        {
            return IntelligenceRules().Find(intelligence => intelligence.Value == AbilityScore);
        }
        private List<Intelligence> IntelligenceRules()
        {
            var returnedList = new List<Intelligence>
            {
                new Intelligence { Value = 1, LanguagesKnown = 0, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 2, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 3, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 4, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 5, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 6, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 7, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 8, LanguagesKnown = 1, SpellLevel = 0, ChanceToLearnSpellPercentage = 0, MaxNumberOfSpells = 0},
                new Intelligence { Value = 9, LanguagesKnown = 2, SpellLevel = 4, ChanceToLearnSpellPercentage = 0.35, MaxNumberOfSpells = 6},
                new Intelligence { Value = 10, LanguagesKnown = 2, SpellLevel = 5, ChanceToLearnSpellPercentage = 0.40, MaxNumberOfSpells = 7},
                new Intelligence { Value = 11, LanguagesKnown = 2, SpellLevel = 5, ChanceToLearnSpellPercentage = 0.45, MaxNumberOfSpells = 7},
                new Intelligence { Value = 12, LanguagesKnown = 3, SpellLevel = 6, ChanceToLearnSpellPercentage = 0.50, MaxNumberOfSpells = 7},
                new Intelligence { Value = 13, LanguagesKnown = 3, SpellLevel = 6, ChanceToLearnSpellPercentage = 0.55, MaxNumberOfSpells = 9},
                new Intelligence { Value = 14, LanguagesKnown = 4, SpellLevel = 7, ChanceToLearnSpellPercentage = 0.60, MaxNumberOfSpells = 9},
                new Intelligence { Value = 15, LanguagesKnown = 4, SpellLevel = 7, ChanceToLearnSpellPercentage = 0.65, MaxNumberOfSpells = 11},
                new Intelligence { Value = 16, LanguagesKnown = 5, SpellLevel = 8, ChanceToLearnSpellPercentage = 0.70, MaxNumberOfSpells = 11},
                new Intelligence { Value = 17, LanguagesKnown = 6, SpellLevel = 8, ChanceToLearnSpellPercentage = 0.75, MaxNumberOfSpells = 14},
                new Intelligence { Value = 18, LanguagesKnown = 7, SpellLevel = 9, ChanceToLearnSpellPercentage = 0.85, MaxNumberOfSpells = 18}
            };
            return returnedList;
        }
        #endregion

        #region Wisdom
        public Wisdom SetWisdom(int AbilityScore)
        {
            return WisdomRules().Find(wisdom => wisdom.Value == AbilityScore);
        }
        private List<Wisdom> WisdomRules()
        {
            var returnedList = new List<Wisdom>
            {
                new Wisdom { Value = 1, MagicalDefenceAdjustment = -6, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.80 },
                new Wisdom { Value = 2, MagicalDefenceAdjustment = -4, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.60 },
                new Wisdom { Value = 3, MagicalDefenceAdjustment = -3, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.50 },
                new Wisdom { Value = 4, MagicalDefenceAdjustment = -2, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.45 },
                new Wisdom { Value = 5, MagicalDefenceAdjustment = -1, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.40 },
                new Wisdom { Value = 6, MagicalDefenceAdjustment = -1, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.35 },
                new Wisdom { Value = 7, MagicalDefenceAdjustment = -1, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.30 },
                new Wisdom { Value = 8, MagicalDefenceAdjustment = 0, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.25},
                new Wisdom { Value = 9, MagicalDefenceAdjustment = 0, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.20 },
                new Wisdom { Value = 10, MagicalDefenceAdjustment = 0, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.15 },
                new Wisdom { Value = 11, MagicalDefenceAdjustment = 0, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.10 },
                new Wisdom { Value = 12, MagicalDefenceAdjustment = 0, BonusSpells = 0, ChanceOfSpellFailPercentage = 0.5 },
                new Wisdom { Value = 13, MagicalDefenceAdjustment = 0, BonusSpells = 1, ChanceOfSpellFailPercentage = 0 },
                new Wisdom { Value = 14, MagicalDefenceAdjustment = 0, BonusSpells = 1, ChanceOfSpellFailPercentage = 0 },
                new Wisdom { Value = 15, MagicalDefenceAdjustment = 1, BonusSpells = 2, ChanceOfSpellFailPercentage = 0 },
                new Wisdom { Value = 16, MagicalDefenceAdjustment = 2, BonusSpells = 2, ChanceOfSpellFailPercentage = 0 },
                new Wisdom { Value = 17, MagicalDefenceAdjustment = 3, BonusSpells = 3, ChanceOfSpellFailPercentage = 0 },
                new Wisdom { Value = 18, MagicalDefenceAdjustment = 4, BonusSpells = 4, ChanceOfSpellFailPercentage = 0 },
            };
            return returnedList;
        }
        #endregion

        #region Charisma
        public Charisma SetCharisma(int AbilityScore)
        {
            return CharismaRules().Find(charisma => charisma.Value == AbilityScore);
        }
        private List<Charisma> CharismaRules()
        {
            var returnedList = new List<Charisma>
            {
                new Charisma { Value = 1, MaximumHenchmen = 0, LoyaltyBase = -8, ReactionAdjustment = -7 },
                new Charisma { Value = 2, MaximumHenchmen = 1, LoyaltyBase = -7, ReactionAdjustment = -6 },
                new Charisma { Value = 3, MaximumHenchmen = 1, LoyaltyBase = -6, ReactionAdjustment = -5 },
                new Charisma { Value = 4, MaximumHenchmen = 1, LoyaltyBase = -5, ReactionAdjustment = -4 },
                new Charisma { Value = 5, MaximumHenchmen = 2, LoyaltyBase = -8, ReactionAdjustment = -3 },
                new Charisma { Value = 6, MaximumHenchmen = 2, LoyaltyBase = -3, ReactionAdjustment = -2 },
                new Charisma { Value = 7, MaximumHenchmen = 3, LoyaltyBase = -2, ReactionAdjustment = -1 },
                new Charisma { Value = 8, MaximumHenchmen = 3, LoyaltyBase = -1, ReactionAdjustment = 0 },
                new Charisma { Value = 9, MaximumHenchmen = 4, LoyaltyBase = 0, ReactionAdjustment = 0 },
                new Charisma { Value = 10, MaximumHenchmen = 4, LoyaltyBase = 0, ReactionAdjustment = 0 },
                new Charisma { Value = 11, MaximumHenchmen = 4, LoyaltyBase = 0, ReactionAdjustment = 0 },
                new Charisma { Value = 12, MaximumHenchmen = 5, LoyaltyBase = 0, ReactionAdjustment = 0 },
                new Charisma { Value = 13, MaximumHenchmen = 5, LoyaltyBase = 0, ReactionAdjustment = 1 },
                new Charisma { Value = 14, MaximumHenchmen = 6, LoyaltyBase = 1, ReactionAdjustment = 2 },
                new Charisma { Value = 15, MaximumHenchmen = 7, LoyaltyBase = 3, ReactionAdjustment = 3 },
                new Charisma { Value = 16, MaximumHenchmen = 8, LoyaltyBase = 4, ReactionAdjustment = 5 },
                new Charisma { Value = 17, MaximumHenchmen = 10, LoyaltyBase = 6, ReactionAdjustment = 6 },
                new Charisma { Value = 18, MaximumHenchmen = 15, LoyaltyBase = 8, ReactionAdjustment = 7 },

            };
            return returnedList;
        }
        #endregion
    }
}
