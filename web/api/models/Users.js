const pool = require("../configurations/database");

class Users {
  
  static async insert(data) {
    try {
      const query = "INSERT INTO users SET ?";
      const [result] = await query(query, data);
      return result;
    } catch (error) {
      throw error;
    }
  }

  static update(id, data) {
    try {
      const query = "UPDATE users SET ? WHERE id = ?";
      const [result] = pool.query(query, [data, id]);
      return result;
    } catch (error) {
      throw error;
    }
  }

  static delete(id) {
    try {
      const query = "DELETE FROM users WHERE id = ?";
      const [result] = pool.query(query, [id]);
      return result;
    } catch (error) {
      throw error;
    }
  }

  static checkUsernameOrEmail(username, email) {
    try {
      const query = "SELECT * FROM users WHERE username = ? OR email = ?";
      const [result] = pool.query(query, [email, username]);
      return result;
    } catch (error) {
      throw error;
    }
  }
}

module.exports = Users;
