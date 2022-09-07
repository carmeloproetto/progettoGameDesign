VAR feeling = 1

-> main

=== main ===
Ehi! Dove vai con quella? #speaker:Dad
	*[Chi Sei?]
		->first
		
	*[Ti ho già visto…]
		->second



=== first ===
{feeling == 0: Vedo che hai la memoria corta.}
{feeling == 0: Sono il ragazzo che hai lasciato venisse picchiato da un energumeno al parco.}
{feeling == 0: …}
{feeling == 0: Non sono stupito di trovarti qui.}
{feeling == 1: Vengo dalla tua città, non ricordi? Abbiamo dato una lezione a quell’energumeno che faceva il gradasso.}
{feeling == 1: Ma certo! Adesso mi ricordo.}
	-> continueStory


=== second ===
Sì! Tu vieni dalla mia città. Ci siamo già incontrati al parco quella volta che stavi litigando con un ragazzo più grande.
{feeling == 0: Sì è vero, quando hai lasciato che quell’energumeno mi picchiasse. | Sì esatto, e tu mi hai salvato da quell’energumeno che faceva il gradasso, ricordi? Non pensavo di trovarti qui.}
{feeling == 0: …}
{feeling == 0: Non mi stupisce trovarti qui.}
	-> continueStory

=== continueStory ===
Io sono qui perché sono un dottorando. Ma tu invece cosa stai facendo? Non ti ho mai visto in università.
	{feeling == 0: -> continueStory2 | -> continueStory3}

=== continueStory2 ===
Da quel che ricordo da quella volta al parco, non sono affari tuoi quello che mi succede.
		* [Non è stata colpa mia.]
			 Mi spiace ma quella volta mi sono solo trovato in mezzo, non volevo guai.
			 Vedo che sei rimasto fedele al tuo essere codardo.
			 -> continueStory3
		* [Mi spiace]
			Avevo paura e non ho reagito, me ne pento. Sono mortificato, ma purtroppo non posso cambiare quello che è successo.
			Umpf…almeno sembri davvero dispiaciuto.
			-> continueStory3

=== continueStory3 ===
-Sono qui per loro. Ho saputo che questi poveri scoiattoli sono stato trasportati qui per degli esperimenti come fossero merce. Ho il dovere di liberarli in una riserva dove vivranno liberamente.
	*[Questi scoiattoli stanno benissimo qui.]
		Il professore li sta studiando per una ricerca, non sta facendo nessun esperimento se è quello che pensi. Me ne sono preso cura io stesso oggi.
		Mi stai prendendo in giro? Si vede palesemente che non sono in forma.
	*[Forse hai ragione.]
		Vivere in quella gabbia non gli fa bene e starebbero meglio nella natura. Ma il professore si sta occupando di una ricerca, non sta facendo nessun esperimento, sono in buone mani.
		E sentiamo, in cosa consisterebbero questi studi?
-…
Come immaginavo. Non hai idea di cosa gli succederà in futuro, ma sai benissimo la fine degli animali da laboratorio.
Beh ti dico io cosa succederà adesso. Prima di tutto li porterò fuori da questa prigione prima che li vivisezioniate. Poi insieme al mio amico qui fuori li libereremo nella riserva naturale più vicina, dove potranno vivere tranquilli nel loro habitat.
	*[Voglio aiutarvi.]
		Hai ragione, ho visto anche io in che condizioni sono. Non voglio che gli succeda altro di brutto.
		{feeling < 0.5: Non voglio il tuo aiuto, non mi fido di te. Non ci saremmo neanche dovuti incontrare. | Si! Sapevo di poter contare su di te! Andiamo seguimi.}
		-> final
	*[Non posso permettertelo.]
		Devi restituirmeli e andartene subito.
		{feeling < 0.5: Me l’aspettavo, non sei cambiato di una virgola in fin dei conti. Continui a fregartene degli altri. Anche questa volta non potrò contare su di te. | Evidentemente mi ero fatto un’idea sbagliata di te. Beh, non importa. Non ho bisogno di te.}
		-> final

=== final ===
->DONE



=== function changeFeeling(newFeeling) ===
~feeling = newFeeling

