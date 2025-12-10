# 🏟️ SimArenaClient - Student Project Template

# Welcome to SimArena!
This project gives you a simple and practical way to work with a real Web API — without having to write your own HTTP-Client or handle JSON manually.

So you can focus on starting to learn **Object-Orientated Programming**!

Everything you need is already wrapped inside the `SimArenaCustomClient-Folder`, you just use the implemented methods of `spAPI` and `mpAPI` in the program.cs-file.
With such a simple start you can therefore focus entirely on programming your own logic and characters.

## How to use this?

Read and do it **step** by **step**.  
Often there are hints or mini-helpers/questions, try to read carefully.

**[💭 Think about this]** parts are optional, but these would have helped me in the beginning. Give them a try.

---

## 🧑‍🏫 Project Goals

- Get in contact with your first REST API in C# in a abstracted easy way - [API overview](#overview)
- Build and send your own classes to the API
- Work with the responses and display them onto the console (foreach() and other loops are your friend)

🪄 Afterwards, develop your own modular mini project, such as:

1. Arena Fight Simulation
2. Rogue-Lite Game
3. Text-Based RPG
4. Survival-Game
5. "Your complete other idea"

# GERALD-WEINBERGER -> Hier bitte anführen, was die mindestanforderungen sind (Wie die 3 Räume etc. bei Text-Adventure)

---

## 📂 Project Architecture Overview

Ready:
- Program.cs → entry point
- CustomClient Folder:
    - SimArenaCustomClient_SinglePlayer.cs → ready-to-use API wrapper
    - SimArenaCustomClient_MultiPlayer.cs → ready-to-use API wrapper
    - HttpHelper.cs → just a little helper, chillin and helping

Examples for you:
- YourNewFolder:
-   YourClass1.cs → first class (start here first)
-   YourClass2.cs → second class (create here, inherit from above)
-   YourClass3.cs → third class (create here, inherit from above, get all properties)

## ⚙️ Requirements

- .NET SDK 9.0 or higher
```powershell
dotnet --version
```
<a href=https://learn.microsoft.com/en-us/dotnet/core/install/windows#install-the-sdk>microsoft "Install the SDK"</a>
```powershell
winget install Microsoft.DotNet.SDK.10
```
- Windows, Linux or macOS
- GitHub (for cloning the repository)

## ⚙️ Setup Instructions

1. Clone the repository

`git clone https://github.com/JantasBantasMe/SimArena_Client.git`

2. Open the project 

Open the project folder in VisualStudio (optional in VisualStudioCode)

3. Test the API

In the `Program.cs`, you will find the first GET-request to check if the API is running.

4. Start with [Step 1 Connectivity Test](#step1)

---

# 🎓 Learning Path & Tasks

This project is structured to guide you — from simple GET requests to POST requests with different response types — all the way to creating your own version of a fun project on your own.

<a id="step1"></a>
## 🪜 Step 1 - API Connectivity Test

You can use the provided Api-method, or you can try on your own.

```
Console.WriteLine("Is the Singleplayer-API ready?");
string response = spApi.GetAlive();
Console.WriteLine(response);
Console.ReadLine();
```

Turn the GET-method into a simple **loop** to fire it as often as you like during RunTime with enter.

If you get the responses, everything works and you can start.

### 💭 Think about this

- Where did the response came from? Locally from your own machine, or from somewhere else?
- Are there more options than one, to create such loops? Try a few.
- Do you know what "runtime" is?
- Do you need STRG+C to exit, or could you build in something that handles the exit? Try it.

---

<a id="step2"></a>
## 🪜 Step 2 - First POST-request

### 🚶‍♂️ Create the class

Now create your first **class** and fill it with these properties:

```csharp
class <Your-Class-Name>
{
    string Name { get; set; }
    int Hp { get; set; }
    int AttackMin { get; set; }
    int DefenseMin { get; set; }
}
```

Make sure to use exactly these property names, because the API depends on them.

After defining the class, create (instantiate) an object of your class in your program.

### 🌐 Use the API

Take the first POST-method and fill it with your object. 

`spApi.PostFirstArena(<your class object>)`

Win against your first Straw-Puppet, here its stats:
```csharp
{
    Name = "Straw-Puppet",
    Hp = 50,
    AttackMin = 5,
    DefenseMin = 5
};
```
Hint: not 0-5 range, but raw 5 attack and 5 defense.

### 🧾 Use the response

Catch the response in a simple `string` variable and write it to the console.

### 💭 Think about this

- Why is it essential to name the properties exactly like this? What happens if it differs? Try it.
- Is it possible to fill in the properties while the code is running? Try to implement this.
- Which access-modifier could you use for your class? Which one should you use and why?
- Do you struggle as much as i did when first learning to program? → Best luck! It gets better.

---

<a id="step3"></a>
## 🪜 Step 3 - Improve/Extend your class

### 🚶‍♂️ Create the class

Lets add more functionality **without** tampering with your current class.
Create a second class and inherit from your first class. ```class2 : class1```

Add the following properties as integers:

1. AttackMax
2. DefenseMax
3. Accuracy (care, should only take 0-100!)

Hint: Accuracy = the higher the better.

### 🌐 Use the API

Take the next POST-Method and send your Character yet again into the arena.

`spApi.PostSecondArena <your class object>)`

Win against your new opponent:
```csharp
{
    Name = "Wood-Puppet",
    Hp = 50,
    AttackMin = 5,
    AttackMax = 20,
    DefenseMin = 5,
    DefenseMax = 20,
    Accuracy = 60
};
```

The arena rules are as followed:
1. Both try to attack in every round.
2. Both roll between 0-100 and try to roll under its own accuracy to successfully hit. 
3. Both roll for the Attack and Defense between each Min-Max-Value.
4. Rolled-Defense gets substracted from the enemies rolled-Attack.
5. This will be repeated till "Winner Winner Chicken Dinner" or draw after 99 lame Rounds.
  
Hint: roll above accuracy == miss


### 🧾 Use the response

Catch the response in a `List` and try to loop over it to output the response into the console.
The fighting log is safed line for line in this `List`. 

### Optional:

Implement an interactive system to create characters dynamically using constructors and attributes, so new characters can be generated at runtime without modifying the code.
Generate a minimum of 3 different characters and have them participate in the fight before you need to come back to the codebase again.

### 💭 Think about this

- While iterating the list, can you add a pause during each full round and then continue when pressing Enter? Try it.
- Is there only one way to iterate over the list? Test the possiblities to find the best.
- How often can you inherit from something? Is inheritance even possible for the constructor, or do i need to write the full constructor in each inherited class? Do i know what a constructor even is?
- Did you use an OP-character, only to stomp a wooden puppet? I did.
- Methods often require parameters, did you know you could set the requirement for your first class, but put in your second class? Try it.

---

## 🪜 Step 4 - Rock Paper Scissor / +DTO

<a id="step4"></a>
### 🚶‍♂️ Create the class

In Step 4, apply what you learned earlier by adding a third class inheriting from the second one.

In the new class, add a property named **TacticList** of type **List<string>**. This list must contain at least one tactic - many more can be added in any order.

Possible tactics and their counter: 

```
"offensive" > "balanced" > "defensive" > "offensive"
```
its written like: `"win" > "loose"`

Example:  
**Character 1** chooses `"offensive"`  
**Character 2** chooses `"defensive"`  
Since `"defensive" > "offensive"` **Character 2** receives the buff.

Example 2:  
**Character 1** chooses `"balanced"`  
**Character 2** chooses `"balanced"`  
Since `"balanced" == "balanced"` **No one** receives the buff.

This introduces a rock-paper-scissor mechanic to the arena, giving the winner a 20% buff to their rolled-attack and rolled-defense. The list is iterated cyclically, so it doesn’t matter how many tactics you prepare — once it reaches the end, it starts again from the beginning.

Win against the HexTech-Puppet, which randomly distributes 100 points:  
```csharp
{
    maxPoints = 100,
    Name = "HexTech-Puppet",
    Hp = random.maxPoints,
    AttackMin = random.maxPoints,
    AttackMax = random.maxPoints,
    DefenseMin = random.maxPoints,
    DefenseMax = random.maxPoints,
    Accuracy = random.maxPoints
};
```

### 🌐 Use the API

Take the next POST-Method and send your Character yet again into the arena.

`spApi.PostThirdArena(<your Class object>)`

### 🧾 Use the response

As before, use the response and show it in the console. 

### 💭 Think about this

- Can you implement a random character method like the HexTech-Puppet one?
- What happens if you send wrong tactics? Try it and go debug mode.

### DTO (Data-Transfer-Object) to send 2 characters

To send two characters into the arena, check out **DTOs** and figure out how to combine two classes into a single one.

Use the following property names:

1. `Character1`
2. `Character2`

PS: Dont inherit from your other classes now. You just encapsulate two classes into one, because API calls only take a **single** parameter/object.

### 🌐 Use the API

Take the next POST-Method and send your DTO with two characters into the arena.

`spApi.ThirdArena_OneVSOne(<your DTO-class object>)`

### 🧾 Use the response

As before, use the response and show it in the console. 

### 💭 Think about this

- Do you know what happens when you use "random" as the name property? Can you recreate such a function?
- Can you tamper with the response data? May break **round** for **round** with a Console.ReadLine()?
- Can you save the response in a txt-file and read from it again? And therefore create something like an "arena-history"? Try it.
- Can you come up with a SkillPoint-system Idea which is balanced and fair for multiplayer? (Tell me please, balancing is hard.)



<a id="step5"></a>
## 🪜 Step 5 - Final Singelplayer Step: 🏁

Hopefully, this project has sparked some inspiration for you so far.

After you´ve completed the test fights against random characters, it´s time to build your own creative project.
Bring your complete own idea to life, and/or use the API to create something unique and modular!

| Idea                    | Description                                                     |
| ----------------------- | --------------------------------------------------------------- |
| 🏟️ **Arena Fight**     | Let two characters enter the arena, use **polymorphism** it´s a useful concept. |
| 🎮 **Rogue-Lite**       | Enemies get stronger each round; your hero gains stats or even implement items. |
| 📜 **Text-Based RPG**   | Combine story elements with API-driven battles. What extras would you give a boss? |
| 🤖 **Random Generator** | Generate random characters and simulate battles. Kinda arleady done if you played around a bit? |
| ✨ **Your Idea** | Your own idea—better than everything listed here! |

### 🌐 Use the API

`spAPI.PostSecondArena_OneVSOne(<your class DTO-object>)`
or
`spAPI.PostThirdArena_OneVSOne(<your class DTO-object>)`
or
`create your own, better version.`

### 💭 Think about this

- What would you make better?
- Have you learned something? (I hope you did, its my first real project.)
- What you want to implement/learn next?
- What is the next project your are going to bring to life?

<a id="step6"></a>
## 🪜 Optional Step 6 - Multiplayer - skill point system:

### 🚶‍♂️ Create the class

To keep your design clean and avoid mixing responsibilities, you should define a new class specifically for the multiplayer skill-point system.

The singleplayer classes represent raw combat stats, while the multiplayer system introduces skill points, transformations, and stat derivation rules.  

Combining both into one class would blur these concerns and violate the Single Responsibility Principle. Even though you could reuse your most recent singleplayer class, it would no longer model its original purpose correctly.

Therefore, create a fresh class dedicated to the skill-point mechanic:

```csharp
class <Your-Class-Name>
{
    string Name { get; set; }
    int HpPoints { get; set; }
    int AttackMinPoints { get; set; }
    int AttackMaxPoints { get; set; }
    int DefenseMinPoints { get; set; }
    int DefenseMaxPoints { get; set; }
    int AccuracyPoints { get; set; }
    List<string> TacticList { get; set; }
}
```

### Ruleset for the Multiplayer skill points system

Your Character gets BASE-Stats seen in the matrix below in the column "BASE".  
You deploy 30 skill points to your character which gets added to the BASE-stats.

Each skill point you assign not only affects the chosen attribute, but also modifies other base stats according to the matrix below. This system is designed (i tried) to create a more balanced character base.
  
For [example](#sp-sample): +1 point in **AttackMinPoints** = +1 **HP** and +2 **AttackMin**.

For [example](#sp-sample) in text form: If you put one point into **AccuracyPoints** you really get plus 10. Or if you put one point into **DefenseMaxPoints** you really get plus 5 which is big, but you get a penalty of minus 5 to your accuracy.

The BASE value is added before any skill points, and all modifiers are cumulative per assigned point.

Hint: Accuracy is clamped between 25 to 85. So if you have 100 accuracy, you only have 85.

| Attribute             | Hp | AttackMin | AttackMax | DefenseMin | DefenseMax | Accuracy | BASE |
| --------------        | -- | --------- | --------- | ---------- | ---------- | -------- | ---- |
| **HpPoints**          | +3 |           |           |            |            |          | 30   |
| **AttackMinPoints**   | +1 | +2        |           |            |            |          | 1    |
| **AttackMaxPoints**   |    |           | +5        |            |            | −5       | 10   |
| **DefenseMinPoints**  | +1 |           |           | +2         |            | 0        |      |
| **DefenseMaxPoints**  |    |           |           |            | +5         | −5       | 10   |
| **AccuracyPoints**    |    |           |           |            |            | +10      | 40   |

<a id="sp-sample"></a>
Sample Character: 30 Points:
```csharp
{
    Name = "random",
    Hp = 5,
    AttackMin = 5,
    AttackMax = 5,
    DefenseMin = 5,
    DefenseMax = 5,
    Accuracy = 5
};
```

will be the following character: (BASE-Stats + skill points)
```csharp
{
    Name = "random",
    Hp = 55,
    AttackMin = 11,
    AttackMax = 35,
    DefenseMin = 10,
    DefenseMax = 35,
    Accuracy = 40
};
```

CHALLENGE your friends!

### 🌐 Use the API

Get a free arena:
`mpApi.GetNewArena())`

Send your character to the arena:
`mpApi.SendCharacter(<your character object>, arenaId)`

After two characters were sent to the arena, they challenge each other.
Get the result:
`mpApi.GetFightingResult(arenaId)`

### 🧾 Use the response

Catch the response as before and write it to the console. This should already work at this point.

### 💭 Think about this

- Optional: Can you rewrite the custom client to function in async? Like it should normally be.
- Do you know what scalar is? Do you know what OpenAPI is? Try to explain them on paper and then check it.
- Do you know more than GET and POST? → NO? → go and learn?
- Do you like the system? 
    → NO? :( → create your own-better version and please give feedback what could be better.
    → YES? :) → Thanks i learnt much with this and refactored like 100 times.


### Optional: 

Play around and trigger some Errors if there were non triggered by now. 
Example: Make very long names, or huge numbers. Or hack the whole thing? Something like that.

---

<a id="overview"></a>
# 🌐 API Overview

API documentation = <a href=https://simarena-ahasg3auane8dhe0.germanywestcentral-01.azurewebsites.net/scalar> Scalar-OpenApi </a>

## Singleplayer API
| Method Name                  | Signature                                        | Endpoint                                                                           | Return Type    | Description                                 |
| ---------------------------- | ------------------------------------------------ | ---------------------------------------------------------------------------------- | -------------- | ------------------------------------------- |
| `GetAlive()`                 | `()`                                             | `/SinglePlayer/Alive`                                                              | `string`       | Checks if the API is available              |
| `PostFirstArena()`           | `(characterInstance)`                            | `/SinglePlayer/FirstArena`                                                         | `string`       | Simple flat-damage fight                    |
| `PostSecondArena()`          | `(characterInstance)`                            | `/SinglePlayer/SecondArena`                                                        | `List<string>` | Fight with accuracy and stat ranges         |
| `PostSecondArena_OneVSOne()` | `(2characterInstanceDTO)` | `/SinglePlayer/SecondArena-1vs1`                                                   | `List<string>` | Two custom characters fight each other      |
| `PostThirdArena()`           | `(characterInstance)`                            | `/SinglePlayer/ThirdArena`                                                         | `List<string>` | Fight a random enemy with tactical options  |
| `PostThirdArena_OneVSOne()`  | `(2characterInstanceDTO)` | `/SinglePlayer/ThirdArena-1vs1`                                                    | `List<string>` | Two custom characters, full tactical system |
---

One multiplayer-endpoint is not implemented in the custom client. Can you find and implement it in the client?

## Multiplayer API
| Method Name                   | Signature                      | Endpoint                                                                           | Return Type    | Description                                     |
| ----------------------------- | ------------------------------ | ---------------------------------------------------------------------------------- | -------------- | ----------------------------------------------- |
| `GetAlive()`                  | `()`                           | `/Multiplayer/Alive`                                                               | `string`       | Checks if the API is available                  |
| `GetRandomCharAsJsonString()` | `(maxPoints)`                  | `/Multiplayer/get-random-skillpoint-character`                                     | `string`       | Returns a random character JSON string          |
| `GetFightingResult()`         | `(arenaId)`                    | `/Multiplayer/get-fight-from-arena/{arenaId}`                                      | `List<string>` | Retrieves the stored fight log                  |
| `GetNewArena()`               | `()`                           | `/Multiplayer/reserve-new-arenaId`                                                 | `int`          | Reserves a new arenaId slot                     |
| `SendCharacter()`             | `(characterInstance, arenaId)` | `/Multiplayer/send-character-to-arena/{arenaId}`                                   | `string`       | Sends a character into the arena                |
| `RandomTestFight()`           | `(characterInstance, arenaId)` | `/Multiplayer/fight-a-random-testcharacter/{arenaId}`                              | `string`       | Fights a random character and stores the result |
---

# 🐸 PS: 

I hope the project is understanable and helpful for the start of learning how to code and how to use OOP.  
This should give you a perspective how to start into OOP and afterwards find something to explore by yourself.
It is intentionally kept very simple, and I welcome any feedback for improvements.