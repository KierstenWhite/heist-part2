using System;
using System.Collections.Generic;

/*In the Main method, create a List<IRobber> and store it in a variable named rolodex. 
This list will contain all possible operatives that we could employ for future heists. 
We want to give the user the opportunity to add new operatives to this list, but for now 
let's pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).*/
List<IRobber> rolodex = new List<IRobber>()
{
    new Hacker(){
        Name = "Sally",
        SkillLevel = 45,
        PercentageCut = 25
    },
    new LockSpecialist(){
        Name = "Boris",
        SkillLevel = 67,
        PercentageCut = 50
    },
    new Muscle(){
        Name = "Zenon",
        SkillLevel = 32,
        PercentageCut = 46
    },
    new Hacker(){
        Name = "Dimitri",
        SkillLevel = 76,
        PercentageCut = 25
    },
    new LockSpecialist(){
        Name = "Nora",
        SkillLevel = 23,
        PercentageCut = 77
    },
    new Muscle(){
        Name = "Prudence",
        SkillLevel = 62,
        PercentageCut = 12
    }
};

Console.WriteLine("Welcome to Heist Part Two!");

//When the program starts, print out the number of current operatives in the rolodex. 
int RolodexListCount = rolodex.Count;
Console.WriteLine($"There are currently {RolodexListCount} robbers in your rolodex.");

// /Continue the above action and allow the user to enter as many crew members as they like to the rolodex
//until they enter a blank name before continuing.
while (true)
{
    //Then prompt the user to enter the name of a new possible crew member. 
    Console.WriteLine("Enter the name of a potential new crew member:");
    string potentialNewMemberName = Console.ReadLine();
    if (string.IsNullOrEmpty(potentialNewMemberName))
        break;

    /*
    Once the user has entered a name, print out a list of possible specialties and have the user select
    which specialty this operative has. The list should contain the following options
        - Hacker (Disables alarms)
        - Muscle (Disarms guards)
        - Lock Specialist (cracks vault)
    */
    Console.WriteLine("Which specialty does this person have?");
    Console.WriteLine("Press 1 for Hacker, Press 2 for Muscle, Press 3 for Lock Specialist");
    string userInputtedSpecialty = Console.ReadLine();
    int parseduserInputtedSpecialty = int.Parse(userInputtedSpecialty);

    //Once the user has selected a specialty, prompt them to enter the crew member's skill level as an integer between 1 and 100.
    Console.WriteLine("Great! Enter the criminal's skill level as an integer between 1-100.");
    string userInputtedSkillLevel = Console.ReadLine();
    int parseduserInputtedSkillLevel = int.Parse(userInputtedSkillLevel);

    //Then prompt the user to enter the percentage cut the crew member demands for each mission.
    Console.WriteLine("Now, how much of a cut does the criminal get for helping with this mission? Enter a percentage");
    string userInputtedPercentage = Console.ReadLine();
    int parsedUserInputtedPercentage = int.Parse(userInputtedPercentage);

    //Once the user has entered the crew member's name, specialty, skill level,
    //and cut, you should instantiate the appropriate class for that crew member (based on their specialty)
    if (parseduserInputtedSpecialty == 1)
    {
        Hacker hacker = new Hacker
        {
            Name = potentialNewMemberName,
            SkillLevel = parseduserInputtedSkillLevel,
            PercentageCut = parsedUserInputtedPercentage
        };
        rolodex.Add(hacker);
    }
    if (parseduserInputtedSpecialty == 2)
    {
        LockSpecialist lockSpecialist = new LockSpecialist
        {
            Name = potentialNewMemberName,
            SkillLevel = parseduserInputtedSkillLevel,
            PercentageCut = parsedUserInputtedPercentage
        };
        rolodex.Add(lockSpecialist);
    }
    else if (parseduserInputtedSpecialty == 3)
    {
        Muscle muscle = new Muscle
        {
            Name = potentialNewMemberName,
            SkillLevel = parseduserInputtedSkillLevel,
            PercentageCut = parsedUserInputtedPercentage
        };
        rolodex.Add(muscle);
    }
}
//and they should be added to the rolodex.
int newRolodexCount = rolodex.Count;
Console.WriteLine($"There are currently {newRolodexCount} robbers in your rolodex.");

/*
The program should create a new bank object and randomly assign values for these properties:

    - AlarmScore (between 0 and 100)
    - VaultScore (between 0 and 100)
    - SecurityGuardScore (between 0 and 100)
    - CashOnHand (between 50,000 and 1 million)
*/
int randomAlarmScore = new Random().Next(0, 100);
int randomVaultScore = new Random().Next(0, 100);
int randomSecurityGuardScore = new Random().Next(0, 100);
int randomCashOnHand = new Random().Next(50000, 1000000);

Bank bank = new Bank
{
    CashOnHand = randomCashOnHand,
    AlarmScore = randomAlarmScore,
    SecurityGuardScore = randomSecurityGuardScore,
    VaultScore = randomVaultScore
};

string mostSecureSystem = "";
int highestScore = 0;

if (bank.AlarmScore > highestScore)
{
    mostSecureSystem = "Alarm";
    highestScore = bank.AlarmScore;
}
if (bank.SecurityGuardScore > highestScore)
{
    mostSecureSystem = "Security Guard";
    highestScore = bank.SecurityGuardScore;
}
if (bank.VaultScore > highestScore)
{
    mostSecureSystem = "Vault";
    highestScore = bank.VaultScore;
}

string leastSecureSystem = "";
int lowestScore = int.MaxValue;

if (bank.AlarmScore < lowestScore)
{
    leastSecureSystem = "Alarm";
    lowestScore = bank.AlarmScore;
}
if (bank.SecurityGuardScore < lowestScore)
{
    leastSecureSystem = "Security Guard";
    lowestScore = bank.SecurityGuardScore;
}
if (bank.VaultScore < lowestScore)
{
    leastSecureSystem = "Vault";
    lowestScore = bank.VaultScore;
}
/*
    Let's do a little recon next. Print out a Recon Report to the user. This should tell the user what the
    bank's most secure system is, and what its least secure system is (don't print the actual integer scores-
    just the name, i.e. Most Secure: Alarm Least Secure: Vault
*/

Console.WriteLine($"Recon Report: This bank's most secure system is {mostSecureSystem}, and it's least secure system is {leastSecureSystem}.");
Console.WriteLine("");

//Prompt the user to enter the index of the operative they'd like to include in the heist.
Console.WriteLine("Press the criminal's number to add them to the list.");
Console.WriteLine("");

//Create a new List<IRobber> and store it in a variable called crew. 
List<IRobber> crew = new List<IRobber>();
int totalCut = 0;

//Allow the user to select as many crew members as they'd like from the rolodex.
while (true)
{

    //Print out a report of the rolodex that includes each person's name, specialty, skill level, and cut.
    //Include an index in the report for each operative so that the user can select them by that index in the next
    //step. (You may want to update the IRobber interface and/or the implementing classes to be able to print out the specialty)

    for (int i = 0; i < rolodex.Count; i++)
    {
        //Continue to print out the report after each crew member is selected, but the report should 
        //not include operatives that have already been added to the crew, or operatives that require a percentage cut that can't be offered.
        if (!crew.Contains(rolodex[i]) && (rolodex[i].PercentageCut + totalCut) < 100)
        {


            Console.WriteLine($"Criminal #{i + 1}. {rolodex[i].Name}, {rolodex[i].Type}: Skill Level: {rolodex[i].SkillLevel} | Percentage Cut: {rolodex[i].PercentageCut}");

        }

        Console.WriteLine("Select a member or press enter to start the Heist:");
    }

    string selection = Console.ReadLine();
    //Once the user enters a blank value for a crew member, we're ready to begin the heist.
    if (selection == "")
    {
        break;
    }

    //Once the user selects an operative, add them to the crew list.
    crew.Add(rolodex[int.Parse(selection) - 1]);
    totalCut = crew.Sum(x => x.PercentageCut);

    Console.WriteLine(totalCut);
}

//Each crew member should perform his/her skill on the bank. Afterwards, evaluate if the bank is secure. If not, the heist was a success! 
//Print out a success message to the user. If the bank does still have positive values for any of its security properties,
//the heist was a failure. Print out a failure message to the user.

foreach (IRobber member in crew)
{
    member.PerformSkill(bank);
}

if (bank.IsSecure())
{
    Console.WriteLine("The heist was a failure.");
}
else
{
    Console.WriteLine("The heist was a success.");

    //If the heist was a success, print out a report of each members' take, along with how much money is left for yourself.
    int myCut = 100 - crew.Sum(x => x.PercentageCut);
    crew.ForEach(x => Console.WriteLine($"Well Done. {x.Name}. Your take is {(bank.CashOnHand * x.PercentageCut) / 100}"));
    Console.WriteLine($"Our take is {(bank.CashOnHand * myCut) / 100}");
}