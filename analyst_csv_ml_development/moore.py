import pandas as pd
from sklearn.model_selection import train_test_split
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import accuracy_score, classification_report
import joblib

# Load the CSV file
csv_path = 'data/jobs.csv'
data_custom = pd.read_csv(csv_path)

# Add a new column as a unique identifier
data_custom['row_id'] = range(len(data_custom))

# Save new csv file with row_id
custom_data = data_custom
custom_csv = 'custom/moore_with_row_id.csv'
custom_data.to_csv(custom_csv, index= False)
print(f"New CSV has been saved: {custom_csv}")

# Read new custome csv file
custom_csv_path = 'custom/moore_with_row_id.csv'
data = pd.read_csv(custom_csv_path)

# Identify string columns that need encoding
string_columns = data.select_dtypes(include='object').columns

# Apply one-hot encoding for string columns
data = pd.get_dummies(data, columns=string_columns, drop_first=True)

X = data.drop('row_id', axis=1)
y = data['row_id']

# Split the data into training and testing sets
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Create and train the model
model = RandomForestClassifier(random_state=42)
model.fit(X, y)

# Save the trained model
model_path = 'training/moore_model.pkl'
joblib.dump(model, model_path)
print(f"Model trained and saved to {model_path}")
