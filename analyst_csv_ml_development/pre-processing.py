import pandas as pd
import mysql.connector

# Load the dataset
csv_file = 'data/server_fb_14-37_23-11-2023.csv'
df = pd.read_csv(csv_file, delimiter=';')

# Check for duplicate rows based on key columns
key_columns = ['Topic/Title', 'Content', 'Post time']
duplicates = df.duplicated(subset=key_columns, keep=False)
duplicate_rows = df[duplicates]

# Display duplicate rows
print(f'Duplicate Rows= {duplicate_rows}')

# Connect to MySQL database
# "NxcConnection": "server=192.168.10.30; port=3306; database=nxcapp; user=nxc_dbuser; password=123456; Persist Security Info=False; Connect Timeout=300; Convert Zero Datetime=true;"
connection = mysql.connector.connect(
    host="192.168.10.30",
    user="root",
    password="root",
    database="crawler"
    # host="192.168.10.30",
    # user="crawler_dbuser",
    # password="123456",
    # database="crawler"
)

# Create a table in MySQL
cursor = connection.cursor()

# Head fields: Crawler Date; Source; Language; Crawler Account; Post Account; Post Owner; Topic/Title; Content;Post time
create_table_query = """
CREATE TABLE IF NOT EXISTS jobs (
    `crawler_date` DATETIME,
    `source` VARCHAR(255),
    `language` VARCHAR(255),
    `crawler_account` VARCHAR(255),
    `post_account` VARCHAR(255),
    `post_owner` VARCHAR(255),
    `topic/title` VARCHAR(255),
    `content` TEXT,
    `post_time` DATETIME
);
"""
cursor.execute(create_table_query)

# Insert data into MySQL table
insert_query = f"INSERT INTO jobs ({', '.join(df.columns)}) VALUES ({', '.join(['%s']*len(df.columns))})"
data_to_insert = [tuple(row) for row in df.values]

cursor.executemany(insert_query, data_to_insert)
connection.commit()

# Close connection
cursor.close()
connection.close()