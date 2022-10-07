VAR feeling = 1

-> main

=== main ===
Ehi! Dove vai con quella? #speaker:Papà
	*[Chi Sei?]
		->first
		
	*[Ti ho già visto…]
		->second



=== first ===
	{feeling == 0: -> noFeeling | -> yesFeeling}

=== noFeeling ===
	Vedo che hai la memoria corta. #speaker:Ragazzo
	Sono il ragazzo che hai lasciato venisse picchiato da un energumeno al parco. #speaker:Ragazzo
	… #speaker:Papà
	Non sono stupito di trovarti qui. #speaker:Ragazzo
	-> continueStory

=== yesFeeling === 
	Vengo dalla tua città, non ricordi? Abbiamo dato una lezione a quell’energumeno che faceva il gradasso. #speaker:Ragazzo
	Ma certo! Adesso mi ricordo. #speaker:Papà
	-> continueStory



=== second ===
Sì! Tu vieni dalla mia città. Ci siamo già incontrati al parco quella volta che stavi litigando con un ragazzo più grande. #speaker:Dad
{feeling == 0: -> continueNoFeeling | -> continueYesFeeling}

===  continueNoFeeling ===
Sì è vero, quando hai lasciato che quell’energumeno mi picchiasse. #speaker:Lad
… #speaker:Dad
Non mi stupisce trovarti qui. #speaker:Lad
	-> continueStory

=== continueYesFeeling ===
	Sì esatto, e tu mi hai salvato da quell’energumeno che faceva il gradasso, ricordi? Non pensavo di trovarti qui. #speaker:Lad
	-> continueStory



=== continueStory ===
Io sono qui perché sono un dottorando. Ma tu invece cosa stai facendo? Non ti ho mai visto in università. #speaker:Dad
	{feeling == 0: -> continueStory2 | -> continueStory3}

=== continueStory2 ===
Da quel che ricordo da quella volta al parco, non sono affari tuoi quello che mi succede. #speaker:Lad
		* [Non è stata colpa mia.]
			 Mi spiace ma quella volta mi sono solo trovato in mezzo, non volevo guai. #speaker:Dad
			 Vedo che sei rimasto fedele al tuo essere codardo. #speaker:Lad
			 -> continueStory3
		* [Mi spiace]
			Avevo paura e non ho reagito, me ne pento. Sono mortificato, ma purtroppo non posso cambiare quello che è successo. #speaker:Dad
			Umpf…almeno sembri davvero dispiaciuto. #speaker:Lad
			-> continueStory3

=== continueStory3 ===
-Sono qui per loro. Ho saputo che questi poveri scoiattoli sono stato trasportati qui per degli esperimenti come fossero merce. Ho il dovere di liberarli in una riserva dove vivranno liberamente. #speaker:Lad
	*[Questi scoiattoli stanno benissimo qui.]
		Il professore li sta studiando per una ricerca, non sta facendo nessun esperimento se è quello che pensi. Me ne sono preso cura io stesso oggi. #speaker:Dad
		Mi stai prendendo in giro? Si vede palesemente che non sono in forma. #speaker:Lad
	*[Forse hai ragione.]
		Vivere in quella gabbia non gli fa bene e starebbero meglio nella natura. Ma il professore si sta occupando di una ricerca, non sta facendo nessun esperimento, sono in buone mani. #speaker:Dad
		E sentiamo, in cosa consisterebbero questi studi? #speaker:Lad
-… #speaker:Dad
Come immaginavo. Non hai idea di cosa gli succederà in futuro, ma sai benissimo la fine degli animali da laboratorio. #speaker:Lad
Beh ti dico io cosa succederà adesso. Prima di tutto li porterò fuori da questa prigione prima che li vivisezioniate. Poi insieme al mio amico qui fuori li libereremo nella riserva naturale più vicina, dove potranno vivere tranquilli nel loro habitat. #speaker:Lad
	*[Voglio aiutarvi.]
		Hai ragione, ho visto anche io in che condizioni sono. Non voglio che gli succeda altro di brutto. #speaker:Dad
		{feeling < 0.5: -> noFeeling2 | -> yesFeeling2}
	*[Non posso permettertelo.]
		Devi restituirmeli e andartene subito. #speaker:Dad
		{feeling < 0.5: -> noFeeling3 | -> yesFeeling3}

=== noFeeling2 ===
	Non voglio il tuo aiuto, non mi fido di te. Non ci saremmo neanche dovuti incontrare. #speaker:Lad
	->final

=== yesFeeling2 ===
	Si! Sapevo di poter contare su di te! Andiamo seguimi. #speaker:Lad
	->final

=== noFeeling3 ===
	Me l’aspettavo, non sei cambiato di una virgola in fin dei conti. Continui a fregartene degli altri. Anche questa volta non potrò contare su di te. #speaker:Lad
	->final

=== yesFeeling3 ===
	Evidentemente mi ero fatto un’idea sbagliata di te. Beh, non importa. Non ho bisogno di te. #speaker:Lad
	->final


=== final ===
->DONE



=== function changeFeeling(newFeeling) ===
~feeling = newFeeling

