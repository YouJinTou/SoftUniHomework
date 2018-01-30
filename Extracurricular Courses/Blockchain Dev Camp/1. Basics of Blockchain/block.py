from time import time


class Block:
    def __init__(self, proof, prev_hash):
        self.index = None
        self.timestamp = time()
        self.transactions = []
        self.proof = proof
        self.prev_hash = prev_hash

    def to_dict(self):
        return dict(index=self.index,
                    timestamp=self.timestamp,
                    transactions=self.transactions,
                    proof=self.proof,
                    prev_hash=self.prev_hash)
