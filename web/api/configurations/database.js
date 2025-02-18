require("dotenv").config();

const mysql = require("mysql2");

const pool = mysql.createConnection({
  host: process.env.DB_HOST,
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
  database: process.env.DB_NAME,
  port: process.env.PORT,
});

pool.connect((error) => {
  if (error) {
    console.error("Error connecting to database: ", error);
  } else {
    console.log("Connected to database");
  }
});

module.exports = pool;
