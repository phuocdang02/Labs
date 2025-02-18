const pool = require("../configurations/database");
class DbContext extends Abstract {
  static async createTable() {
    try {
      // Create table if it doesn't exist
      const query = `
            CREATE TABLE IF NOT EXISTS user (
              user_id CHAR(36) PRIMARY KEY,
              username VARCHAR(255) NOT NULL,
              dob DATE NOT NULL,
              id_number NVARCHAR(12) NOT NULL,
              issue_date DATE NOT NULL,
              gender VARCHAR(10),
              fullname VARCHAR(255),
              phone_number VARCHAR(9),
              email VARCHAR(255) UNIQUE NOT NULL,
              hashpassword VARCHAR(255) NOT NULL,  // Renamed for clarity and security
              profile_pic VARCHAR(255),
              organizer_id CHAR(36) NOT NULL,
              role_id CHAR(36) NOT NULL,
              event_role_id CHAR(36),
              is_verified TINYINT(1) NOT NULL DEFAULT 0, // Renamed and set default value
              created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
              updated_at DATETIME ON UPDATE CURRENT_TIMESTAMP
            )
          `;

      await connection.query(query);
      console.log("Table 'user' created successfully");
    } catch (error) {
      console.error("Error creating table:", error);
      throw error; // Re-throw the error for proper handling
    }
  }
}
