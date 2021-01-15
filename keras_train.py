import csv
import numpy as np
import tensorflow as tf
from tensorflow import keras

results = []

with open("daneTest.txt") as csvfile:
    reader = csv.reader(csvfile, delimiter='\t')
    for row in reader:
        results.append(list(map(float, row)))

results_array = np.array(results)
rows = results_array.shape[0]
cols = results_array.shape[1]

results_split = np.hsplit(results_array, [5,rows])

x_train = results_split[0]
x_train = x_train

y_train = results_split[1]
y_train = y_train / 1.0

print("x_train")
print(x_train.shape)
print("y_shape")
print(y_train.shape)
print("x_train[0]")
print("First items:")
print(x_train[0])
print(y_train[0])
print("\n\n\n###########################\n\n")

model = tf.keras.models.Sequential([
    tf.keras.layers.Flatten(input_shape=(5,1)),
    tf.keras.layers.Dense(20, activation='relu'), 
    tf.keras.layers.Dropout(0.2),
    tf.keras.layers.Dense(1, activation='sigmoid')
])

model.compile(optimizer='adam',
    loss='binary_crossentropy',
    metrics=['accuracy'])

print("model complete")

model.fit(x_train, y_train, epochs=10, validation_split=0.2)

#model.evaluate(x_test, y_test)

model_json = model.to_json()
with open('modelDam.json', 'w') as json_file:
    json_file.write(model_json)
model.save_weights("modelDam.h5")
print("Saved model to disk")
