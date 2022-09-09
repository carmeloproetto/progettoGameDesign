VAR feeling = 0
VAR help = true

-> main

=== main ===
Ehi? Chi va là? Cosa state facendo? 
{help == false: -> firstChoice | -> secondChoice}

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
		-> DONE
		

=== final1 ===
No.
-> DONE

=== final2 ===
...
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
		->DONE
	* [(non salire in macchina)]
		->DONE



=== function changeFeeling(newFeeling) ===
~feeling = newFeeling


=== function changeHelp(newHelp) ===
~help = newHelp

