# Interview Template (Football API)

## Football API :soccer:
The aim of this API is to store information about players, managers, referees, matches and league information. Each controller has 4 actions:


## Goals

1. Fix current errors in the API
3. Implement Statistics controller following Clean Clode practices
4. Create a Job that notifies 5 minutes before a game starts incorrect alignments
5. The other controllers (Manager, Match, Player, Referee) are not well implemented. What are the things you would improve? Provide that information in comments with //TODO:
6. Create the frontend with a List of statistics (no Razor allowed, no new endpoints allowed)

## Comments

I have splitted Commands from Queries to implement CQRS pattern and have used the same ORM (EF core) for both, however, different ORMs can also be used, such as Dapper, ADO.Net, etc.
Within them I have used Repository Pattern, which lets you use different databases too such as nosql ones(elasticsearch, mongoDB,...) or Oracle, etc.

Regarding the Statistics Controller, in interview-api.azurewebsites.net//api/Statistics/yellowcards output, there is a "team" property which does not exist in the Models. So I just calculate all red and yellow cards for all or specific player.
For goal 5 (frontend) I could use some simple Js/Css pages to present data, but as I had a surgery on my eyes, I could not look at monitor screen for a long time. So I skipped this one. (In less than a week I will recover from the sergury completely) 

For the Notification goal, I created a new scheduler project to handle it. I had some problems about it: I didn't get what exactly mean by this "IncorrectAlignment" api because in the description of Github it says goal 4 but in the description on the Api itself, says Goal 2, but the only goal relating to this "IncorrectAlignment" is Goal 3. Also this "IncorrectAlignment" is not clear itself. It accepts a list of Ids. I didn't know what should I send to it. I merged the Ids of home/away players of the match, and sent them in a list to the Api. (I think the most important thing is to send some data about matches 5 minutes befor each match) 




