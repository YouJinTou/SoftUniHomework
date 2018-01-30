from time import time


class Block:
    def __init__(self, proof, prev_hash):
        self.index = None
        self.timestamp = time()
        self.transactions = []
        self.proof = proof
        self.prev_hash = prev_hash