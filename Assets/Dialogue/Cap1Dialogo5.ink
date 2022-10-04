-> main

=== main ===
Che hai da guardare? Vattene #speaker:Bullo
	* [...]
		-> continue1
	* [Smettila!]
		-> continue2


=== continue1 ===
Sei un codardo! #speaker:Ragazzino
	* [Hai iniziato tu.]
		->continue
	* [Mi spiace]
		ero spaventato… #speaker:Papà
		->continue

=== continue ===
Sta zitto! Non hai fatto nulla come tutti gli altri! #speaker:Ragazzino
Ma io non sarò inutile come te e quell’idiota. Non chiuderò gli occhi lasciando gli animali che vivono nel parco in pericolo per colpa di quel criminale! #speaker:Ragazzino
->final

=== continue2 ===
Lascialo stare! #speaker:Papà
Cosa vuoi anche tu?! #speaker:Bullo
Bravo, ti sei trovato un amico sociopatico quanto te. Siete due esaltati. #speaker:Bullo
Ti ringrazio, sei stato davvero coraggioso ad aiutarmi. Quell’idiota finalmente ha avuto la lezione che meritava. #speaker:Ragazzino 
Erano giorni che gli urlavo di smetterla di andare in giro con quella specie di motorino truccato. Emette un fumo disgustoso e spaventa gli animali del parco, oltre a mettere in pericolo i cani e gatti randagi quando sfreccia con i suoi amici. #speaker:Ragazzino
Sono contento di aver trovato finalmente qualcun altro che si interessa a proteggere i più deboli. #speaker:Ragazzino
->final

=== final ===
->DONE
