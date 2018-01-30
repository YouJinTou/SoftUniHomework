from block import Block
import json
import hashlib
from urllib.parse import urlparse
from flask import Flask, jsonify, request

class Blockchain:
    def __init__(self):
        self.chain = []
        self.transactions = []
        self.create_block(Block(proof=100, prev_hash='1'))
        self.nodes = set()

    @property
    def tail(self):
        return self.chain[-1]

    def create_block(self, block):
        block.index = len(self.chain) + 1
        block.transactions = self.transactions
        block.prev_hash = block.prev_hash or self.hash_block(self.chain[-1])

        self.chain.append(block)

    def create_transaction(self, transaction):
        self.transactions.append(transaction)

    def register_node(self, address):
        self.nodes.add(urlparse(address))

    def resolve_conflicts(self):
        best_chain = None
        best_length = len(self.chain)

        for node in self.nodes:
            response = request.get('http://%s/chain' %node)

            if response.status_code == 200:
                length = response.json()['length']
                chain = response.json()['chain']

                if length > best_length and self.chain_valid(chain):
                    best_length = length
                    best_chain = chain

        if best_chain:
            self.chain = best_chain
            return True

        return False

    @staticmethod
    def chain_valid(chain):
        if len(chain) == 0:
            return True

        last_block = chain[0]
        current_block = 1

        while current_block < len(chain):
            block = chain[current_block]

            if block.prev_hash != Blockchain.hash_block(last_block):
                return False

            if not Blockchain.is_valid_proof(last_block.proof, block.proof):
                return False

            last_block = block
            current_block += 1

        return True

    @staticmethod
    def hash_block(block):
        block_string = json.dumps(block.__dict__, sort_keys=True).encode()
        return hashlib.sha256(block_string).hexdigest()

    @staticmethod
    def do_proof_of_work(self, last_proof):
        proof = 0

        while self.is_valid_proof(last_proof, proof) is False:
            proof += 1

        return proof

    @staticmethod
    def is_valid_proof(last_proof, proof):
        guess = f'{last_proof}{proof}'.encode()
        guess_hash = hashlib.sha256(guess).hexdigest()
        return guess_hash[:4] == '0000'