# D&D 2nd Edition Engine
<div><img src='https://stargazersworld.com/wordpress/wp-content/uploads/2019/08/Advanced-Dungeons-Dragons-2e.png' width='100%' /></div>
<h1>Welcome to the D&D2E Engine</h1>
<p>A detailed and easy-to-use C# engine for game development.</p>
<h3>Creating a new PC (Player Character)</h3>
<pre>
Player Felix = new Player
{
    Name = "Felix",
    RaceType = ERaces.Human,
    OwnerName = "Jonathan",
    ClassType = EClasses.Fighter,
    Level = 1,
};
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
