# This script creates a randomly generated population
# 9/20/2017
# Daniel Couturier


import random;
import math;
import numpy as np;


# create a "word" container
class word(object):
	"""docstring for word"""
	def __init__(self, emptyArray=[]):
		super(word, self).__init__()
		self.letters = emptyArray
		

def printPop(pop):
		pop0 = pop[0];
		pop1 = pop[1];

		for x in range (0, len(pop)):

			for a in range (0, len(pop[x].letters)):
				print (pop0.letters[a])
			
			print ("\n")

		


def createWord(object, target):
	# create one array of random numbers
	w = word([]);
	for i in range (0,len(target)):
		num = random.randrange(0,5)
		w.letters.append(num)
	return w;

def createPopulation(numWords, target):
	population = [];
	for i in range (0, numWords):
		w = createWord(0, target);
		population.append(w);

	return population;

def scoreWord(word, target):
	# score fitness of a word
	score = 0;
	for i in range(0, len(word.letters)):
		if word.letters[i] == target[i]:
			score = score + 1;

	# this is to make the better words stick out more
	score = score * score;

	return float(score);


def calculateScores(pop, target):
	#find fitness of each word in the population
	scores = [];
	for i in range(0, len(pop)):
		wordIndex = pop[i];
		score = scoreWord(wordIndex, target)
		scores.append(score)
	
	return scores;

def calculateNormalizeScores(scores):
	# normalize scores
	scoresSum = sum(scores)

	# create an array or normalized scores
	normScores = [];
	for i in range(0, len(scores)):
		normScore = float(scores[i] / scoresSum)
		normScores.append(normScore)

	return normScores

def selectParent(normScores):
	# select an index from the population of words based on it's probability from normalized score

	# this number is always between 0 and 1
	dart = random.random();
	
	index = 0;
	while (dart > 0):
		dart = dart - normScores[index];
		index = index + 1;

	index = index - 1;

	return index;

def createChild(indexA, indexB, pop, target, mutationRate):
	#create child from parents
	parentA = pop[indexA]
	parentB = pop[indexB]

	child = createWord(0, target);



	for i in range(0, len(parentA.letters)):
		dart = random.random();
		if (dart < 0.5):
			child.letters[i] = parentA.letters[i]
		else:
			child.letters[i] = parentB.letters[i]

		#mutate here
		rand = random.random();
		if(rand < mutationRate):
			newNum = random.randrange(0,10)
			child.letters[i] = newNum

	return child;

def createChildren(normScores, pop, target, mutationRate):
	#create children for entire next population

	for i in range (0, len(pop)):
		#select parents a & b randomly "from a bag"
		indexA = selectParent(normScores);
		indexB = selectParent(normScores);

		#create child from given parents
		child = createChild(indexA, indexB, pop, target, mutationRate)

		#replace child into population
		pop[i] = child

	return pop;

def getMaxScore(scores, pop, generation):
	# get top scorer
	maxScore = 0;
	maxScoreIndex = 0;

	for i in range(0, len(scores)):
		currScore = scores[i];
		if(currScore > maxScore):
			maxScore = currScore;
			maxScoreIndex = i;

	print ("Generation:", generation, ",    max score: ", maxScore)

	return maxScore

def setup(target):
	#	population is an array of words
	pop = createPopulation(200, target);
	
	# score the initial population

	# calculate scores for each word
	scores = calculateScores(pop, target);
	
	# normalize word scores
	normScores = calculateNormalizeScores(scores);

	# print high score
	maxScore = getMaxScore(scores, pop, 0);

	return [pop, scores, normScores, maxScore]

# ==================================================
def main():

	# target word is "01234"
	target = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7, 8];
	mutationRate = 0.01;

	[pop, scores, normScores, maxScore] = setup(target)
	generation = 0;

	targetWord = word(0);
	targetWord.letters = target;
	targetScore = scoreWord(targetWord, target)

	print (targetScore);
	

	while (maxScore < targetScore):
		generation = generation + 1;

		# ===== CROSS BREEDING ===================================

		#create children for entire next population
		pop = createChildren(normScores, pop, target, mutationRate);


		# ==== SCORING ==========================================

		# calculate scores for each word
		scores = calculateScores(pop, target);
		
		# normalize word scores
		normScores = calculateNormalizeScores(scores);

		# print high score
		maxScore = getMaxScore(scores, pop, generation);





# ====================
main();