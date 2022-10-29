VAR espulsione = 1

-> main

=== main ===
Ora puoi darmi la grande notizia o vuoi tenermi ancora sulle spine?  #speaker:Papà
Ci siamo quasi, abbi ancora un po’ di pazienza. #speaker:Mamma
Ti ricordi da bambini quanto tempo abbiamo passato in questo parco? #speaker:Mamma
Certo che ricordo! Passavamo interi pomeriggi qui insieme, ricordo anche tanti altri bambini con noi. Adesso è solo uno dei tanti parchi abbandonati a se stessi.. #speaker:Papà
Era così diverso da come appare oggi, non è vero? #speaker:Mamma
Già, come tutto il resto in realtà. Ne abbiamo già parlato tante volte. Ormai siamo circondati dal colore grigio e l’aria è diventata così irrespirabile che uscire di casa è sempre più pesante.  #speaker:Papà
Ma non capisco, pensavo volessi parlarmi di argomenti più felici. #speaker:Papà
Sì sì, ci sto arrivando. #speaker:Mamma
Ricordi quei bandi di ricerca per l’estrazione di campioni dai ghiacciai? #speaker:Mamma
Credo tu me ne abbia parlato solo qualche centinaio di volte negli ultimi mesi, quindi potrei averne una mezza idea. #speaker:Papà
Beh non ti ho detto una cosa però. Il mio gruppo di collaboratori ha partecipato e siamo risultati vincitori! #speaker:Mamma
Faremo delle operazioni di carotaggio. Spero con tutto il cuore di riuscire ad ottenere dei risultati rilevanti, magari riusciamo a far smuovere qualcosa ai piani alti… È necessario portare alla luce la questione del cambiamento climatico. #speaker:Mamma
Ma è fantastico! È un’ottima notizia! #speaker:Papà
E c’è di più! #speaker:Mamma
{espulsione == 0: -> noEspulso | -> espulso}

=== noEspulso ===
Nel mio team c’è ancora posto per un altro ricercatore, qualcuno che abbia voglia di sporcarsi le mani nella neve e con tanta voglia di fare la sua parte. #speaker:Mamma
->Continue

=== espulso ===
Nel mio team c’è ancora posto per un altro membro. Anche se non hai terminato il dottorato per diventare ricercatore, abbiamo bisogno di qualcuno che abbia voglia di sporcarsi le mani nella neve e con tanta voglia di fare la sua parte. #speaker:Mamma
->Continue

=== Continue ===
Mi stai forse proponendo di seguirti in Antartide a recuperare colonne di ghiaccio da osservare al microscopio tutto il giorno? Perchè credo che non avrei potuto chiedere un’occasione migliore per dare il mio contributo. #speaker:Papà
->DONE

=== function changeEspulsione(newEspulsione) ===
~espulsione = newEspulsione