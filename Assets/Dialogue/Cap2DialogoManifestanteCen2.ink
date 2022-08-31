-> main

=== main ===
La guardia ti ha bloccata? #speaker:Manifestante2
Se vuoi proprio entrare puoi provare a controllare se sul retro del palazzo c’è qualche uscita di sicurezza. Ma in quel caso non dovresti farti vedere da nessuno o potresti finire nei guai. Dovrai riuscire a trovare da sola le risposte che cerchi. 
Tranquilla, non lo dirò a nessuno. Quando vuoi andare sul retro vieni ad avvisarmi, così distrarrò la guardia.
Adesso ti senti pronta ad andare?
	+ [Si]
		-> chosen("Perfetto, buona fortuna!")
	+ [No]
		-> chosen("Va bene. Quando sei pronta ad andare sul retro vieni ad avvisarmi, così distrarrò la guardia.")

=== chosen(choose) ===
{choose}
-> END


