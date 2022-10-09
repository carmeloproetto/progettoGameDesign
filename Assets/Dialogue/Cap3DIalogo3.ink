VAR feeling = 0
VAR help = 0

-> main

=== main ===
Ehi? Chi va là? Cosa state facendo?  #speaker:Professore
{help == 0: -> firstChoice | -> secondChoice}

=== firstChoice ===
Basta! Ho detto che devi ridarmeli! #speaker:Papà
No! #speaker:Ragazzo
	* [Dammi la gabbia.]
		->continue
	* [(avvicinati)]
		->continue

=== continue ===
Non li lascerò nelle tue mani! #speaker:Ragazzo
	* [Avanti, smettila di insistere.]
		-> continue2
	* [(avvicinati)]
		-> continue2

=== continue2 ===
Non cambierò idea! Piuttosto li libero qui. #speaker:Ragazzo
Non lasciarglielo fare! #speaker:Professore
Non possono essere liberati qui! Le conseguenze potrebbero essere drammatiche! #speaker:Professore
	* [Abbi fiducia in noi. ]
		Ti prego. #speaker:Papà
		{feeling < 0.5: -> final1 | -> final2}
	* [(spingilo nel fiume)]
		Non volelvo farlo, perdonami. #speaker:Papà
		-> DONE
		

=== final1 ===
No. #speaker:Ragazzo
-> END

=== final2 ===
... #speaker:Ragazzo
E va bene. #speaker:Ragazzo
Avete vinto voi. #speaker:Ragazzo
-> END

=== secondChoice ===
Accidenti! Non riesco più a correre! #speaker:Ragazzo
Avanti, dammi la gabbia. Lascia che ti aiuti. #speaker:Papà
Va bene. Supera il ponte, troverai un pick up che ti aspetta. #speaker:Ragazzo
Non farlo! #speaker:Professore
Non possono essere liberati! Le conseguenze potrebbero essere drammatiche! #speaker:Professore
	* [(sali in macchina)]
		->fine1
	* [(non salire in macchina)]
		->fine2


=== fine1 ===
Va bene. Non posso non fidarmi di lei. #speaker:Papà
-> END


=== fine2 ===
Mi dispiace. #speaker:Papà
-> END

=== function changeFeeling(newFeeling) ===
~feeling = newFeeling


=== function changeHelp(newHelp) ===
~help = newHelp

