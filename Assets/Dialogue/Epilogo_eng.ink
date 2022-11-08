VAR espulsione = 0

-> main

=== main ===

Now can you give me the big news, or do you want to keep me guessing?  #speaker:Dad
Almost there, just a little more patience.. #speaker:Mom
Remember when we were kids, how much time we spent in this park? #speaker:Mom
Of course I remember! We spent whole afternoons here together, I also remember many other kids with us. Now it’s just one of the many parks left to themselves. #speaker:Dad
It was so different from what it looks like today, wasn’t it? #speaker:Mom
Like everything else actually. We’ve talked about it many times. Now we are surrounded by gray and the air has become so unbreathable that leaving home is always heavier.  #speaker:Dad
But I don’t understand, I thought you wanted to talk about happier topics. #speaker:Dad
Yes yes, I’m getting there. #speaker:Mom
Do you remember those research calls for the extraction of samples from glaciers? #speaker:Mom
I think you’ve only mentioned it a few hundred times in the last few months, so I might have half an idea. #speaker:Dad
Well I didn’t tell you one thing though. My team participated and we won! #speaker:Mom
We’re gonna do some core drilling. I hope with all my heart I can get some relevant results, maybe we can get something moving high places... The issue of climate change needs to be brought to light. #speaker:Mom
But that’s great! That’s an amazing new! #speaker:Dad
And there is more! #speaker:Mom
{espulsione == 0: -> noEspulso | -> espulso}

=== noEspulso ===
My team is looking for another researcher, someone who wants to get his hands dirty in the snow and with a great desire to do his part. #speaker:Mom
->Continue

=== espulso ===
My team is looking for another researcher. Even if you haven’t finished your PhD to become one of them, we need someone who wants to get their hands dirty in the snow and really want to do their part. #speaker:Mom
->Continue

=== Continue ===
Are you suggesting I follow you to Antarctica to retrieve columns of ice to be observed under a microscope all day? I think I could not have asked for a better opportunity to give my contribution. #speaker:Dad
->DONE

=== function changeEspulsione(newEspulsione) ===
~espulsione = newEspulsione