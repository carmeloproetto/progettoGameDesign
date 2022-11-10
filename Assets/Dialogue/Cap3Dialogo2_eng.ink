VAR feeling = 1

-> main

=== main ===
Ehi! Where are you going with that? #speaker:Dad
	*[Who are you?]
		->first
		
	*[I’ve seen you before…]
		->second



=== first ===
	{feeling == 0: -> noFeeling | -> yesFeeling}

=== noFeeling ===
	I see you have a short memory. #speaker:Lad
	I’m the guy you left getting beat up by a bully in the park. #speaker:Lad
	… #speaker:Dad
	I’m not surprised to find you here. #speaker:Lad
	-> continueStory

=== yesFeeling === 
	I’m from your town, remember? We taught that bully a lesson. #speaker:Lad
	Of course! Now I remember. #speaker:Dad
	-> continueStory



=== second ===
Yes! You're from my town. We already met in the park that time you were arguing with an older guy. #speaker:Dad
{feeling == 0: -> continueNoFeeling | -> continueYesFeeling}

===  continueNoFeeling ===
Yes, it's true, when you let that bully beat me. #speaker:Lad
… #speaker:Dad
I’m not surprised to find you here. #speaker:Lad
	-> continueStory

=== continueYesFeeling ===
	Yes, it's true, you saved me from that bully, remember? I didn’t think you’d be here. #speaker:Lad
	-> continueStory



=== continueStory ===
I’m here because I’m a PhD student. But what are you doing? I’ve never seen you in college. #speaker:Dad
	{feeling == 0: -> continueStory2 | -> continueStory3}

=== continueStory2 ===
I remember that time in the park and it’s none of your business what happens to me. #speaker:Lad
		* [It wasn't my fault.]
			 I’m sorry, that time I just got in the way, I didn’t want any trouble. #speaker:Dad
			 I see you’ve stayed loyal to your cowardice. #speaker:Lad
			 -> continueStory3
		* [I'm sorry]
			I was afraid and I didn’t react, I regret it. Unfortunately I can’t change what happened. #speaker:Dad
			Umpf… At least you look really upset. #speaker:Lad
			-> continueStory3

=== continueStory3 ===
-I'm here for them. I heard that these poor squirrels were transported here for experiments as if they were merchandise. I must release them in a reserve where they will live freely. #speaker:Lad
	*[These squirrels look great here.]
		The professor is studying them for research, he’s not doing any experiments if that’s what you think. I took care of them myself today. #speaker:Dad
		Are you kidding me? I can clearly see they're not well. #speaker:Lad
	*[Maybe you're right.]
		Is not good for them to living in that cage. They’d be better off in nature, but the professor is doing a research, he’s not doing any experiments, they're in good hands. #speaker:Dad
		What would these studies consist of? #speaker:Lad
-… #speaker:Dad
As I thought. You have no idea what will happen to them in the future, but you know the end of lab animals. #speaker:Lad
Well, I’ll tell you what happens now. First of all, I’m gonna get them out of this prison before you dissect them. Then, together with my friend who is out here, we will free them in the nearest nature reserve, where they can live peacefully in their habitat. #speaker:Lad
	*[I would like to help you.]
		You're right, I’ve seen their conditions too. I don’t want anything bad happen to them. #speaker:Dad
		{feeling < 0.5: -> noFeeling2 | -> yesFeeling2}
	*[I can't allow that.]
		You have to give them back and leave now. #speaker:Dad
		{feeling < 0.5: -> noFeeling3 | -> yesFeeling3}

=== noFeeling2 ===
	I don’t want your help, I don’t trust you. We shouldn’t have even met. #speaker:Lad
	->final

=== yesFeeling2 ===
	Yes! I knew I could count on you! Come on, follow me. #speaker:Lad
	->final

=== noFeeling3 ===
	I expected, you haven’t changed a bit. You still don’t care about others. Once again I can’t count on you. #speaker:Lad
	->final

=== yesFeeling3 ===
	Obviously I had the wrong idea about you. Well, never mind. I don't need you. #speaker:Lad
	->final


=== final ===
->DONE



=== function changeFeeling(newFeeling) ===
~feeling = newFeeling

