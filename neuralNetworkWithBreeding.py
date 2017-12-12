# This script creates a basic neural network outline
# 12/10/2017
# Daniel Couturier

#  ========================
import random;
import math;
import numpy as np;
#  ========================

#  ========================
# GLOBAL VARS
#  ========================
# activationThreshold = random.uniform(0,1)
# seed = 1
#  ========================


def updateSeed():
	seed = seed + 1

#  ========================
# create a "nodes" container
class Nodes(object):
	"""docstring for word"""
	def __init__(self, emptyArray=[]):
		super(Nodes, self).__init__()
		self.nodes = emptyArray

#  ========================
# create a "weight" container
class Weights(object):
	"""docstring for word"""
	def __init__(self, emptyArray=[]):
		super(Weights, self).__init__()
		self.weights = emptyArray

#  ========================
# creates a node
class Node(object):
	"""docstring for word"""
	def __init__(self):
		super(Node, self).__init__()
		self.output = int(0)
		self.activationSum = int(0)
		self.bias = random.random()
		self.activationThreshold = random.uniform(0,1)



#  ========================
# create a "Network" container
class Network(object):
	"""docstring for network"""
	def __init__(self, emptyArray=[]):
		super(Network, self).__init__()
		self.nodeLayers = []
		self.weightLayers = []
		

#  ========================
# modifies a node
def runNode(node):
	
	node.output = 0;
	finalSum = node.activationSum + node.bias

	if (finalSum >= node.activationThreshold):
		node.output = 1;
	else:
		node.output = 0;

	node.activationSum = 0

#  ========================
# adds a value to the activation Sum
def addActivationSum(node,num):
	originalSum = node.activationSum
	node.activationSum = originalSum + num


#  ========================
# runs the first layer of the neural network.
def firstLayer(numInputNodes):
	# FIRST LAYER ===========================

	# initialInputs are ONLY used in the very first layer of inputs. This could be the distance from a wall, or a 0 or 1 value. 
	# Basically need to take this value and multiply it by the first layer of weights to get your first set of inputs to your first layer of nodes.
	initialInputs = Weights([]);
	# random.seed(seed)
	# seed = seed + 1
	for i in range(0, numInputNodes):
		initialInputs.weights.append(random.random())


	inputNodes = Nodes([]);

	for i in range(0, numInputNodes):
		inputNodes.nodes.append(Node())

	weights = Weights([])
	for x in range (0, numInputNodes):
		weights.weights.append(1)


	for i in range(0,numInputNodes):
		# NOTE: MIGHT NOT EVEN NEED THE INPUTS VARIABLE
		# inputNodes.nodes[i].input = initialInputs.weights[i] * weights.weights[i]
		addActivationSum(inputNodes.nodes[i], initialInputs.weights[i] * weights.weights[i])

	# once the layer nodes are all added up, need to see if they are activated
	for i in range(0, numInputNodes):
		runNode(inputNodes.nodes[i])

	return [inputNodes, initialInputs]


def calculateNormalizeWeights(weights):
	# normalize weights
	weightsSum = sum(weights)

	# create an array or normalized scores
	normWeights = [];
	for i in range(0, len(weights)):
		normWeight = float(weights[i] / weightsSum)
		normWeights.append(normWeight)

	return normWeights


#  ========================
# runs the Nth layer of the neural network.
def nLayer(numOutputNodes, prevLayer):

	# OUTPUT LAYER ======================
	outputNodes = Nodes([]);
	numPrevLayer = len(prevLayer.nodes)

	for i in range(0, numOutputNodes):
		outputNodes.nodes.append(Node())


	outputWeights = Weights([])
	for i in range(0, numPrevLayer*numOutputNodes):
		outputWeights.weights.append(random.random())

	outputWeights.weights = calculateNormalizeWeights(outputWeights.weights)

	# iterate through previous layer nodes
	for x in range(0, len(prevLayer.nodes)):
		inputNodeOutputAtX = prevLayer.nodes[x].output
		
		# iterate through current layer
		for y in range(0, numOutputNodes):
			
			value = outputWeights.weights[(x*numOutputNodes) + y]

			num = inputNodeOutputAtX * value
			addActivationSum(outputNodes.nodes[y], num)
			

	for i in range(0, numOutputNodes):
		runNode(outputNodes.nodes[i])


	return [outputNodes, outputWeights]


def scoreLayer(nodeLayer, target):
	# score fitness of a word
	score = 0;
	for i in range(0, len(nodeLayer.nodes)):
		if nodeLayer.nodes[i].output == target[i]:
			score = score + 1;

	# this is to make the better words stick out more
	score = score * score;

	return float(score);

def createNetwork(lastLayerNodesNum):
	# CREATE A NETWORK ==================================
	# INPUT LAYER

	# define Network
	network = Network([])


	numInputNodes = 100
	inputNodes = Nodes([])
	initialWeights = Weights([])
	[inputNodes, initialWeights] = firstLayer(numInputNodes)

	network.nodeLayers.append(inputNodes)
	network.weightLayers.append(initialWeights)

	prevLayer = Nodes([])
	prevLayer = inputNodes

	nextLayerNodesNum = [60, 20, lastLayerNodesNum]


	for i in range(0, len(nextLayerNodesNum)):
		# NEXT LAYER(S)
		numNextLayerNodes = nextLayerNodesNum[i];
		nextLayer = Nodes([])
		outputWeights = Weights([])
		[nextLayer, outputWeights] = nLayer(numNextLayerNodes, prevLayer)
		network.nodeLayers.append(nextLayer)
		network.weightLayers.append(outputWeights)
		prevLayer.nodes.clear()
		prevLayer = Nodes([])
		prevLayer = nextLayer

	return network
# ====================================================

def calculateScores(pop, targetOutputs):
	#find fitness of each word in the population
	scores = [];
	for i in range(0, len(pop)):
		wordIndex = pop[i];
		score = scoreLayer(pop[i].nodeLayers[len(pop[i].nodeLayers)-1], targetOutputs)
		scores.append(score)

	return scores

def calculateNormalizeScores(scores):
	# normalize scores
	scoresSum = sum(scores)

	# create an array or normalized scores
	normScores = [];
	for i in range(0, len(scores)):
		normScore = float(scores[i] / scoresSum)
		normScores.append(normScore)

	return normScores


def createPopulation(lastLayerNodesNum):
	# create initial population
	pop = []
	popSize = 100

	for i in range(0, popSize):
		network = createNetwork(lastLayerNodesNum);
		pop.append(network)

	return pop


def createChild(indexA, indexB, pop, target, mutationRate):
	#create child from parents
	parentA = Network([])
	parentB = Network([])
	parentA = pop[indexA]
	parentB = pop[indexB]

	child = Network([]);


# GO THROUGH NODES =======
	# go through all node layers
	for i in range(0, len(parentA.nodeLayers)):
		child.nodeLayers.append(Nodes([]))

		# go through all nodes within this layer
		for x in range(0, len(parentA.nodeLayers[i].nodes)):
			dart = random.random();
			if (dart < 0.5):
				child.nodeLayers[i].nodes.append(parentA.nodeLayers[i].nodes[x])
			else:
				child.nodeLayers[i].nodes.append(parentB.nodeLayers[i].nodes[x])

			# mutate here
			rand = random.random();
			if(rand < mutationRate):
				newNum = random.random()
				child.nodeLayers[i].nodes[x].activationThreshold = newNum


# GO THROUGH WEIGHTS
	# go through all weights layers
	for y in range(0, len(parentA.weightLayers)):
		child.weightLayers.append(Weights([]))
	
		# go through all weights within this layer
		for z in range(0, len(parentA.weightLayers[y].weights)):
			dart = random.random()
			if(dart < 0.5):
				child.weightLayers[y].weights.append(parentA.weightLayers[y].weights[z])
			else:
				child.weightLayers[y].weights.append(parentB.weightLayers[y].weights[z])
				

			# mutate here
			rand = random.random();
			if(rand < mutationRate):
				newNum = random.random()
				child.weightLayers[y].weights[z] = newNum

		child.weightLayers[y].weights = calculateNormalizeWeights(child.weightLayers[y].weights)

	return child;

def createChildren(normScores, pop, target, mutationRate, lastLayerNodesNum):
	#create children for entire next population

	popPortion = math.floor(len(pop)/10)
	pop2 = []

	for i in range (0, len(pop)-popPortion):
		# select parents a & b randomly "from a bag"
		indexA = selectParent(normScores);
		indexB = selectParent(normScores);

		#create child from given parents
		child = createChild(indexA, indexB, pop, target, mutationRate)

		#replace child into population
		pop2.append(child)

	for i in range(0, popPortion):
		pop2.append(createNetwork(lastLayerNodesNum))

	return pop2;


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


def setup():
	targetOutputs = [1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1]
	mutationRate = 0.1
	lastLayerNodesNum = len(targetOutputs)

	generation = 0

	return [targetOutputs, mutationRate, lastLayerNodesNum, generation]


def findTargetScore(pop, targetOutputs, generation):
	scores = []
	scores = calculateScores(pop, targetOutputs);


	maxScore = getMaxScore(scores, pop, generation);


	targetLayer = Nodes([])
	for i in range(0, len(targetOutputs)):
		targetLayer.nodes.append(Node())
		targetLayer.nodes[i].output = targetOutputs[i]

	targetScore = scoreLayer(targetLayer, targetOutputs)

	normScores = calculateNormalizeScores(scores);

	return [maxScore, targetScore, normScores]

#  ========================
def main():

# setup the basic requirements
	[targetOutputs, mutationRate, lastLayerNodesNum, generation] = setup()

# CREATE INITIAL POPULATION
	pop = createPopulation(lastLayerNodesNum)
	
# setup teh basic target score
	scores = []
	[maxScore, targetScore, normScores] = findTargetScore(pop, targetOutputs, generation)


	while maxScore < targetScore:
		generation = generation + 1

		# ===== CROSS BREEDING ===================================

		#create children for entire next population
		pop = createChildren(normScores, pop, targetOutputs, mutationRate, lastLayerNodesNum);
		
		# ==== SCORING ==========================================

		# calculate scores for each word
		scores.clear()
		scores = calculateScores(pop, targetOutputs);
			
		# normalize word scores
		normScores = calculateNormalizeScores(scores);

		# print high score
		maxScore = getMaxScore(scores, pop, generation);


# =========================
main();