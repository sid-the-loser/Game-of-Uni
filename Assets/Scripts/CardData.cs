using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public static Dictionary<string, int> cardsOpp = new Dictionary<string, int> // this is the data for opportunities
    {
        {"Congratulations! You aced your assignments and gained an extra $200!", 200},
        {"You got chosen for a really nice internship for a renowned cooperation, obtain $400", 400},
        {"Your classmates are struggling and asking for help so you offered to tutor them! Attain $300!", 300},
        {"You started a new job at the student directory! Gain $1000", 1000},
        {"You won a student voucher at an event! Attain $500!", 500},
        {"Woah! You just won a design competition representing your university! Collect $2000!", 2000},
        {"You were selected for a leadership scholarship! Gain $3000!", 3000},
        {"You got a discount on your school supplies! Gain $100", 100},
        {"Today's your lucky day! You were awarded a prestigious scholarship! Gain $5000", 5000},
        {"While you were in the library a shelf broke and you fixed it! Gain $200!", 200},
        {"You applied for a co-op job opportunity and got it! Gain $400!", 400},
        {"You started working as a TA for one of your courses. Gain $3000!", 3000},
        {"While walking home from a lecture you stumbled on a $100 bill!", 100},
        {"Woah you just got a scholarship! receive $5000!", 5000}
    };

    public static Dictionary<string, int> cardsExp = new Dictionary<string, int> // this is the data for expenses
    {
        {"Oh no! You accidentally missed an important lecture and your professor found out! Deduct $200!", 200},
        {"Oopsies daisies, you had to take another course this semester! Pay $400!" , 400},
        {"Sadly you missed your assignments for a whole week, deduct $300.", 300},
        {"You broke one of the lab equipment while doing an experiment, pay $1000!", 1000},
        {"You need to pay for a bus pass to travel to your university, deduct $500!", 500},
        {"You need to buy textbooks for your courses, pay $200!", 200},
        {"You need to buy a new laptop and school supplies, pay $4000", 4000},
        {"You failed a semester and have to redo some courses, pay: $3000!", 3000},
        {"You lost your student ID and need to buy a new one: pay $100!", 100},
        {"You live very far from the university so you decide to stay in residence. Pay $5000!", 5000},
        {"You plagiarized an assignment without citing the information right, pay $2000!", 2000},
        {"You broke your phone while walking to class, pay $400!", 400},
        {"You lost your wallet while you left class early pay $300!", 300},
        {"You were late for your classes for a whole semester. Pay $100!", 100},
        {"You wanted to change courses mid year as it wasn't what you wanted to do. Pay $5000!", 5000}
    };
}
