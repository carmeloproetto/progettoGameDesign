VAR feeling = 0
VAR help = 0

-> main

=== main ===
Ehi? Who are you? What are you doing? #speaker:Professor
{help == 0: -> firstChoice | -> secondChoice}

=== firstChoice ===
Stop! I said give it back! #speaker:Dad
No! #speaker:Lad
	* [Give me the cage.]
		->continue
	* [(come closer)]
		->continue

=== continue ===
I won’t leave them with you! #speaker:Lad
	* [Come on, stop pushing.]
		-> continue2
	* [(come closer)]
		-> continue2

=== continue2 ===
I won’t change my mind! I’ll rather release them here. #speaker:Lad
Don't let him do! #speaker:Professor
They cannot be released here! The consequences could be dramatic! #speaker:Professor
	* [Trust us. ]
		Please. #speaker:Dad
		{feeling < 0.5: -> final1 | -> final2}
	* [(push him into the river)]
		I won’t do it, forgive me. #speaker:Dad
		-> DONE
		

=== final1 ===
No. #speaker:Lad
-> DONE

=== final2 ===
... #speaker:Lad
All right. #speaker:Lad
You guys win. #speaker:Lad
-> DONE

=== secondChoice ===
Damn it! I can’t run anymore! #speaker:Lad
Come on, give me the cage. Let me help you. #speaker:Dad
All right. Cross the bridge, you’ll find a pick up waiting for you. #speaker:Lad
Don't do it! #speaker:Professor
They cannot be released here! The consequences could be dramatic! #speaker:Professor
	* [(get in the car)]
		->fine1
	* [(don't get in the car)]
		->fine2


=== fine1 ===
I'm sorry. #speaker:Dad
-> DONE


=== fine2 ===
All right. I can’t not trust you. #speaker:Dad
-> DONE

=== function changeFeeling(newFeeling) ===
~feeling = newFeeling


=== function changeHelp(newHelp) ===
~help = newHelp

