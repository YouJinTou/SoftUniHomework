from transaction import Transaction
from block import Block
from blockchain import Blockchain
from uuid import uuid4
from flask import Flask, jsonify, request

SYSTEM_SENDER = '0'
MINE_REWARD = 1

app = Flask(__name__)
node_identifier = str(uuid4()).replace('-', '')
blockchain = Blockchain()


@app.route('/mine', methods=['POST'])
def mine():
    last_proof = blockchain.tail.index
    prev_hash = blockchain.hash_block(blockchain.tail)
    proof = blockchain.do_proof_of_work(last_proof)

    blockchain.create_block(Block(proof, prev_hash))
    blockchain.create_transaction(Transaction(SYSTEM_SENDER, node_identifier, MINE_REWARD))

    response = {
        'message': 'Block created.',
        'index': blockchain.tail.index,
        'transactions': blockchain.tail.transactions,
        'proof': blockchain.tail.proof,
        'prev_hash': blockchain.tail.prev_hash
    }
    return jsonify(response), 201


@app.route('/transactions/new', methods=['POST'])
def create_transaction(transaction):
    values = request.get_json()

    if not all(k in values for k in ['sender', 'recipient', 'amount']):
        return 'Missing values', 400

    blockchain.create_transaction(Transaction(values['sender'], values['recipient'], values['amount']))

    response = {
        'message': f'Transaction will be added to block {len(blockchain.chain) + 1}.'
    }
    return jsonify(response), 201


@app.route('/chain', methods=['GET'])
def chain():
    chain_info = {
        'chain': blockchain.chain,
        'length': len(blockchain.chain)
    }
    return jsonify(chain_info), 200


@app.route('/nodes/register', methods=['POST'])
def register_nodes():
    values = request.get_json()
    nodes = values.get('nodes')

    if nodes is None:
        return 'Invalid list of nodes.', 400

    for node in nodes:
        blockchain.register_node(node)

    response = {
        'message': 'New nodes added.',
        'total_nodes': list(blockchain.nodes)
    }
    return jsonify(response), 201


@app.route('/nodes/resolve', methods=['POST'])
def resolve():
    if blockchain.resolve_conflicts():
        response = {
            'message': 'Chain replaced.',
            'chain': blockchain.chain
        }
    else:
        response = {
            'message': 'Chain valid.',
            'chain': blockchain.chain
        }

    return jsonify(response), 200


if __name__ == '__main__':
    from argparse import ArgumentParser

    parser = ArgumentParser()
    parser.add_argument('-p', '--port', default=5000, type=int, help='Port to listen on.')
    args = parser.parse_args()

    app.run(host='127.0.0.1', port=args.port, debug=True, use_reloader=False)