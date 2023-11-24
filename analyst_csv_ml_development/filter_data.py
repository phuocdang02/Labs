# moore_model.pkl
# marketing_sample_for_naukri_com-jobs__20190701_20190830__30k_data.csv

import pandas as pd

# Load the CSV file
csv_path = 'marketing_sample_for_naukri_com-jobs__20190701_20190830__30k_data.csv'  # Replace with the actual path to your CSV file
data = pd.read_csv(csv_path)

# Custom data processing - You can modify this based on your requirements
filtered_data = data[data['Location'].str.contains('Vietnam', case=False, na=False)]

# Save the processed data to a new CSV file
moore_model = 'moore_model2.csv'  # Replace with the desired output path
filtered_data.to_csv(moore_model, index=False)

print(f"Data saved to {moore_model}")
