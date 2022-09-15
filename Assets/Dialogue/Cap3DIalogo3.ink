VAR feeling = 0
VAR help = 0

-> main

=== main ===
Ehi? Chi va là? Cosa state facendo? 
{help == 0: -> firstChoice | -> secondChoice}

=== firstChoice ===
Basta! Ho detto che devi ridarmeli!
No!
	* [Dammi la gabbia.]
		->continue
	* [(avvicinati)]
		->continue

=== continue ===
Non li lascerò nelle tue mani!
	* [Avanti, smettila di insistere.]
		-> continue2
	* [(avvicinati)]
		-> continue2

=== continue2 ===
Non cambierò idea! Piuttosto li libero qui.
Non lasciarglielo fare!
Non possono essere liberati qui! Le conseguenze potrebbero essere drammatiche!
	* [Abbi fiducia in noi. ]
		Ti prego.
		{feeling < 0.5: -> final1 | -> final2}
	* [(spingilo nel fiume)]
		Non volelvo farlo, perdonami.
		-> DONE
		

=== final1 ===
No.
-> DONE

=== final2 ===
...
E va bene.
Avete vinto voi.
-> DONE

=== secondChoice ===
Accidenti! Non riesco più a correre!
Avanti, dammi la gabbia. Lascia che ti aiuti.
Va bene. Supera il ponte, troverai un pick up che ti aspetta.
Non farlo!
Non possono essere liberati! Le conseguenze potrebbero essere drammatiche!
	* [(sali in macchina)]
		->fine1
	* [(non salire in macchina)]
		->fine2


=== fine1 ===
Va bene. Non posso non fidarmi di lei.
-> DONE


=== fine2 ===
Mi dispiace.
-> DONE

=== function changeFeeling(newFeeling) ===
~feeling = newFeeling


=== function changeHelp(newHelp) ===
~help = newHelp

