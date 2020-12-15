# D&D 2nd Edition Engine
<div><img src='https://stargazersworld.com/wordpress/wp-content/uploads/2019/08/Advanced-Dungeons-Dragons-2e.png' width='100%' /></div>
<h1>Welcome to the D&D2E Engine</h1>
<p>A detailed and easy-to-use C# engine for game development.</p>
<h3>Creating a new PC (Player Character)</h3>
<pre>
Character Felix = new Character
{
    Name = "Felix",
    RaceType = ERaces.Human,
    ClassType = EClasses.Fighter,
    Level = 5,
    RandomizeStats = true,
};
Felix.CreateCharacter();
</pre>
<h3>Rolling Dice</h3>
<pre>
DiceRoll Dice = new DiceRoll();
var Response = Dice.Roll(amount, sides);
</pre>
<p>Amount is the amount of die, and the sides is well... how many sides the die has.</p>
<pre>
Dice.Roll(1, 20);
Is the same as rolling a 1d20
</pre>
<h3>Creating and adding items to a player</h3>
<pre>
Player Gotrek = new Player
{
    Name = "Gotrek",
    RaceType = ERaces.Dwarf,
    ClassType = EClasses.Fighter,
    Level = 5,
};
Equipment Cheese = new Equipment
{
    Type = EEquipmentType.Food,
    Name = "Cheese",
    Description = "Some slightly moldy cheese.",
    Price = { Copper = 5 }
};
Gotrek.Equipment.Add(Cheese);
</pre>
<h3>Creating / Adding Weapon</h3>
<pre>
Weapon BastardSword = new Weapon
{
    Name = "Bastard Sword",
    AttackType = EWeaponAttackType.S,
    Category = EWeaponCategory.BastardSwordTwoHanded,
    TwoHanded = true,
    Price = { Gold = 1},
    Weight = 10
};
Felix.PrimaryWeapon = BastardSword;
</pre>
