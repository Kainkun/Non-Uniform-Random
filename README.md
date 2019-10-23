# Non-Uniform-Random

Unity's Random.Range function can only randomize with a uniform distribution which means that every number has an equal chance of being returned.
My NonUniformRandom script solves this problem but allowing users to input their own probabilities.
This script can either return random data from an array or a random Index.

The probabilities inputted determine their chance of being returned proportionally to each other.
For example, if 5,10,20 is inputted, there is a 5/35 chance of returning the first data, 10/35 for the second, 20/35 for the third. This means that if the inputted numbers add up to 100, it is identical to a percent chance.
