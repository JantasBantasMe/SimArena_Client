# 🏟️ SimArenaClient - Student Project Template

# Welcome to SimArena!
This project gives you a simple and practical way to work with a real Web API — without having to write your own HTTP-Client or handle JSON manually. So you can focus on learning **Object-Orientated Programming**!

Everything you need is already wrapped inside the `SimArenaCustomClient`, you can use the implemented methods.
You have a simple start, and can therefore focus entirely on programming your own logic and characters.

## How to use? 

Read and do it **step** by **step**.

---

## 🧑‍🏫 Project Goals

- Learn how to use a REST API in C# in a abstracted easy way
- Build and send your own character classes, or whatever you call them
- Work with API responses and display fight results (foreach() is a friend)

🪄 Afterwards, develop your own modular mini project, such as:

1. Arena Fight Simulation
2. Rogue-Lite Game
3. Text-Based RPG

---

## 📂 Project Architecture Overview

Ready:
- Program.cs → entry point with sample API call
- SimArenaCustomClient.cs → ready-to-use API wrapper

Examples for you:
- YourNewFolder:
-   YourClass1.cs → first class (start here first)
-   YourClass2.cs → second class (create here, inherit from above)
-   YourClass3.cs → third class (create here, inherit from above, get all properties)

## ⚙️ Setup Instructions

1. Clone the repository

`git clone https://github.com/JantasBantasMe/SimArena_Client.git`

2. Open the project 

Open the project folder in VisualStudio (optional in VisualStudioCode)

3. Test the API

In the `Program.cs`, you will find the first GET-request to check if the API is running.

---

# 🎓 Learning Path & Tasks

This Project is structured to to guide you -- from simple GET-requests to POST-requests with 2 different response types -- to creating your own Version of a Fun Project.

## 🪜 Step 1 - API Connectivity Test

Use the provided Method and turn it into a simple **loop** to fire it as often as you like during RunTime.

```
SimArenaCustomClient API = new SimArenaCustomClient();

string result = API.GetAlive();
Console.WriteLine(result);
```

If you get the response, everything works and you can start.

### 💭 Think about this

- Do I understand sending and receiving variables like that?
- Are there more options than one, to create such loops?
- Do I know what RunTime is?

---

## 🪜 Step 2 - First own POST-request

### 🚶‍♂️ Create the class

Now create your first class and fill it with these properties:

public class Class-Name-Get-Creative
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int AttackMin { get; set; }
    public int DefenseMin { get; set; }
}

The class name is free to choose, but care to name the properties **exactly** like showed above.

Instantiate your new Class in the Program.cs and safe it to a variable to be able to send it.

### 🌐 Use the API

Take the first POST-method and fill it with your character. 

`API.PostFirstFight(<your class instance>)`

Win against your first enemy, here its stats:
{
    Name = "Straw-Puppet",
    Hp = 50,
    AttackMin = 5,
    DefenseMin = 5
};

### 🧾 Use the response

Catch the response in a simple `string` variable and write it to the console.

### 💭 Think about this

- Did I really just used a real API in the internet? (Spoiler, yes.)
- Is it possible to fill in the variables while the code is running?
- Do I struggle as hard as the producer of this Guide in the beginning → I hope you dont, best luck!

---

## 🪜 Step 3 - Improve your class

### 🚶‍♂️ Create the class

Lets add more functionality WITHOUT tampering with your current class.
Create a second class and try to inherit from your first class.

Add the following properties to enhance your class:

1. AttackMax
2. DefenseMax
3. Accuracy (care, only takes 0-100)

### 🌐 Use the API

Take the second POST-Method and send your Character yet again into the arena.

`API.PostSecondFight(<your class instance>)`

Win against your second enemy:
```json
{
    Name = "Wood-Puppet",
    Hp = 50,
    AttackMin = 5,
    AttackMax = 20,
    DefenseMin = 5,
    DefenseMax = 20,
    Accuracy = 40
};
```

The rules are as followed:
1. Both hit in every round, no turn base.
2. Both roll between 0-100 and try to roll under its own Accuracy to hit.
3. Both roll for Attack and Defense between Min-Max-Value.
4. Rolled Defense gets substracted from enemies rolled Attack.
5. Repeat till "Winner Winner Chicken Dinner" (Or after 99 Rounds)

### 🧾 Use the response

Catch the response in a `List` and try to loop over it to output the response into the console.
The fighting log is safed line for line in this `List`. 

### Optional:

Create a Constructor in your classes and try to implement a "command-line-creation-tool", where you can generate different characters like a "Knight", "Fighter", "Asassine" or a "Princess" while the code is running.

With something like this, you dont need to change the character in Code, but during Runtime.

### 💭 Think about this

- Isn't inheritance nice? Is inheritance even possible for the constructor?
- In Step 2, did I think about why its called AttackMin and DefenseMin?
- Is the "Wood-Puppet" even a real enemie for me? Or do I need stronger ones?

---

## 🪜 Step 4 - Rock Paper Sissor / skill point system:

### 🚶‍♂️ Create the class

In Step 4 repeat the learned things in the steps before by adding a 3rd class and inherit from the 2nd one.

In the new class add a property named "AttackList" as a List<string> variable and fill it with attacks in your wanted order.

Possible attacks and their counter:
"offensive" > "balanced" > "defensive" > "offensive"

This will bring a Rock-Paper-Sissor element to the fight and the winner will get a 20% buff on the rolled attack and defense. The list will be iterated, so it doesnt matter how many attacks you prepare, when the list ends, it begins from the start.

### Ruleset for the System

*TLDR: Just use a list with the above mentioned tactics and deploy 30 skill points to your character and see what happens*

skill point system: Your Character gets BASE-Stats, you deploy 30 skill points to your character which gets added to the BASE-stats. To not limit you from the beginning, its a soft cap and therefore you could deploy more than 30. Its up to you to implement a validation, where its no longer possible in your code to deploy more than 30 Points.

Each skill point you assign not only affects the chosen attribute, but also modifies other base stats according to the matrix below. This system is designed (i tried) to create a more balanced character base.
For example: +1 skill point put in **AttackMin**, gives +1 **HP** and +2 **AttackMin**.

The BASE value is added before any skill points, and all modifiers are cumulative per assigned point.


| Attribute      | Hp | AttackMin | AttackMax | DefenseMin | DefenseMax | Accuracy | BASE |
| -------------- | -- | --------- | --------- | ---------- | ---------- | -------- | ---- |
| **Hp**         | +3 |           |           |            |            |          | 30   |
| **AttackMin**  | +1 | +2        |           |            |            |          | 1    |
| **AttackMax**  |    |           | +5        |            |            | −5       | 10   |
| **DefenseMin** | +1 |           |           | +2         |            | 0        |      |
| **DefenseMax** |    |           |           |            | +5         | −5       | 10   |
| **Accuracy**   |    |           |           |            |            | +10      | 40   |

Sample Character: 30 Points:
```json
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

will be the following character:
```json
{
    Name = "Thorin Ironfist",
    Hp = 55,
    AttackMin = 11,
    AttackMax = 35,
    DefenseMin = 10,
    DefenseMax = 35,
    Accuracy = 40
};
```

### 🌐 Use the API

Take the third POST-Method and send your Character yet again into the arena, but now with tactics.

`API.PostThirdFight(<your class instance>)`

### 🧾 Use the response

Catch the response as before and write it to the console. This should already work at this point.

### 💭 Think about this

- Can i tamper with the response data? May i break round for round with a Console.ReadLine()?
- Can I find more Endpoints on this API with Scalar? And even write a new CustomHttpClient method?
- Do I know what scalar is?
- Do I like this system? → NO? → create your better version 
- Do I know more than GET and POST? → NO? → go and learn?
- Do I know what happens when i use "random" as the name?

### Optional: 

Implement the optional part from Step 3 and try to validate the inputs, where it is not allowed anymore to give more than 30 skill points to your character.

---
You dont like the system?

Use the following Method instead: (Step 5 will introduce you to sending 2 characters)

`API.PostOneVSOne_OwnSkillPoints(<your DTO instance>)`

here you can choose the attributes as you like without the skill point System given.

---

### Optional: 

Play around and trigger some Errors if there were non triggered by now. 
Example: Make very long names, or huge numbers. Or hack the whole thing? Something like that.

## 🪜 Step 5 - Final Step: 🏁

Now your brain is hopefully ticklet with ideas how you can implement this.

After you’ve completed the test fights, it’s time to build your own creative project.
Use the API to create something unique and modular!

| Idea                    | Description                                                     |
| ----------------------- | --------------------------------------------------------------- |
| 🏟️ **Arena Fight**     | Let two characters fight automatically (`API.PostOneVSOne()`)   |
| 🎮 **Rogue-Lite**       | Enemies get stronger each round; your hero gains stats or items |
| 📜 **Text-Based RPG**   | Combine story elements with API-driven fights                   |
| 🤖 **Random Generator** | Generate random fighters and simulate battles                   |


To be able to play local you can prepare 2 characters and send them into the arena.
For this, read something about DTO[1] to send 2 characters over 1 combination class.

`API.PostOneVSOne(<your class instance>)`

[1]A DTO (Data Transfer Object) is a lightweight class that bundles both characters into a single object for sending via one request.

### 💭 Think about this

- What can i make better?
- What have i already learned?
- What i want to learn next?
- What is the next project i am going to bring to life?

---

# 🌐 API Overview

| Method                          | Endpoint                        | Return Type    | Description                            |
| ------------------------------- | ------------------------------- | -------------- | -------------------------------------- |
| `GetAlive()`                    | `/fight/alive`                  | `string`       | Checks if the API is available         |
| `PostFirstFight()`              | `/fight/FirstFight`             | `string`       | Basic flat-damage fight                |
| `PostSecondFight()`             | `/fight/SecondFight`            | `List<string>` | Fight with accuracy and stat ranges    |
| `PostThirdFight()`              | `/fight/fight-a-random-char-v3` | `List<string>` | Fight with attack options              |
| `PostOneVSOne()`                | `/fight/ThirdFight-1vs1`        | `List<string>` | Two custom characters fight each other |
| `PostOneVSOne_OwnSkillPoints()` | `/fight/RawCharFight`           | `List<string>` | Fully custom stats and skill system    |


# 🐸 PS: 

I hope the project is understanable and helpful by learning how to code and how to use OOP.

Servas, Pfiati, hau eini und mochs guad!, oder so.
LG Jan