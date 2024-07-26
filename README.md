# A Leightweight Language Estimation Tool
Using letter frequencies scraped from [Wikipedia](https://en.wikipedia.org/wiki/Letter_frequency), this tool conducts a Chi Squared test against inputted text and all the available language frequencies, and returns the name of the language with the highest P-Score.

## Why?
I was recently looking through some old University assignments and noticed one on cracking a ceaser cypher using letter frequency analysis, I had forgotten about this project and thought it was pretty cool.
Using this as inspiration, I thought it would be interesting to see if I could make a more complex project using this statistical technique, so here's the random idea of estimating languages using letter frequency analysis.

## Benefits
I have no idea how beneficial this is. I assume whoever made the "Detect Language" feature on Google Translate has figured out a much more accurate way to detect the language you are typing.

With the above said, this is pretty fast, and whilst it occassionally gives a wonky result, I've found it to be pretty accurate even on short sentences.

Usually the first result takes ~12ms to complete, but subsequent analysis are all seem to be sub 1ms, even for larger texts. I haven't figured out why yet, I assume it is to do with the Accord.Statstics package I'm using to conduct the Chi-Squared tests. Maybe it loads in data for the given degrees of freedom and caches it? I will update this if I find out!
