const { v4: uuidv4 } = require("uuid");

const bcrypt = require("bcrypt");
const jwt = require("jsonwebtoken");
const response = require();
const service = require();
const userService = require("../services/userService");

exports.login = async (req, res) => {
  try {
    const { username, password } = req.body;
    const user = await userService.login(username, password);
  } catch (error) {
    res.status(500).json(response.error());
  }
};
