import pandas as pd
# import joblib
import pickle

pkl_path = 'training/moore_model.pkl'
# Using Joblib
# data = joblib.load(pkl_path)

# dataFrame = pd.DataFrame(data)
# dataFrame.to_csv('converted_data.csv', index=False)

# Using Pickle
with open(pkl_path, 'rb')as file:
    data = pickle.load(file)

dataFrame = pd.DataFrame(data)
converted_data = 'converted_data.csv'
dataFrame.to_csv('converted_data.csv', index=False)
print(f"Data has been successfully converted and saved to {converted_data}.")