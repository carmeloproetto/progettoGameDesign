-> main

=== main ===
Did the guard block you?? #speaker:Protester 1
If you really want to get in, you can try to check the back of the building for emergency exits. But then you shouldn’t be seen by anyone or you could get in trouble. You’ll have to find your own answers alone. 
Don’t worry, I won’t tell anyone. When you want to go to the back come to me, so I’ll distract the guard.
Are you ready to go now?
	+ [Yes]
		-> chosen("All right. Hurry up, move to the back while I distract him. Good luck!")
	+ [No]
		-> chosen("All right. When you’re ready to go to the back come to me, so I’ll distract the guard.")

=== chosen(choose) ===
{choose}
-> END


