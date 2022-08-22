-> main

=== main ===
Ciao! Tu devi essere il nuovo arrivato. Al centro mi hanno detto che eri a fare un giro tutto solo, così sono venuta a cercarti.
Io faccio parte dei volontari del centro di accoglienza, se ti va potrei farti vedere la città.
	+ [...]
		-> chosen("Avanti, sarà più divertente girare insieme.")
	+ [Certo, volentieri.]
		-> chosen("Molto bene!")

=== chosen(resp) ===
{resp}
-> END