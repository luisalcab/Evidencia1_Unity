from flask import Flask
import sys
import random

app = Flask(__name__)

@app.route('/get_positions/<int:num>')
def principal(num):
    puntos = []
    for i in range(num):
        puntos.append({"id": i, "x": random.uniform(-1200, 1200), "y": 4, "z": random.uniform(-1200, 1200)})

    return {"carros": puntos}