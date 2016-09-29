## Homers from Homers

This project is a first-generation experiment in using genetic algorithms to predict home run production among major league baseball players. I wrote it to explore some very basic ideas from machine learning and genetic algorithms including fitness testing and population seeding.

For this first iteration, I limited the seed data to a single datapoint (home runs hit in previous seasons) and a single mechanism for manipulating that datapoint (weighted average over three previous years.) This allowed me to test the concepts I was working with on a finite set of candidates and to come up with a single "correct" answer - at least to an arbitrary degree of precision.

On this basis, future projects should take into account additional variables (at bats, player age, player health, home ballpark, etc.) in order to refine the predictive algorithms. With an expanded dataset, it will also make sense to run multiple generations of candidates complete with ancestry and mutations. Additionally, more operations will be used to create more complex predictive algorithms.

For this first iteration, the best answer (based on statistics current at the end of the 2014 regular season) was a weighted average of 100%, 46%, and 21% of the previous three years, which predicted production in 2015 with 53.60% accuracy - slightly better than random guessing.
