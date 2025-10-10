// For the exceeding requirements I added a leveling system to help gamify the goals. 
// Each time the player earns points, it checks to see if the have reached the next level, the prints a message telling them
// they leveled up. Then it adds 500 more points to the current score for the next level up. 

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
        manager.LoadGoals();
        manager.ListGoalDetails();
    }
}