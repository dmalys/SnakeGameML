import os
import csv
import numpy as np
import tensorflow as tf
from tensorflow import keras
from flask import Flask, jsonify, request

app = Flask(__name__)


@app.route("/", methods=['POST'])
def index():
    global model

    #left = int(request.args.get("left")) / 1.0
    #front = int(request.args.get("front")) /1.0
    #right = int(request.args.get("right")) /1.0
    #dir =  int(request.args.get("dir")) / 1.0

    data = request.get_json(force=True)

    print(data)

    left = data['left']
    front = data['front']
    right = data['right']
    dir = data['dir']
    angle = data['angle']

    predict_array = np.array([[left, front, right, dir, angle]])
    result = model.predict(predict_array)
    
    return jsonify({"result":result.tolist()}), 200


if __name__ == '__main__':
    # load model
    json_file = open('modelDam.json', 'r')
    loaded_model_json = json_file.read()
    json_file.close()
    model = keras.models.model_from_json(loaded_model_json)

    # load weights
    model.load_weights('modelDam.h5')
    print('loaded model from files') 

    # compile model
    model.compile(optimizer='adam',
    loss='binary_crossentropy',
    metrics=['accuracy'])
    
    # fire flask service
    app.run(host='172.17.0.2',port=5000,debug=True)
